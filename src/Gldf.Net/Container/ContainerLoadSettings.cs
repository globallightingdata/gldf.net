namespace Gldf.Net.Container
{
    public class ContainerLoadSettings
    {
        public static ContainerLoadSettings Default => new();

        public ProductLoadBehaviour ProductLoadBehaviour { get; set; }

        public AssetLoadBehaviour AssetLoadBehaviour { get; set; }

        public SignatureLoadBehaviour SignatureLoadBehaviour { get; set; }

        public ContainerLoadSettings()
        {
        }

        public ContainerLoadSettings(ProductLoadBehaviour productLoadBehaviour)
        {
            ProductLoadBehaviour = productLoadBehaviour;
            AssetLoadBehaviour = AssetLoadBehaviour.Load;
            SignatureLoadBehaviour = SignatureLoadBehaviour.Load;
        }

        public ContainerLoadSettings(AssetLoadBehaviour assetLoadBehaviour)
        {
            ProductLoadBehaviour = ProductLoadBehaviour.Load;
            AssetLoadBehaviour = assetLoadBehaviour;
            SignatureLoadBehaviour = SignatureLoadBehaviour.Load;
        }

        public ContainerLoadSettings(SignatureLoadBehaviour signatureLoadBehaviour)
        {
            ProductLoadBehaviour = ProductLoadBehaviour.Load;
            AssetLoadBehaviour = AssetLoadBehaviour.Load;
            SignatureLoadBehaviour = signatureLoadBehaviour;
        }

        public ContainerLoadSettings(ProductLoadBehaviour productLoadBehaviour, AssetLoadBehaviour assetLoadBehaviour,
            SignatureLoadBehaviour signatureLoadBehaviour)
        {
            ProductLoadBehaviour = productLoadBehaviour;
            AssetLoadBehaviour = assetLoadBehaviour;
            SignatureLoadBehaviour = signatureLoadBehaviour;
        }
    }

    public enum ProductLoadBehaviour
    {
        Load,
        Skip
    }

    public enum AssetLoadBehaviour
    {
        Load,
        FileNamesOnly,
        Skip
    }

    public enum SignatureLoadBehaviour
    {
        Load,
        Skip
    }
}