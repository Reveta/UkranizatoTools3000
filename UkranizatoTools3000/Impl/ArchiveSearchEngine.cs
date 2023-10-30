using UkranizatoTools3000.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace UkranizatoTools3000.Impl;

public class ArchiveSearchEngine : ASearchEngineBase {

	public override List<LangBundleContainer> GetDataTranslateFiles(string path) {
		List<LangBundleContainer> langBundles = new List<LangBundleContainer>();

		List<string> archiveFiles = SearchFiles(path, "*.*", true);

		foreach (var archiveFile in archiveFiles) {
			string extension = Path.GetExtension(archiveFile).ToLower();

			if (extension == ".jar" || extension == ".zip") {
				langBundles.AddRange(SearchArchives(archiveFile));
			}
		}

		return langBundles;
	}

	private List<LangBundleContainer> SearchArchives(string archiveFilePath) {
		List<LangBundleContainer> archiveLangBundles = new List<LangBundleContainer>();

		string extension = Path.GetExtension(archiveFilePath).ToLower();

		switch (extension) {
			case ".jar":
			case ".zip":
				archiveLangBundles.AddRange(SearchTranslateFilesBy(archiveFilePath));
				break;

			default:
				break;
		}

		return archiveLangBundles;
	}

	private List<LangBundleContainer> SearchTranslateFilesBy(string zipFilePath) {
		List<LangBundleContainer> zipLangBundles = new List<LangBundleContainer>();

		using (ZipArchive archive = ZipFile.OpenRead(zipFilePath)) {
			foreach (var entry in archive.Entries) {
				if (entry.FullName.Contains("lang") && base.IsEnglishFile(entry.FullName)) {
					string ukrainianPath = FindUkrainianFileIn(archive, entry.FullName);
					string russianPath = FindRussianFileIn(archive, entry.FullName); // Знаходимо російський шлях
					zipLangBundles.Add(new LangBundleContainer(zipFilePath, entry.FullName) {
						RussianPath = russianPath,
						UkrainianPath = ukrainianPath
					});
				}
			}
		}

		return zipLangBundles;
	}


	private string FindUkrainianFileIn(ZipArchive archive, string englishPath) {
		foreach (var entry in archive.Entries) {
			if (IsUkrainianFile(entry.FullName, englishPath)) {
				return entry.FullName;
			}
		}

		return null; // Якщо файл української локалізації не знайдено
	}

	private string FindRussianFileIn(ZipArchive archive, string englishPath) {
		foreach (var entry in archive.Entries) {
			if (IsRussianFile(entry.FullName, englishPath)) {
				return entry.FullName;
			}
		}

		return null; // Якщо файл російської локалізації не знайдено
	}

	private List<string> SearchFiles(string path, string searchPattern, bool includeSubdirectories = false) {
		List<string> foundFiles = new List<string>();

		if (Directory.Exists(path)) {
			foundFiles.AddRange(Directory.GetFiles(path,
				searchPattern,
				includeSubdirectories? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly));
		}

		return foundFiles;
	}
}