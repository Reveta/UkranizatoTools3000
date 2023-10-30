using UkranizatoTools3000.Impl;
using UkranizatoTools3000.Interfaces;

namespace UkranizatoTools3000;

public partial class Form1 : Form {
	private readonly IModel _model;
	private readonly IMainController _mainController;


	public Form1(IMainController mainController, IModel model) {
		_mainController = mainController;
		_model = model;
		InitializeComponent();
	}

	private void selectPathButton_Click(object sender, EventArgs e) {
		using (FolderBrowserDialog folderDialog = new FolderBrowserDialog()) {
			folderDialog.Description = "Виберіть папку з файлами";

			DialogResult result = folderDialog.ShowDialog();

			if (result == DialogResult.OK) {
				_mainController.SetFolderPath(folderDialog.SelectedPath);
				selectedPathTextBox.Text = folderDialog.SelectedPath;
			}
		}
	}


	private void searchFilesButton_Click(object sender, EventArgs e) {
		if (string.IsNullOrEmpty(this.selectedPathTextBox.Text)) {
			throw new InvalidOperationException(
				"Шлях до папки не встановлено. Використовуйте SetFolderPath() для встановлення шляху.");
		}
		_mainController.StartSearch();

		if (_model.BundleManager.GetAll().Count == 0) {
			MessageBox.Show("Папок 'lang' не знайдено.", "Результат пошуку");
			return;
		}

		folderList.Items.Clear(); // Очистити список перед пошуком

		var pathGroups = _model.BundleManager.GetAll()
			.Select(translateData => new { Path = translateData.EnglishPath, Count = 1 })
			.GroupBy(item => item.Path)
			.Select(group => new { Path = group.Key, Count = group.Sum(item => item.Count) })
			.ToList();

		foreach (var group in pathGroups) {
			folderList.Items.Add($"{group.Path}");
		}

	}


	private void createLocalizationFileButton_Click(object? sender, EventArgs e) {
		int selectedIndex = folderList.SelectedIndex;
		if (selectedIndex < 0 || selectedIndex >= folderList.Items.Count) {
			MessageBox.Show("Виберіть файл для створення локалізаційного файлу.");
			return;
		}

		string selectedLocalizationFile = folderList.Items[selectedIndex].ToString();
		LangBundleContainer container = _model.BundleManager.FindBy(selectedLocalizationFile);

		if (container == null) {
			MessageBox.Show("Неможливо знайти вибраний файл.");
			return;
		}

		string newName = newLocalizationFileNameTextBox.Text.Trim();

		if (string.IsNullOrWhiteSpace(newName)) {
			MessageBox.Show("Введіть нову назву локалізаційного файлу.");
			return;
		}

		// Перевірка, чи нове ім'я містить "ua" або "ukr"
		if (newName.Contains("ua") || newName.Contains("ukr")) {
			_mainController.CreateUkraineLocalisationFile(container, newName);
			newLocalizationFileNameTextBox.Text = string.Empty; // Очистити поле для нового імені
		} else {
			MessageBox.Show("Нова назва файлу має містити 'ua' або 'ukr'.");
		}
	}


	private void editLocalizationFileButton_Click(object? sender, EventArgs e) {
		int selectedIndex = folderList.SelectedIndex;

		if (selectedIndex >= 0) {
			string selectedLocalizationFile = folderList.Items[selectedIndex].ToString();


		}
	}
	private void nextTranslationButton_Click(object? sender, EventArgs e) {
		throw new NotImplementedException();
	}
	private void previousTranslationButton_Click(object? sender, EventArgs e) {
		throw new NotImplementedException();
	}
}