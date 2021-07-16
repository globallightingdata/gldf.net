using FluentAssertions;
using Gldf.Net.Container;
using Gldf.Net.Domain;
using Gldf.Net.Exceptions;
using Gldf.Net.Tests.TestData;
using NUnit.Framework;
using System;
using System.IO;
using System.IO.Compression;

namespace Gldf.Net.Tests
{
    [TestFixture]
    public class GldfContainerReadTests
    {
        private GldfContainer _gldfContainer;
        private string _tempFile;

        [SetUp]
        public void SetUp()
        {
            _gldfContainer = new GldfContainer();
            _tempFile = Path.GetTempFileName();
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(_tempFile);
        }

        [Test]
        public void ReadFromFile_EmptyContainer_ShouldThrow_BecauseOf_Missing_ProductXml()
        {
            ZipFile.Open(_tempFile, ZipArchiveMode.Update).Dispose();

            Action act = () => _gldfContainer.ReadFromFile(_tempFile);

            act.Should()
                .Throw<GldfContainerException>()
                .WithMessage("Failed to read GldfContainer from*")
                .WithInnerException<RootNotFoundException>()
                .WithMessage($"Required product.xml not found in root of {nameof(GldfContainer)}");
        }

        [Test]
        public void ReadFromFile_InvalidContainer_ShouldThrow_UnreadableContainerException()
        {
            File.WriteAllBytes(_tempFile, new byte[10]);

            Action act = () => _gldfContainer.ReadFromFile(_tempFile);

            act.Should()
                .Throw<GldfContainerException>()
                .WithMessage("Failed to read GldfContainer from*")
                .WithInnerException<InvalidDataException>();
        }

        [Test]
        public void ReadFromFile_Should_ReadAndDeserialize_ProductXml()
        {
            var expectedModel = EmbeddedXmlTestData.GetHeaderMandatoryModel();
            var gldfBytes = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
            File.WriteAllBytes(_tempFile, gldfBytes);

            var archive = _gldfContainer.ReadFromFile(_tempFile);

            archive.Product.Should().BeEquivalentTo(expectedModel);
        }

        [Test]
        public void ReadFromFile_WithSkipProductSetting_Should_SkipRoot()
        {
            var settings = new ContainerLoadSettings(ProductLoadBehaviour.Skip);
            var gldfBytesWithHeader = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
            var expectedEmptyRoot = new Root();
            File.WriteAllBytes(_tempFile, gldfBytesWithHeader);

            var archive = _gldfContainer.ReadFromFile(_tempFile, settings);

            archive.Product.Should().BeEquivalentTo(expectedEmptyRoot);
        }

        [Test]
        public void ReadFromFile_WithSkipFilesSetting_ShouldReturn_EmptyAssets()
        {
            var settings = new ContainerLoadSettings(AssetLoadBehaviour.Skip);
            var gldfBytesWithHeader = EmbeddedGldfTestData.GetGldfWithFiles();
            File.WriteAllBytes(_tempFile, gldfBytesWithHeader);

            var archive = _gldfContainer.ReadFromFile(_tempFile, settings);

            archive.Assets.All.Should().BeEmpty();
        }

        [Test]
        public void ReadFromFile_WithFilesNamesOnlySetting_ShouldReturn_AssetsWithoutContent()
        {
            var settings = new ContainerLoadSettings(AssetLoadBehaviour.FileNamesOnly);
            var gldfBytesWithHeader = EmbeddedGldfTestData.GetGldfWithFiles();
            File.WriteAllBytes(_tempFile, gldfBytesWithHeader);

            var archive = _gldfContainer.ReadFromFile(_tempFile, settings);

            archive.Assets.All.Should().OnlyContain(f => !string.IsNullOrWhiteSpace(f.FileName));
            archive.Assets.All.Should().NotContain(f => f.Bytes.Length > 0);
        }

        [Test]
        public void ReadFromFile_WithSkipSignatureSetting_ShouldReturn_EmptySignature()
        {
            var settings = new ContainerLoadSettings(SignatureLoadBehaviour.Skip);
            var gldfBytesWithHeader = EmbeddedGldfTestData.GetGldfWithSignature();
            File.WriteAllBytes(_tempFile, gldfBytesWithHeader);

            var archive = _gldfContainer.ReadFromFile(_tempFile, settings);

            archive.Signature.Should().BeEmpty();
        }

        [Test]
        public void ReadFromFile_Should_HaveNoAssets_WhenMissingInContainer()
        {
            var gldfBytes = EmbeddedGldfTestData.GetGldfNoFiles();
            File.WriteAllBytes(_tempFile, gldfBytes);

            var archive = _gldfContainer.ReadFromFile(_tempFile);

            archive.Assets.All.Should().BeEmpty();
        }

        [Test]
        public void ReadFromFile_Should_ReturnEmptySignature_WhenMissingInContainer()
        {
            var gldfBytes = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
            File.WriteAllBytes(_tempFile, gldfBytes);

            var archive = _gldfContainer.ReadFromFile(_tempFile);

            archive.Signature.Should().BeEmpty();
            archive.Signature.Should().NotBeNull();
        }

        [Test]
        public void ReadFromFile_Should_ReadAndDeserialize_Signature()
        {
            var gldfBytes = EmbeddedGldfTestData.GetGldfWithSignature();
            File.WriteAllBytes(_tempFile, gldfBytes);

            var archive = _gldfContainer.ReadFromFile(_tempFile);

            archive.Signature.Should().Contain("signature");
        }

        [Test]
        public void ReadFromFile_Should_ReadAndDeserialize_Assets()
        {
            var gldfBytes = EmbeddedGldfTestData.GetGldfWithFiles();
            File.WriteAllBytes(_tempFile, gldfBytes);

            var archive = _gldfContainer.ReadFromFile(_tempFile);

            archive.Assets.All.Should().HaveCount(11);
            archive.Assets.Geometries.Should().ContainEquivalentOf(new ContainerFile("geometry.l3d", new byte[1]));
            archive.Assets.Geometries.Should().ContainEquivalentOf(new ContainerFile("geometry.r3d", new byte[2]));
            archive.Assets.Images.Should().ContainEquivalentOf(new ContainerFile("image.jpg", new byte[3]));
            archive.Assets.Images.Should().ContainEquivalentOf(new ContainerFile("image.png", new byte[4]));
            archive.Assets.Photometries.Should().ContainEquivalentOf(new ContainerFile("lvk.ldt", new byte[5]));
            archive.Assets.Photometries.Should().ContainEquivalentOf(new ContainerFile("lvk.ies", new byte[6]));
            archive.Assets.Documents.Should().ContainEquivalentOf(new ContainerFile("document.docx", new byte[7]));
            archive.Assets.Sensors.Should().ContainEquivalentOf(new ContainerFile("sensor.xml", new byte[8]));
            archive.Assets.Spectrums.Should().ContainEquivalentOf(new ContainerFile("spectrum.txt", new byte[9]));
            archive.Assets.Symbols.Should().ContainEquivalentOf(new ContainerFile("symbol.svg", new byte[10]));
            archive.Assets.Other.Should().ContainEquivalentOf(new ContainerFile("project.c4d", new byte[11]));
        }

        [Test]
        public void ReadFromFile_Should_Ignore_UnknownFiles()
        {
            var gldfBytes = EmbeddedGldfTestData.GetGldfWithFiles();
            File.WriteAllBytes(_tempFile, gldfBytes);

            var archive = _gldfContainer.ReadFromFile(_tempFile);

            archive.Assets.All.Should().NotContain(file => file.FileName == "other.txt");
            archive.Assets.All.Should().NotContainNulls();
        }
    }
}