using UkranizatoTools3000.Interfaces.model;

namespace UkranizatoTools3000.Interfaces;

public interface IModel {
	ITranslatedBundleManager BundleManager { get; }
}