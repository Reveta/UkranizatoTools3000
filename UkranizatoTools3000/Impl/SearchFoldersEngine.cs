using UkranizatoTools3000.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UkranizatoTools3000.Impl {
	public class SearchFoldersEngine : ASearchEngineBase {

		public override List<LangBundleContainer> GetDataTranslateFiles(string path) {
			List<LangBundleContainer> langBundles = new List<LangBundleContainer>();

			// Рекурсивно шукаємо файли із англійською локалізацією
			List<LangBundleContainer> englishFiles = SearchEnglishFiles(path);

			foreach (var englishFile in englishFiles) {
				langBundles.Add(englishFile);
			}

			return langBundles;
		}


		private List<LangBundleContainer> SearchEnglishFiles(string directoryPath) {
			List<LangBundleContainer> englishFiles = new List<LangBundleContainer>();

			foreach (string filePath in Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories)) {
				// Перевіряємо, чи шлях містить папку "lang" і чи це англійський файл
				if (filePath.Contains("lang") && base.IsEnglishFile(filePath)) {
					string ukrainianPath = FindUkrainianFile(filePath);
					string russianPath = FindRussianFile(filePath); // Знаходимо російський шлях
					englishFiles.Add(new LangBundleContainer(filePath) {
						RussianPath = russianPath,
						UkrainianPath = ukrainianPath
					});
				}
			}

			return englishFiles;
		}


		//TODO use base methods for searching ua and ru translation
		private string FindUkrainianFile(string englishPath) {
			string directory = Path.GetDirectoryName(englishPath);
			string extension = Path.GetExtension(englishPath);

			// Шукаємо файли з частинками "ru" або "rus" в назві
			string[] russianKeywords = { "ua", "ukr", "UA" };

			foreach (string russianKeyword in russianKeywords) {
				string russianPattern = "*" + russianKeyword + "*" + extension;
				string[] russianFiles = Directory.GetFiles(directory, russianPattern);

				if (russianFiles.Length > 0) {
					return russianFiles[0];
				}
			}

			return null;
		}

		private string FindRussianFile(string englishPath) {
			string directory = Path.GetDirectoryName(englishPath);
			string extension = Path.GetExtension(englishPath);

			// Шукаємо файли з частинками "ru" або "rus" в назві
			string[] russianKeywords = { "ru", "rus" };

			foreach (string russianKeyword in russianKeywords) {
				string russianPattern = "*" + russianKeyword + "*" + extension;
				string[] russianFiles = Directory.GetFiles(directory, russianPattern);

				if (russianFiles.Length > 0) {
					return russianFiles[0];
				}
			}

			return null; // Якщо файл російської локалізації не знайдено
		}


	}
}