using UkranizatoTools3000.Impl;
using UkranizatoTools3000.Interfaces.model;

namespace UkranizatoTools3000.Interfaces;

public class TranslatedBundleManager : ITranslatedBundleManager {
	private List<LangBundleContainer> bundles = new();

	public List<LangBundleContainer> GetAll() {
		return bundles;
	}
	public void Set(List<LangBundleContainer> bundleContainers) {
		bundles = bundleContainers;
	}

	public void Add(LangBundleContainer container) {
		// Перевірка, чи вже існує об'єкт зі збігом EnglishPath
		var existingBundle = bundles.FirstOrDefault(bundle => bundle.EnglishPath == container.EnglishPath);

		if (existingBundle != null) {
			// Замінюємо існуючий об'єкт новим
			bundles.Remove(existingBundle);
		}

		bundles.Add(container);
	}

	public LangBundleContainer FindBy(string originalPath) {
		return bundles.FirstOrDefault(bundle => bundle.EnglishPath == originalPath);
	}
}