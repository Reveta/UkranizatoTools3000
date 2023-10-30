using UkranizatoTools3000.Impl;

namespace UkranizatoTools3000;

public interface IMainController {
	void SetFolderPath(string path);

	void StartSearch();

	void CreateUkraineLocalisationFile(LangBundleContainer originalLocalisationFile, string newName);


}
