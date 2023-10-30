using UkranizatoTools3000.Impl;

namespace UkranizatoTools3000.Interfaces;

public interface ISearchEngine {
	List<LangBundleContainer> GetDataTranslateFiles(string path);
}