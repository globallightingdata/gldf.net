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
        private GldfContainerReader _gldfContainerReader;
        private string _tempFile;

        [SetUp]
        public void SetUp()
        {
            _gldfContainerReader = new GldfContainerReader();
            _tempFile = Path.GetTempFileName();
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(_tempFile);
        }

        [Test]
        public void ReadFromFile_ShouldThrow_When_FilePathParameter_IsNull()
        {
            Action act = () => _gldfContainerReader.ReadFromFile(null);

            act.Should()
                .Throw<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'filePath')");
        }

        [Test]
        public void ReadFromFile_ShouldThrow_When_SettingsParameter_IsNull()
        {
            Action act = () => _gldfContainerReader.ReadFromFile("", null);

            act.Should()
                .Throw<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'settings')");
        }

        [Test]
        public void ReadFromFile_EmptyContainer_ShouldThrow_When_Missing_ProductXml()
        {
            ZipFile.Open(_tempFile, ZipArchiveMode.Update).Dispose();

            Action act = () => _gldfContainerReader.ReadFromFile(_tempFile);

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

            Action act = () => _gldfContainerReader.ReadFromFile(_tempFile);

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

            var container = _gldfContainerReader.ReadFromFile(_tempFile);

            container.Product.Should().BeEquivalentTo(expectedModel);
        }

        [Test]
        public void ReadFromFile_WithSkipProductSetting_Should_SkipRoot()
        {
            var settings = new ContainerLoadSettings(ProductLoadBehaviour.Skip);
            var gldfBytesWithHeader = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
            var expectedEmptyRoot = new Root();
            File.WriteAllBytes(_tempFile, gldfBytesWithHeader);

            var container = _gldfContainerReader.ReadFromFile(_tempFile, settings);

            container.Product.Should().BeEquivalentTo(expectedEmptyRoot);
        }

        [Test]
        public void ReadFromFile_WithSkipFilesSetting_ShouldReturn_EmptyAssets()
        {
            var settings = new ContainerLoadSettings(AssetLoadBehaviour.Skip);
            var gldfBytesWithHeader = EmbeddedGldfTestData.GetGldfWithFiles();
            File.WriteAllBytes(_tempFile, gldfBytesWithHeader);

            var container = _gldfContainerReader.ReadFromFile(_tempFile, settings);

            container.Assets.All.Should().BeEmpty();
        }

        [Test]
        public void ReadFromFile_WithFilesNamesOnlySetting_ShouldReturn_AssetsWithoutContent()
        {
            var settings = new ContainerLoadSettings(AssetLoadBehaviour.FileNamesOnly);
            var gldfBytesWithHeader = EmbeddedGldfTestData.GetGldfWithFiles();
            File.WriteAllBytes(_tempFile, gldfBytesWithHeader);

            var container = _gldfContainerReader.ReadFromFile(_tempFile, settings);

            container.Assets.All.Should().OnlyContain(f => !string.IsNullOrWhiteSpace(f.FileName));
            container.Assets.All.Should().NotContain(f => f.Bytes.Length > 0);
        }

        [Test]
        public void ReadFromFile_WithSkipSignatureSetting_ShouldReturn_EmptySignature()
        {
            var settings = new ContainerLoadSettings(SignatureLoadBehaviour.Skip);
            var gldfBytesWithHeader = EmbeddedGldfTestData.GetGldfWithSignature();
            File.WriteAllBytes(_tempFile, gldfBytesWithHeader);

            var container = _gldfContainerReader.ReadFromFile(_tempFile, settings);

            container.Signature.Should().BeEmpty();
        }

        [Test]
        public void ReadFromFile_Should_HaveNoAssets_WhenMissingInContainer()
        {
            var gldfBytes = EmbeddedGldfTestData.GetGldfNoFiles();
            File.WriteAllBytes(_tempFile, gldfBytes);

            var container = _gldfContainerReader.ReadFromFile(_tempFile);

            container.Assets.All.Should().BeEmpty();
        }

        [Test]
        public void ReadFromFile_Should_ReturnEmptySignature_WhenMissingInContainer()
        {
            var gldfBytes = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
            File.WriteAllBytes(_tempFile, gldfBytes);

            var container = _gldfContainerReader.ReadFromFile(_tempFile);

            container.Signature.Should().BeEmpty();
            container.Signature.Should().NotBeNull();
        }

        [Test]
        public void ReadFromFile_Should_ReadAndDeserialize_Signature()
        {
            var gldfBytes = EmbeddedGldfTestData.GetGldfWithSignature();
            File.WriteAllBytes(_tempFile, gldfBytes);

            var container = _gldfContainerReader.ReadFromFile(_tempFile);

            container.Signature.Should().Contain("signature");
        }

        [Test]
        public void ReadFromFile_Should_ReadAndDeserialize_Assets()
        {
            var gldfBytes = EmbeddedGldfTestData.GetGldfWithFiles();
            File.WriteAllBytes(_tempFile, gldfBytes);

            var container = _gldfContainerReader.ReadFromFile(_tempFile);

            container.Assets.All.Should().HaveCount(11);
            container.Assets.Geometries.Should().ContainEquivalentOf(new ContainerFile("geometry.l3d", new byte[1]));
            container.Assets.Geometries.Should().ContainEquivalentOf(new ContainerFile("geometry.r3d", new byte[2]));
            container.Assets.Images.Should().ContainEquivalentOf(new ContainerFile("image.jpg", new byte[3]));
            container.Assets.Images.Should().ContainEquivalentOf(new ContainerFile("image.png", new byte[4]));
            container.Assets.Photometries.Should().ContainEquivalentOf(new ContainerFile("lvk.ldt", new byte[5]));
            container.Assets.Photometries.Should().ContainEquivalentOf(new ContainerFile("lvk.ies", new byte[6]));
            container.Assets.Documents.Should().ContainEquivalentOf(new ContainerFile("document.docx", new byte[7]));
            container.Assets.Sensors.Should().ContainEquivalentOf(new ContainerFile("sensor.xml", new byte[8]));
            container.Assets.Spectrums.Should().ContainEquivalentOf(new ContainerFile("spectrum.txt", new byte[9]));
            container.Assets.Symbols.Should().ContainEquivalentOf(new ContainerFile("symbol.svg", new byte[10]));
            container.Assets.Other.Should().ContainEquivalentOf(new ContainerFile("project.c4d", new byte[11]));
        }

        [Test]
        public void ReadFromFile_Should_Ignore_UnknownFiles()
        {
            var gldfBytes = EmbeddedGldfTestData.GetGldfWithFiles();
            File.WriteAllBytes(_tempFile, gldfBytes);

            var container = _gldfContainerReader.ReadFromFile(_tempFile);

            container.Assets.All.Should().NotContain(file => file.FileName == "other.txt");
            container.Assets.All.Should().NotContainNulls();
        }
    }
}