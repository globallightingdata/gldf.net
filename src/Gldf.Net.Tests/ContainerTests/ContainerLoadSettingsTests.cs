using FluentAssertions;
using Gldf.Net.Container;
using NUnit.Framework;

namespace Gldf.Net.Tests.ContainerTests;

[TestFixture]
public class ContainerLoadSettingsTests
{
    [Test]
    public void Ctor_Should_SetDefault_ToLoadComplete()
    {
        var settings = new ContainerLoadSettings();

        settings.ProductLoadBehaviour.Should().Be(ProductLoadBehaviour.Load);
        settings.AssetLoadBehaviour.Should().Be(AssetLoadBehaviour.Load);
        settings.MetaInfoLoadBehaviour.Should().Be(MetaInfoLoadBehaviour.Load);
    }

    [Test]
    public void Ctor_Should_SetProductLoadBehaviour_AsExpected()
    {
        var settings = new ContainerLoadSettings(ProductLoadBehaviour.Skip);

        settings.ProductLoadBehaviour.Should().Be(ProductLoadBehaviour.Skip);
        settings.AssetLoadBehaviour.Should().Be(AssetLoadBehaviour.Load);
        settings.MetaInfoLoadBehaviour.Should().Be(MetaInfoLoadBehaviour.Load);
    }

    [Test]
    public void Ctor_Should_SetAssetLoadBehaviour_AsExpected()
    {
        var settings = new ContainerLoadSettings(AssetLoadBehaviour.Skip);

        settings.ProductLoadBehaviour.Should().Be(ProductLoadBehaviour.Load);
        settings.AssetLoadBehaviour.Should().Be(AssetLoadBehaviour.Skip);
        settings.MetaInfoLoadBehaviour.Should().Be(MetaInfoLoadBehaviour.Load);
    }

    [Test]
    public void Ctor_Should_SetMetaInfoLoadBehaviour_AsExpected()
    {
        var settings = new ContainerLoadSettings(MetaInfoLoadBehaviour.Skip);

        settings.ProductLoadBehaviour.Should().Be(ProductLoadBehaviour.Load);
        settings.AssetLoadBehaviour.Should().Be(AssetLoadBehaviour.Load);
        settings.MetaInfoLoadBehaviour.Should().Be(MetaInfoLoadBehaviour.Skip);
    }

    [Test, Combinatorial]
    public void Ctor_Should_SetParameter_AsExpected(
        [Values(ProductLoadBehaviour.Load, ProductLoadBehaviour.Skip)]
        ProductLoadBehaviour productLoadBehaviour,
        [Values(AssetLoadBehaviour.Load, AssetLoadBehaviour.Skip, AssetLoadBehaviour.FileNamesOnly)]
        AssetLoadBehaviour assetLoadBehaviour,
        [Values(MetaInfoLoadBehaviour.Load, MetaInfoLoadBehaviour.Skip)]
        MetaInfoLoadBehaviour metaInfoLoadBehaviour)
    {
        var settings = new ContainerLoadSettings(productLoadBehaviour, assetLoadBehaviour, metaInfoLoadBehaviour);

        settings.ProductLoadBehaviour.Should().Be(productLoadBehaviour);
        settings.AssetLoadBehaviour.Should().Be(assetLoadBehaviour);
        settings.MetaInfoLoadBehaviour.Should().Be(metaInfoLoadBehaviour);
    }
}