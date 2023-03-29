using FluentAssertions;
using Gldf.Net.Container;
using Gldf.Net.Domain.Xml;
using Gldf.Net.Domain.Xml.Definition.Types;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Gldf.Net.Tests.ContainerTests
{
    [TestFixture]
    public class GldfContainerTests
    {
        public delegate List<ContainerFile> ListSelector(GldfContainer container);

        [Test]
        public void Ctor_ShouldThrow_When_Root_IsNull()
        {
            void Ctor1() => _ = new GldfContainer(null);
            void Ctor2() => _ = new GldfContainer(null, new GldfAssets());
            void Ctor3() => _ = new GldfContainer(null, new GldfAssets(), new MetaInformation());

            void Test(Action act) => act.Should()
                .ThrowExactly<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'root')");

            Test(Ctor1);
            Test(Ctor2);
            Test(Ctor3);
        }

        [Test]
        public void Ctor_ShouldThrow_When_Assets_IsNull()
        {
            void Ctor1() => _ = new GldfContainer(new Root(), (GldfAssets)null);
            void Ctor2() => _ = new GldfContainer(new Root(), null, new MetaInformation());

            void Test(Action act) => act.Should()
                .ThrowExactly<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'assets')");

            Test(Ctor1);
            Test(Ctor2);
        }

        [Test]
        public void Ctor_ShouldThrow_When_Signature_IsNull()
        {
            void Ctor1() => _ = new GldfContainer(new Root(), (MetaInformation)null);
            void Ctor2() => _ = new GldfContainer(new Root(), new GldfAssets(), null);

            void Test(Action act) => act.Should()
                .ThrowExactly<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'metaInformation')");

            Test(Ctor1);
            Test(Ctor2);
        }

        [Test]
        public void Ctor_ShouldInitialize_AllProperties()
        {
            var gldfContainer = new GldfContainer();

            gldfContainer.Product.Should().NotBeNull();
            gldfContainer.Assets.All.Should().HaveCount(0);
            gldfContainer.Signature.Should().BeNull();
        }

        [Test]
        public void Ctor_ShouldSet_Root()
        {
            var root = new Root();
            var gldfContainer = new GldfContainer(root);

            gldfContainer.Product.Should().BeSameAs(root);
            gldfContainer.Assets.All.Should().HaveCount(0);
            gldfContainer.Signature.Should().BeNull();
        }

        [Test]
        public void Ctor_ShouldSet_RootAndAssets()
        {
            var root = new Root();
            var assets = new GldfAssets();
            var gldfContainer = new GldfContainer(root, assets);

            gldfContainer.Product.Should().BeSameAs(root);
            gldfContainer.Assets.Should().BeSameAs(assets);
            gldfContainer.Signature.Should().BeNull();
        }

        [Test]
        public void Ctor_ShouldSet_RootAndSignature()
        {
            var root = new Root();
            var metaInformation = new MetaInformation();
            var gldfContainer = new GldfContainer(root, metaInformation);

            gldfContainer.Product.Should().BeSameAs(root);
            gldfContainer.Assets.All.Should().HaveCount(0);
            gldfContainer.Signature.Should().BeSameAs(metaInformation);
        }

        [Test]
        public void Ctor_ShouldSet_RootSignatureAndAssets()
        {
            var root = new Root();
            var assets = new GldfAssets();
            var metaInformation = new MetaInformation();
            var gldfContainer = new GldfContainer(root, assets, metaInformation);

            gldfContainer.Product.Should().BeSameAs(root);
            gldfContainer.Assets.Should().BeSameAs(assets);
            gldfContainer.Signature.Should().BeSameAs(metaInformation);
        }

        [TestCaseSource(nameof(TestData))]
        public void AddAssetFile_ShouldAdd_ToExpectedCollection(ListSelector listSelector, FileContentType type)
        {
            const string fileName = "file";
            var fileContent = new byte[1];
            var gldfContainer = new GldfContainer();

            gldfContainer.AddAssetFile(type, fileName, fileContent);

            listSelector(gldfContainer).Should().ContainEquivalentOf(new ContainerFile(fileName, fileContent));
        }

        [TestCaseSource(nameof(TestData))]
        public void AddAssetFile_ShouldThrow_When_FileName_IsNull(ListSelector _, FileContentType type)
        {
            var gldfContainer = new GldfContainer();
            Action act = () => gldfContainer.AddAssetFile(type, null, new byte[1]);

            act.Should().Throw<ArgumentNullException>();
        }

        [TestCaseSource(nameof(TestData))]
        public void AddAssetFile_ShouldThrow_When_FileContent_IsNull(ListSelector _, FileContentType type)
        {
            var gldfContainer = new GldfContainer();
            Action act = () => gldfContainer.AddAssetFile(type, "fileName", null);

            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void AddAssetFile_ShouldThrow_When_InvalidFileContentType()
        {
            var gldfContainer = new GldfContainer();
            Action act = () => gldfContainer.AddAssetFile((FileContentType)int.MaxValue, "fileName", null);

            act.Should()
                .ThrowExactly<InvalidEnumArgumentException>()
                .WithMessage("The value of argument 'fileContentType' (2147483647) " +
                             "is invalid for Enum type 'FileContentType'*");
        }

        public static List<TestCaseData> TestData => new()
        {
            new TestCaseData(new ListSelector(container => container.Assets.Geometries), FileContentType.GeoL3d),
            new TestCaseData(new ListSelector(container => container.Assets.Geometries), FileContentType.GeoM3d),
            new TestCaseData(new ListSelector(container => container.Assets.Geometries), FileContentType.GeoR3d),
            new TestCaseData(new ListSelector(container => container.Assets.Images), FileContentType.ImageSvg),
            new TestCaseData(new ListSelector(container => container.Assets.Images), FileContentType.ImagePng),
            new TestCaseData(new ListSelector(container => container.Assets.Images), FileContentType.ImageJpg),
            new TestCaseData(new ListSelector(container => container.Assets.Documents), FileContentType.DocPdf),
            new TestCaseData(new ListSelector(container => container.Assets.Photometries), FileContentType.LdcIesXml),
            new TestCaseData(new ListSelector(container => container.Assets.Photometries), FileContentType.LdcEulumdat),
            new TestCaseData(new ListSelector(container => container.Assets.Photometries), FileContentType.LdcIes),
            new TestCaseData(new ListSelector(container => container.Assets.Other), FileContentType.Other),
            new TestCaseData(new ListSelector(container => container.Assets.Sensors), FileContentType.SensorSensXml),
            new TestCaseData(new ListSelector(container => container.Assets.Sensors), FileContentType.SensorSensLdt),
            new TestCaseData(new ListSelector(container => container.Assets.Symbols), FileContentType.SymbolSvg),
            new TestCaseData(new ListSelector(container => container.Assets.Symbols), FileContentType.SymbolDxf),
            new TestCaseData(new ListSelector(container => container.Assets.Spectrums), FileContentType.SpectrumText)
        };
    }
}