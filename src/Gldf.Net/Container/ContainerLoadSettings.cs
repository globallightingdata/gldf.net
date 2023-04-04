namespace Gldf.Net.Container;

public class ContainerLoadSettings
{
    public static ContainerLoadSettings Default => new();

    public ProductLoadBehaviour ProductLoadBehaviour { get; set; }

    public AssetLoadBehaviour AssetLoadBehaviour { get; set; }

    public MetaInfoLoadBehaviour MetaInfoLoadBehaviour { get; set; }

    public ContainerLoadSettings()
    {
    }

    public ContainerLoadSettings(ProductLoadBehaviour productLoadBehaviour)
    {
        ProductLoadBehaviour = productLoadBehaviour;
        AssetLoadBehaviour = AssetLoadBehaviour.Load;
        MetaInfoLoadBehaviour = MetaInfoLoadBehaviour.Load;
    }

    public ContainerLoadSettings(AssetLoadBehaviour assetLoadBehaviour)
    {
        ProductLoadBehaviour = ProductLoadBehaviour.Load;
        AssetLoadBehaviour = assetLoadBehaviour;
        MetaInfoLoadBehaviour = MetaInfoLoadBehaviour.Load;
    }

    public ContainerLoadSettings(MetaInfoLoadBehaviour metaInfoLoadBehaviour)
    {
        ProductLoadBehaviour = ProductLoadBehaviour.Load;
        AssetLoadBehaviour = AssetLoadBehaviour.Load;
        MetaInfoLoadBehaviour = metaInfoLoadBehaviour;
    }

    public ContainerLoadSettings(ProductLoadBehaviour productLoadBehaviour, AssetLoadBehaviour assetLoadBehaviour,
        MetaInfoLoadBehaviour metaInfoLoadBehaviour)
    {
        ProductLoadBehaviour = productLoadBehaviour;
        AssetLoadBehaviour = assetLoadBehaviour;
        MetaInfoLoadBehaviour = metaInfoLoadBehaviour;
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

public enum MetaInfoLoadBehaviour
{
    Load,
    Skip
}