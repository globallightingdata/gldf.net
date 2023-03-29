using FluentAssertions;
using Gldf.Net.Container;
using Gldf.Net.Domain.Xml;
using Gldf.Net.Exceptions;
using Gldf.Net.Tests.TestData;
using NUnit.Framework;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace Gldf.Net.Tests.ContainerTests
{
    [TestFixture]
    public class ZipArchiveReaderTests
    {
        private ZipArchiveReader _zipArchiveReader;
        private string _tempFile;

        [SetUp]
        public void SetUp()
        {
            _zipArchiveReader = new ZipArchiveReader();
            _tempFile = Path.GetTempFileName();
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(_tempFile);
        }

        [Test]
        public void ReadContainer_EmptyContainer_ShouldThrow_BecauseOf_Missing_ProductXml()
        {
            ZipFile.Open(_tempFile, ZipArchiveMode.Update).Dispose();

            Action act = () => _zipArchiveReader.ReadContainer(_tempFile);

            act.Should()
                .Throw<RootNotFoundException>()
                .WithMessage($"Required product.xml not found in root of {nameof(GldfContainer)}");
        }

        [Test]
        public void ReadContainer_InvalidContainer_ShouldThrow_InvalidDataException()
        {
            File.WriteAllBytes(_tempFile, new byte[10]);

            Action act = () => _zipArchiveReader.ReadContainer(_tempFile);

            act.Should().ThrowExactly<InvalidDataException>();
        }

        [Test]
        public void ReadContainer_Should_ReadAndDeserialize_ProductXml()
        {
            var expectedModel = EmbeddedXmlTestData.GetHeaderMandatoryModel();
            var gldfBytes = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
            File.WriteAllBytes(_tempFile, gldfBytes);

            var container = _zipArchiveReader.ReadContainer(_tempFile);

            container.Product.Should().BeEquivalentTo(expectedModel);
        }

        [Test]
        public void ReadContainer_WithSkipProductSetting_Should_SkipRoot()
        {
            var settings = new ContainerLoadSettings(ProductLoadBehaviour.Skip);
            var gldfBytesWithHeader = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
            var expectedEmptyRoot = new Root();
            File.WriteAllBytes(_tempFile, gldfBytesWithHeader);

            var container = _zipArchiveReader.ReadContainer(_tempFile, settings);

            container.Product.Should().BeEquivalentTo(expectedEmptyRoot);
        }

        [Test]
        public void ReadContainer_WithSkipFilesSetting_ShouldReturn_EmptyAssets()
        {
            var settings = new ContainerLoadSettings(AssetLoadBehaviour.Skip);
            var gldfBytesWithHeader = EmbeddedGldfTestData.GetGldfWithFiles();
            File.WriteAllBytes(_tempFile, gldfBytesWithHeader);

            var container = _zipArchiveReader.ReadContainer(_tempFile, settings);

            container.Assets.All.Should().BeEmpty();
        }

        [Test]
        public void ReadContainer_WithFilesNamesOnlySetting_ShouldReturn_AssetsWithoutContent()
        {
            var settings = new ContainerLoadSettings(AssetLoadBehaviour.FileNamesOnly);
            var gldfBytesWithHeader = EmbeddedGldfTestData.GetGldfWithFiles();
            File.WriteAllBytes(_tempFile, gldfBytesWithHeader);

            var container = _zipArchiveReader.ReadContainer(_tempFile, settings);

            container.Assets.All.Should().OnlyContain(f => !string.IsNullOrWhiteSpace(f.FileName));
            container.Assets.All.Should().NotContain(f => f.Bytes.Length > 0);
        }

        [Test]
        public void ReadContainer_WithSkipSignatureSetting_ShouldReturn_EmptySignature()
        {
            var settings = new ContainerLoadSettings(SignatureLoadBehaviour.Skip);
            var gldfBytesWithHeader = EmbeddedGldfTestData.GetGldfWithSignature();
            File.WriteAllBytes(_tempFile, gldfBytesWithHeader);

            var container = _zipArchiveReader.ReadContainer(_tempFile, settings);

            container.MetaInformation.Should().BeNull();
        }

        [Test]
        public void ReadContainer_Should_HaveNoAssets_WhenMissingInContainer()
        {
            var gldfBytes = EmbeddedGldfTestData.GetGldfNoFiles();
            File.WriteAllBytes(_tempFile, gldfBytes);

            var container = _zipArchiveReader.ReadContainer(_tempFile);

            container.Assets.All.Should().BeEmpty();
        }

        [Test]
        public void ReadContainer_Should_ReturnEmptySignature_WhenMissingInContainer()
        {
            var gldfBytes = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
            File.WriteAllBytes(_tempFile, gldfBytes);

            var container = _zipArchiveReader.ReadContainer(_tempFile);

            container.MetaInformation.Should().BeNull();
        }

        [Test]
        public void ReadContainer_Should_ReadAndDeserialize_Signature()
        {
            var gldfBytes = EmbeddedGldfTestData.GetGldfWithSignature();
            var metaInformation = EmbeddedGldfTestData.ExpectedMetaInformation;
            
            File.WriteAllBytes(_tempFile, gldfBytes);
            var container = _zipArchiveReader.ReadContainer(_tempFile);

            container.MetaInformation.Should().BeEquivalentTo(metaInformation);
        }

        [Test]
        public void ReadContainer_Should_ReadAndDeserialize_Assets()
        {
            var gldfBytes = EmbeddedGldfTestData.GetGldfWithFiles();
            File.WriteAllBytes(_tempFile, gldfBytes);

            var container = _zipArchiveReader.ReadContainer(_tempFile);

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
        public void ReadContainer_Should_Ignore_UnknownFiles()
        {
            var gldfBytes = EmbeddedGldfTestData.GetGldfWithFiles();
            File.WriteAllBytes(_tempFile, gldfBytes);

            var container = _zipArchiveReader.ReadContainer(_tempFile);

            container.Assets.All.Should().NotContain(file => file.FileName == "other.txt");
            container.Assets.All.Should().NotContainNulls();
        }

        [Test]
        public void ReadRootXml_ShouldReturn_ExpectedXml()
        {
            var gldfBytes = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
            File.WriteAllBytes(_tempFile, gldfBytes);
            using var zipFile = ZipFile.OpenRead(_tempFile);
            using var entryStream = zipFile.GetEntry("product.xml")!.Open();
            using var streamReader = new StreamReader(entryStream, Encoding.UTF8);
            var expectedXml = streamReader.ReadToEnd();

            var rootXml = _zipArchiveReader.ReadRootXml(_tempFile);

            rootXml.Should().BeEquivalentTo(expectedXml);
        }

        [Test]
        public void IsZipArchive_ShouldReturn_True_When_ValidZipArchive()
        {
            var gldfBytes = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
            File.WriteAllBytes(_tempFile, gldfBytes);

            var isZipArchive = _zipArchiveReader.IsZipArchive(_tempFile);

            isZipArchive.Should().BeTrue();
        }

        [Test]
        public void IsZipArchive_Should_NotThrow_When_InvalidZipArchive()
        {
            File.WriteAllBytes(_tempFile, new byte[1]);

            Action act = () => _zipArchiveReader.IsZipArchive(_tempFile);

            act.Should().NotThrow();
        }

        [Test]
        public void IsZipArchive_Should_Return_False_When_InvalidZipArchive()
        {
            File.WriteAllBytes(_tempFile, new byte[1]);

            var isZipArchive = _zipArchiveReader.IsZipArchive(_tempFile);

            isZipArchive.Should().BeFalse();
        }

        [Test]
        public void ContainsRootXml_ShouldReturn_True_When_ZipArchive_ContainsProductXml()
        {
            var gldfBytes = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
            File.WriteAllBytes(_tempFile, gldfBytes);

            var containsRootXml = _zipArchiveReader.ContainsRootXml(_tempFile);

            containsRootXml.Should().BeTrue();
        }

        [Test]
        public void ContainsRootXml_ShouldReturn_False_When_ZipArchive_HasNoProductXml()
        {
            ZipFile.Open(_tempFile, ZipArchiveMode.Update).Dispose();

            var containsRootXml = _zipArchiveReader.ContainsRootXml(_tempFile);

            containsRootXml.Should().BeFalse();
        }

        [Test]
        public void ContainsRootXml_ShouldThrow_When_ZipArchiveIsInvalid()
        {
            File.WriteAllBytes(_tempFile, new byte[1]);

            Action act = () => _zipArchiveReader.ContainsRootXml(_tempFile);

            act.Should().ThrowExactly<InvalidDataException>();
        }

        [Test]
        public void GetLargeFileNames_ShouldReturn_Expected5MbFile()
        {
            var gldfWithLargeFiles = EmbeddedGldfTestData.GetGldfWithLargeFiles();
            File.WriteAllBytes(_tempFile, gldfWithLargeFiles);

            var largeFileNames = _zipArchiveReader.GetLargeFileNames(_tempFile, 5 * 1024 * 1024).ToList();

            largeFileNames.Should().Contain("doc/5MbTextFile.txt");
            largeFileNames.Should().NotContain("doc/4MbTextFile.txt");
        }

        [Test]
        public void GetLargeFileNames_ShouldThrow_WhenInvalidZipFile()
        {
            File.WriteAllBytes(_tempFile, new byte[1]);

            Action act = () => _zipArchiveReader.GetLargeFileNames(_tempFile, 1);

            act.Should().ThrowExactly<InvalidDataException>();
        }

        [Test]
        public void ExtractToDirectory_ShouldExtract_ExpectedContent()
        {
            var tempSubDirectory = Path.Combine(Path.GetTempPath(), $"gldf-{DateTime.Now.Ticks}");
            var gldfWithFiles = EmbeddedGldfTestData.GetGldfWithFiles();
            var expectedDirectoryFilePaths = EmbeddedGldfTestData.ExpectedDirectoryFilePaths;
            File.WriteAllBytes(_tempFile, gldfWithFiles);

            _zipArchiveReader.ExtractToDirectory(_tempFile, tempSubDirectory);
            var options = new EnumerationOptions { RecurseSubdirectories = true };
            var filesInsideDirectory = Directory.EnumerateFiles(tempSubDirectory, "*.*", options).ToList();
            Directory.Delete(tempSubDirectory, true);

            filesInsideDirectory.Should().HaveCount(12);
            expectedDirectoryFilePaths.ForEach(e => filesInsideDirectory.Should().ContainMatch(e));
        }
    }
}