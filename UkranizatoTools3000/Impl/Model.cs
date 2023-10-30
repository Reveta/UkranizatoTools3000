using UkranizatoTools3000.Interfaces;
using UkranizatoTools3000.Interfaces.model;

namespace UkranizatoTools3000.Impl;

public class Model : IModel {

	public ITranslatedBundleManager BundleManager { get; }

	public Model(ITranslatedBundleManager bundleManager) {
		BundleManager = bundleManager;
	}
}