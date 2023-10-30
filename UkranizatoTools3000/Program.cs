using UkranizatoTools3000.Impl;
using UkranizatoTools3000.Interfaces;
using UkranizatoTools3000.Interfaces.model;

namespace UkranizatoTools3000;

static class Program {

	[STAThread]
	static void Main() {
		ITranslatedBundleManager bundleManager = new TranslatedBundleManager();
		IModel model = new Model(bundleManager);

		ISearchEngine archiveSearch = new ArchiveSearchEngine();
		ISearchEngine searchEngine = new SearchFoldersEngine();
		IMainController mainController = new MainController(model, searchEngine, archiveSearch);

		ApplicationConfiguration.Initialize();
		Application.Run(new Form1(mainController, model));
	}
}