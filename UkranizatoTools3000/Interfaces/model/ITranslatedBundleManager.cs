using UkranizatoTools3000.Impl;

namespace UkranizatoTools3000.Interfaces.model {
	public interface ITranslatedBundleManager {
		List<LangBundleContainer> GetAll();
		void Set(List<LangBundleContainer> bundleContainers);
		void Add(LangBundleContainer container);
		LangBundleContainer FindBy(string originalPath);
	}

}