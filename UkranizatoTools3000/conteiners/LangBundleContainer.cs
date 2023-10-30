namespace UkranizatoTools3000.Impl {
	public class LangBundleContainer
	{
		public FileLocation Location { get; set; }
		public string ArchivePath { get; set; }
		public string EnglishPath { get; set; }
		public string RussianPath { get; set; }
		public string UkrainianPath { get; set; } // Додайте поле для українського шляху

		public LangBundleContainer(string archivePath, string englishPath)
		{
			Location = FileLocation.Archive;
			ArchivePath = archivePath;
			EnglishPath = englishPath;
			RussianPath = "";
			UkrainianPath = ""; // Ініціалізуйте український шлях пустим рядком
		}

		public LangBundleContainer(string englishPath)
		{
			Location = FileLocation.Folder;
			EnglishPath = englishPath;
			RussianPath = "";
			UkrainianPath = ""; // Ініціалізуйте український шлях пустим рядком
		}
	}
}

public enum FileLocation
{
	Folder,
	Archive
}
