using FluentAssertions;
using Gldf.Net.Container;
using Gldf.Net.Domain;
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
        public void ReadArchive_EmptyContainer_ShouldThrow_BecauseOf_Missing_ProductXml()
        {
            ZipFile.Open(_tempFile, ZipArchiveMode.Update).Dispose();

            Action act = () => _zipArchiveReader.ReadArchive(_tempFile);

            act.Should()
                .Throw<RootNotFoundException>()
                .WithMessage($"Required product.xml not found in root of {nameof(GldfContainer)}");
        }

        [Test]
        public void ReadArchive_InvalidContainer_ShouldThrow_InvalidDataException()
        {
            File.WriteAllBytes(_tempFile, new byte[10]);

            Action act = () => _zipArchiveReader.ReadArchive(_tempFile);

            act.Should().ThrowExactly<InvalidDataException>();
        }

        [Test]
        public void ReadArchive_Should_ReadAndDeserialize_ProductXml()
        {
            var expectedModel = EmbeddedXmlTestData.GetHeaderMandatoryModel();
            var gldfBytes = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
            File.WriteAllBytes(_tempFile, gldfBytes);

            var archive = _zipArchiveReader.ReadArchive(_tempFile);

            archive.Product.Should().BeEquivalentTo(expectedModel);
        }

        [Test]
        public void ReadArchive_WithSkipProductSetting_Should_SkipRoot()
        {
            var settings = new ContainerLoadSettings(ProductLoadBehaviour.Skip);
            var gldfBytesWithHeader = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
            var expectedEmptyRoot = new Root();
            File.WriteAllBytes(_tempFile, gldfBytesWithHeader);

            var archive = _zipArchiveReader.ReadArchive(_tempFile, settings);

            archive.Product.Should().BeEquivalentTo(expectedEmptyRoot);
        }

        [Test]
        public void ReadArchive_WithSkipFilesSetting_ShouldReturn_EmptyAssets()
        {
            var settings = new ContainerLoadSettings(AssetLoadBehaviour.Skip);
            var gldfBytesWithHeader = EmbeddedGldfTestData.GetGldfWithFiles();
            File.WriteAllBytes(_tempFile, gldfBytesWithHeader);

            var archive = _zipArchiveReader.ReadArchive(_tempFile, settings);

            archive.Assets.All.Should().BeEmpty();
        }

        [Test]
        public void ReadArchive_WithFilesNamesOnlySetting_ShouldReturn_AssetsWithoutContent()
        {
            var settings = new ContainerLoadSettings(AssetLoadBehaviour.FileNamesOnly);
            var gldfBytesWithHeader = EmbeddedGldfTestData.GetGldfWithFiles();
            File.WriteAllBytes(_tempFile, gldfBytesWithHeader);

            var archive = _zipArchiveReader.ReadArchive(_tempFile, settings);

            archive.Assets.All.Should().OnlyContain(f => !string.IsNullOrWhiteSpace(f.FileName));
            archive.Assets.All.Should().NotContain(f => f.Bytes.Length > 0);
        }

        [Test]
        public void ReadArchive_WithSkipSignatureSetting_ShouldReturn_EmptySignature()
        {
            var settings = new ContainerLoadSettings(SignatureLoadBehaviour.Skip);
            var gldfBytesWithHeader = EmbeddedGldfTestData.GetGldfWithSignature();
            File.WriteAllBytes(_tempFile, gldfBytesWithHeader);

            var archive = _zipArchiveReader.ReadArchive(_tempFile, settings);

            archive.Signature.Should().BeEmpty();
        }

        [Test]
        public void ReadArchive_Should_HaveNoAssets_WhenMissingInContainer()
        {
            var gldfBytes = EmbeddedGldfTestData.GetGldfNoFiles();
            File.WriteAllBytes(_tempFile, gldfBytes);

            var archive = _zipArchiveReader.ReadArchive(_tempFile);

            archive.Assets.All.Should().BeEmpty();
        }

        [Test]
        public void ReadArchive_Should_ReturnEmptySignature_WhenMissingInContainer()
        {
            var gldfBytes = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
            File.WriteAllBytes(_tempFile, gldfBytes);

            var archive = _zipArchiveReader.ReadArchive(_tempFile);

            archive.Signature.Should().BeEmpty();
            archive.Signature.Should().NotBeNull();
        }

        [Test]
        public void ReadArchive_Should_ReadAndDeserialize_Signature()
        {
            var gldfBytes = EmbeddedGldfTestData.GetGldfWithSignature();
            File.WriteAllBytes(_tempFile, gldfBytes);

            var archive = _zipArchiveReader.ReadArchive(_tempFile);

            archive.Signature.Should().Contain("signature");
        }

        [Test]
        public void ReadArchive_Should_ReadAndDeserialize_Assets()
        {
            var gldfBytes = EmbeddedGldfTestData.GetGldfWithFiles();
            File.WriteAllBytes(_tempFile, gldfBytes);

            var archive = _zipArchiveReader.ReadArchive(_tempFile);

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
        public void ReadArchive_Should_Ignore_UnknownFiles()
        {
            var gldfBytes = EmbeddedGldfTestData.GetGldfWithFiles();
            File.WriteAllBytes(_tempFile, gldfBytes);

            var archive = _zipArchiveReader.ReadArchive(_tempFile);

            archive.Assets.All.Should().NotContain(file => file.FileName == "other.txt");
            archive.Assets.All.Should().NotContainNulls();
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
    }
}