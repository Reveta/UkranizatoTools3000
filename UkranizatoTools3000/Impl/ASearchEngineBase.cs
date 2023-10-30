using UkranizatoTools3000.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace UkranizatoTools3000.Impl {
	public abstract class ASearchEngineBase : ISearchEngine {
		public abstract List<LangBundleContainer> GetDataTranslateFiles(string path);

		protected virtual bool IsRussianFile(string filePath, string englishPath) {
			string[] russianKeywords = { "ru", "rus", "RU" };

			// Розділюємо назву файлу на слова за допомогою розділювачів, таких як '_', '-', і крапка
			string[] words = Path.GetFileNameWithoutExtension(filePath).Split(new char[] { '_', '-', '.' });

			// Перевіряємо, чи файл містить хоча б одну частинку англійської локалізації
			foreach (string keyword in russianKeywords) {
				foreach (string word in words) {
					if (word.Equals(keyword, StringComparison.OrdinalIgnoreCase)) {
						return true;
					}
				}
			}

			return false;
		}

		protected virtual bool IsUkrainianFile(string filePath, string englishPath) {
			string[] russianKeywords = { "ua", "ukr", "UA" };

			// Розділюємо назву файлу на слова за допомогою розділювачів, таких як '_', '-', і крапка
			string[] words = Path.GetFileNameWithoutExtension(filePath).Split(new char[] { '_', '-', '.' });

			// Перевіряємо, чи файл містить хоча б одну частинку англійської локалізації
			foreach (string keyword in russianKeywords) {
				foreach (string word in words) {
					if (word.Equals(keyword, StringComparison.OrdinalIgnoreCase)) {
						return true;
					}
				}
			}

			return false;
		}


		protected virtual bool IsEnglishFile(string filePath) {
			// Масив можливих частинок для англійської локалізації
			string[] englishKeywords = { "en", "eng" };

			// Розділюємо назву файлу на слова за допомогою розділювачів, таких як '_', '-', і крапка
			string[] words = Path.GetFileNameWithoutExtension(filePath).Split(new char[] { '_', '-', '.' });

			// Перевіряємо, чи файл містить хоча б одну частинку англійської локалізації
			foreach (string keyword in englishKeywords) {
				foreach (string word in words) {
					if (word.Equals(keyword, StringComparison.OrdinalIgnoreCase)) {
						return true;
					}
				}
			}

			return false;
		}
	}
}