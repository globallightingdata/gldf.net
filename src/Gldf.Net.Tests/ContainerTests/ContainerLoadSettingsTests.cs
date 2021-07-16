using FluentAssertions;
using Gldf.Net.Container;
using NUnit.Framework;

namespace Gldf.Net.Tests.ContainerTests
{
    [TestFixture]
    public class ContainerLoadSettingsTests
    {
        [Test]
        public void Ctor_Should_SetDefault_ToLoadComplete()
        {
            var settings = new ContainerLoadSettings();

            settings.ProductLoadBehaviour.Should().Be(ProductLoadBehaviour.Load);
            settings.AssetLoadBehaviour.Should().Be(AssetLoadBehaviour.Load);
            settings.SignatureLoadBehaviour.Should().Be(SignatureLoadBehaviour.Load);
        }

        [Test]
        public void Ctor_Should_SetProductLoadBehaviour_AsExpected()
        {
            var settings = new ContainerLoadSettings(ProductLoadBehaviour.Skip);

            settings.ProductLoadBehaviour.Should().Be(ProductLoadBehaviour.Skip);
            settings.AssetLoadBehaviour.Should().Be(AssetLoadBehaviour.Load);
            settings.SignatureLoadBehaviour.Should().Be(SignatureLoadBehaviour.Load);
        }

        [Test]
        public void Ctor_Should_SetAssetLoadBehaviour_AsExpected()
        {
            var settings = new ContainerLoadSettings(AssetLoadBehaviour.Skip);

            settings.ProductLoadBehaviour.Should().Be(ProductLoadBehaviour.Load);
            settings.AssetLoadBehaviour.Should().Be(AssetLoadBehaviour.Skip);
            settings.SignatureLoadBehaviour.Should().Be(SignatureLoadBehaviour.Load);
        }

        [Test]
        public void Ctor_Should_SetSignatureLoadBehaviour_AsExpected()
        {
            var settings = new ContainerLoadSettings(SignatureLoadBehaviour.Skip);

            settings.ProductLoadBehaviour.Should().Be(ProductLoadBehaviour.Load);
            settings.AssetLoadBehaviour.Should().Be(AssetLoadBehaviour.Load);
            settings.SignatureLoadBehaviour.Should().Be(SignatureLoadBehaviour.Skip);
        }

        [Test, Combinatorial]
        public void Ctor_Should_SetParameter_AsExpected(
            [Values(ProductLoadBehaviour.Load, ProductLoadBehaviour.Skip)]
            ProductLoadBehaviour productLoadBehaviour,
            [Values(AssetLoadBehaviour.Load, AssetLoadBehaviour.Skip, AssetLoadBehaviour.FileNamesOnly)]
            AssetLoadBehaviour assetLoadBehaviour,
            [Values(SignatureLoadBehaviour.Load, SignatureLoadBehaviour.Skip)]
            SignatureLoadBehaviour signatureLoadBehaviour)
        {
            var settings = new ContainerLoadSettings(productLoadBehaviour, assetLoadBehaviour, signatureLoadBehaviour);

            settings.ProductLoadBehaviour.Should().Be(productLoadBehaviour);
            settings.AssetLoadBehaviour.Should().Be(assetLoadBehaviour);
            settings.SignatureLoadBehaviour.Should().Be(signatureLoadBehaviour);
        }
    }
}