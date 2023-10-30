using UkranizatoTools3000.Interfaces;
using System.Collections.Generic;

namespace UkranizatoTools3000.Impl {
	public class MainController : IMainController {
		private readonly IModel _model;
		private readonly ISearchEngine[] _searchEngines;
		private string? folderPath;
		public List<LangBundleContainer> Paths = new();
		public MainController(IModel model, params ISearchEngine[] searchEngines) {
			_model = model;
			_searchEngines = searchEngines;
		}

		public void SetFolderPath(string? path) {
			if (Directory.Exists(path)) {
				folderPath = path;
			} else {
				throw new DirectoryNotFoundException("Папку не знайдено. Виберіть дійсний шлях.");
			}
		}

		public void StartSearch() {
			Paths.Clear();

			if (string.IsNullOrEmpty(folderPath)) {
				throw new InvalidOperationException(
					"Шлях до папки не встановлено. Використовуйте SetFolderPath() для встановлення шляху.");
			}

			SearchLangFolders();
		}
		public void CreateUkraineLocalisationFile(LangBundleContainer? originalLocalisationFile, string newName) {
			if (originalLocalisationFile != null) {
				// Отримайте шлях до теки, де розташований англійський файл
				string englishPath = originalLocalisationFile.EnglishPath;
				string directoryPath = Path.GetDirectoryName(englishPath);

				// Отримайте розширення з англійського файлу
				string fileExtension = Path.GetExtension(englishPath);

				// Видаліть розширення з імені файлу, якщо воно є
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(newName);

				// Створіть новий шлях для файлу з врахуванням розширення
				string newFileName = $"{fileNameWithoutExtension}{fileExtension}";
				string newFilePath = Path.Combine(directoryPath, newFileName);

				// Створіть новий файл і закрийте його (якщо потрібно)
				using (File.Create(newFilePath)) {}

				// Оновіть інформацію про новий файл у контейнері
				originalLocalisationFile.UkrainianPath = newFilePath;

				// Оновіть інформацію про новий файл в моделі через інтерфейс IModel
				_model.BundleManager.Add(originalLocalisationFile);
			}
		}
		private void SearchLangFolders() {

			foreach (var searchEngine in _searchEngines) {
				var enginePaths = searchEngine.GetDataTranslateFiles(folderPath);
				Paths.AddRange(enginePaths);
			}

			Paths = Paths.Distinct().ToList();
			_model.BundleManager.Set(Paths);
		}
	}
}