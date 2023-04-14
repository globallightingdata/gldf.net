using FluentAssertions;
using Gldf.Net.Container;
using Gldf.Net.Exceptions;
using Gldf.Net.Tests.TestData;
using NUnit.Framework;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace Gldf.Net.Tests.ContainerTests;

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
        ZipFile.Open(_tempFile, ZipArchiveMode.Update).Dispose();
    }

    [TearDown]
    public void TearDown()
    {
        File.Delete(_tempFile);
    }

    [Test]
    public void ReadContainerFile_EmptyContainer_ShouldReturnNull()
    {
        var gldfContainer = _zipArchiveReader.ReadContainer(_tempFile);
        gldfContainer.Product.Should().BeNull();
    }

    [Test]
    public void ReadContainerStream_EmptyContainer_ShouldReturnNull()
    {
        using var fileStream = new FileStream(_tempFile, FileMode.Open);
        var gldfContainer = _zipArchiveReader.ReadContainer(fileStream, false);

        gldfContainer.Product.Should().BeNull();
    }

    [Test]
    public void ReadContainerFile_InvalidContainer_ShouldThrow_InvalidDataException()
    {
        File.WriteAllBytes(_tempFile, new byte[10]);

        Action act = () => _zipArchiveReader.ReadContainer(_tempFile);

        act.Should().ThrowExactly<InvalidDataException>();
    }

    [Test]
    public void ReadContainerStream_InvalidContainer_ShouldThrow_InvalidDataException()
    {
        File.WriteAllBytes(_tempFile, new byte[10]);

        var act = () =>
        {
            using var fileStream = new FileStream(_tempFile, FileMode.Open);
            _zipArchiveReader.ReadContainer(fileStream, false);
        };

        act.Should().ThrowExactly<InvalidDataException>();
    }

    [Test]
    public void ReadContainerFile_Should_ReadAndDeserialize_ProductXml()
    {
        var expectedModel = EmbeddedXmlTestData.GetHeaderMandatoryModel();
        var gldfBytes = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
        File.WriteAllBytes(_tempFile, gldfBytes);

        var container = _zipArchiveReader.ReadContainer(_tempFile);

        container.Product.Should().BeEquivalentTo(expectedModel);
    }

    [Test]
    public void ReadContainerStream_Should_ReadAndDeserialize_ProductXml()
    {
        var expectedModel = EmbeddedXmlTestData.GetHeaderMandatoryModel();
        var gldfBytes = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
        using var memoryStream = new MemoryStream(gldfBytes);

        var container = _zipArchiveReader.ReadContainer(memoryStream, false);

        container.Product.Should().BeEquivalentTo(expectedModel);
    }

    [Test]
    public void ReadContainerFile_WithSkipProductSetting_Should_SkipRoot()
    {
        var settings = new ContainerLoadSettings(ProductLoadBehaviour.Skip);
        var gldfBytesWithHeader = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
        File.WriteAllBytes(_tempFile, gldfBytesWithHeader);

        var container = _zipArchiveReader.ReadContainer(_tempFile, settings);

        container.Product.Should().BeNull();
    }

    [Test]
    public void ReadContainerStream_WithSkipProductSetting_Should_SkipRoot()
    {
        var settings = new ContainerLoadSettings(ProductLoadBehaviour.Skip);
        var gldfBytesWithHeader = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
        using var memoryStream = new MemoryStream(gldfBytesWithHeader);

        var container = _zipArchiveReader.ReadContainer(memoryStream, false, settings);

        container.Product.Should().BeNull();
    }

    [Test]
    public void ReadContainerFile_WithSkipFilesSetting_ShouldReturn_EmptyAssets()
    {
        var settings = new ContainerLoadSettings(AssetLoadBehaviour.Skip);
        var gldfBytesWithHeader = EmbeddedGldfTestData.GetGldfWithFiles();
        File.WriteAllBytes(_tempFile, gldfBytesWithHeader);

        var container = _zipArchiveReader.ReadContainer(_tempFile, settings);

        container.Assets.All.Should().BeEmpty();
    }

    [Test]
    public void ReadContainerStream_WithSkipFilesSetting_ShouldReturn_EmptyAssets()
    {
        var settings = new ContainerLoadSettings(AssetLoadBehaviour.Skip);
        var gldfBytesWithHeader = EmbeddedGldfTestData.GetGldfWithFiles();
        using var memoryStream = new MemoryStream(gldfBytesWithHeader);

        var container = _zipArchiveReader.ReadContainer(memoryStream, false, settings);

        container.Assets.All.Should().BeEmpty();
    }

    [Test]
    public void ReadContainerFile_WithFilesNamesOnlySetting_ShouldReturn_AssetsWithoutContent()
    {
        var settings = new ContainerLoadSettings(AssetLoadBehaviour.FileNamesOnly);
        var gldfBytesWithHeader = EmbeddedGldfTestData.GetGldfWithFiles();
        File.WriteAllBytes(_tempFile, gldfBytesWithHeader);

        var container = _zipArchiveReader.ReadContainer(_tempFile, settings);

        container.Assets.All.Should().OnlyContain(f => !string.IsNullOrWhiteSpace(f.FileName));
        container.Assets.All.Should().NotContain(f => f.Bytes.Length > 0);
    }

    [Test]
    public void ReadContainerStream_WithFilesNamesOnlySetting_ShouldReturn_AssetsWithoutContent()
    {
        var settings = new ContainerLoadSettings(AssetLoadBehaviour.FileNamesOnly);
        var gldfBytesWithHeader = EmbeddedGldfTestData.GetGldfWithFiles();
        using var memoryStream = new MemoryStream(gldfBytesWithHeader);

        var container = _zipArchiveReader.ReadContainer(memoryStream, false, settings);

        container.Assets.All.Should().OnlyContain(f => !string.IsNullOrWhiteSpace(f.FileName));
        container.Assets.All.Should().NotContain(f => f.Bytes.Length > 0);
    }

    [Test]
    public void ReadContainerFile_WithSkipMetaInfoSetting_ShouldReturn_Null()
    {
        var settings = new ContainerLoadSettings(MetaInfoLoadBehaviour.Skip);
        var gldfBytesWithHeader = EmbeddedGldfTestData.GetGldfWithMetaInfo();
        File.WriteAllBytes(_tempFile, gldfBytesWithHeader);

        var container = _zipArchiveReader.ReadContainer(_tempFile, settings);

        container.MetaInformation.Should().BeNull();
    }

    [Test]
    public void ReadContainerStream_WithSkipMetaInfoSetting_ShouldReturn_Null()
    {
        var settings = new ContainerLoadSettings(MetaInfoLoadBehaviour.Skip);
        var gldfBytesWithHeader = EmbeddedGldfTestData.GetGldfWithMetaInfo();
        using var memoryStream = new MemoryStream(gldfBytesWithHeader);

        var container = _zipArchiveReader.ReadContainer(memoryStream, false, settings);

        container.MetaInformation.Should().BeNull();
    }

    [Test]
    public void ReadContainerFile_Should_HaveNoAssets_WhenMissingInContainer()
    {
        var gldfBytes = EmbeddedGldfTestData.GetGldfNoFiles();
        File.WriteAllBytes(_tempFile, gldfBytes);

        var container = _zipArchiveReader.ReadContainer(_tempFile);

        container.Assets.All.Should().BeEmpty();
    }

    [Test]
    public void ReadContainerStream_Should_HaveNoAssets_WhenMissingInContainer()
    {
        var gldfBytes = EmbeddedGldfTestData.GetGldfNoFiles();
        using var memoryStream = new MemoryStream(gldfBytes);

        var container = _zipArchiveReader.ReadContainer(memoryStream, false);

        container.Assets.All.Should().BeEmpty();
    }

    [Test]
    public void ReadContainerFile_Should_ReturnEmptyMetaInfo_WhenMissingInContainer()
    {
        var gldfBytes = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
        File.WriteAllBytes(_tempFile, gldfBytes);

        var container = _zipArchiveReader.ReadContainer(_tempFile);

        container.MetaInformation.Should().BeNull();
    }

    [Test]
    public void ReadContainerStream_Should_ReturnEmptyMetaInfo_WhenMissingInContainer()
    {
        var gldfBytes = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
        using var memoryStream = new MemoryStream(gldfBytes);

        var container = _zipArchiveReader.ReadContainer(memoryStream, false);

        container.MetaInformation.Should().BeNull();
    }

    [Test]
    public void ReadContainerFile_Should_ReadAndDeserialize_MetaInfo()
    {
        var gldfBytes = EmbeddedGldfTestData.GetGldfWithMetaInfo();
        var metaInformation = EmbeddedGldfTestData.ExpectedMetaInformation;

        File.WriteAllBytes(_tempFile, gldfBytes);
        var container = _zipArchiveReader.ReadContainer(_tempFile);

        container.MetaInformation.Should().BeEquivalentTo(metaInformation);
    }

    [Test]
    public void ReadContainerFileStream_Should_ReadAndDeserialize_MetaInfo()
    {
        var gldfBytes = EmbeddedGldfTestData.GetGldfWithMetaInfo();
        var metaInformation = EmbeddedGldfTestData.ExpectedMetaInformation;
        using var memoryStream = new MemoryStream(gldfBytes);

        var container = _zipArchiveReader.ReadContainer(memoryStream, false);

        container.MetaInformation.Should().BeEquivalentTo(metaInformation);
    }

    [Test]
    public void ReadContainerFile_Should_ReadAndDeserialize_Assets()
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
    public void ReadContainerStream_Should_ReadAndDeserialize_Assets()
    {
        var gldfBytes = EmbeddedGldfTestData.GetGldfWithFiles();
        using var memoryStream = new MemoryStream(gldfBytes);

        var container = _zipArchiveReader.ReadContainer(memoryStream, false);

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
    public void ReadContainerFile_Should_Ignore_UnknownFiles()
    {
        var gldfBytes = EmbeddedGldfTestData.GetGldfWithFiles();
        File.WriteAllBytes(_tempFile, gldfBytes);

        var container = _zipArchiveReader.ReadContainer(_tempFile);

        container.Assets.All.Should().NotContain(file => file.FileName == "other.txt");
        container.Assets.All.Should().NotContainNulls();
    }

    [Test]
    public void ReadContainerStream_Should_Ignore_UnknownFiles()
    {
        var gldfBytes = EmbeddedGldfTestData.GetGldfWithFiles();
        using var memoryStream = new MemoryStream(gldfBytes);

        var container = _zipArchiveReader.ReadContainer(memoryStream, false);

        container.Assets.All.Should().NotContain(file => file.FileName == "other.txt");
        container.Assets.All.Should().NotContainNulls();
    }

    [Test]
    public void ReadRootXmlFile_ShouldReturn_ExpectedXml()
    {
        var gldfBytes = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
        File.WriteAllBytes(_tempFile, gldfBytes);
        using var zipFile = ZipFile.OpenRead(_tempFile);
        using var entryStream = zipFile.GetEntry(GldfStaticNames.Files.Product)!.Open();
        using var streamReader = new StreamReader(entryStream, Encoding.UTF8);
        var expectedXml = streamReader.ReadToEnd();

        var rootXml = _zipArchiveReader.ReadRootXml(_tempFile);

        rootXml.Should().BeEquivalentTo(expectedXml);
    }

    [Test]
    public void ReadRootXmlStream_ShouldReturn_ExpectedXml()
    {
        var gldfBytes = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
        File.WriteAllBytes(_tempFile, gldfBytes);
        using var zipFile = ZipFile.OpenRead(_tempFile);
        using var entryStream = zipFile.GetEntry(GldfStaticNames.Files.Product)!.Open();
        using var streamReader = new StreamReader(entryStream, Encoding.UTF8);
        var expectedXml = streamReader.ReadToEnd();
        using var memoryStream = new MemoryStream(gldfBytes);

        var rootXml = _zipArchiveReader.ReadRootXml(memoryStream, false);

        rootXml.Should().BeEquivalentTo(expectedXml);
    }

    [Test]
    public void IsZipArchiveFile_ShouldReturn_True_When_ValidZipArchive()
    {
        var gldfBytes = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
        File.WriteAllBytes(_tempFile, gldfBytes);

        var isZipArchive = ZipArchiveReader.IsZipArchive(_tempFile);

        isZipArchive.Should().BeTrue();
    }

    [Test]
    public void IsZipArchiveStream_ShouldReturn_True_When_ValidZipArchive()
    {
        var gldfBytes = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
        using var memoryStream = new MemoryStream(gldfBytes);

        var isZipArchive = ZipArchiveReader.IsZipArchive(memoryStream, false);

        isZipArchive.Should().BeTrue();
    }

    [Test]
    public void IsZipArchiveFile_Should_NotThrow_When_InvalidZipArchive()
    {
        File.WriteAllBytes(_tempFile, new byte[1]);

        Action act = () => ZipArchiveReader.IsZipArchive(_tempFile);

        act.Should().NotThrow();
    }

    [Test]
    public void IsZipArchiveStream_Should_NotThrow_When_InvalidZipArchive()
    {
        Action act = () => ZipArchiveReader.IsZipArchive(Stream.Null, false);

        act.Should().NotThrow();
    }

    [Test]
    public void IsZipArchiveFile_Should_Return_False_When_InvalidZipArchive()
    {
        File.WriteAllBytes(_tempFile, new byte[1]);

        var isZipArchive = ZipArchiveReader.IsZipArchive(_tempFile);

        isZipArchive.Should().BeFalse();
    }

    [Test]
    public void IsZipArchiveStream_Should_Return_False_When_InvalidZipArchive()
    {
        var isZipArchive = ZipArchiveReader.IsZipArchive(Stream.Null, false);

        isZipArchive.Should().BeFalse();
    }

    [Test]
    public void ContainsRootXmlFile_ShouldReturn_True_When_ZipArchive_ContainsProductXml()
    {
        var gldfBytes = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
        File.WriteAllBytes(_tempFile, gldfBytes);

        var containsRootXml = ZipArchiveReader.ContainsRootXml(_tempFile);

        containsRootXml.Should().BeTrue();
    }

    [Test]
    public void ContainsRootXmlStream_ShouldReturn_True_When_ZipArchive_ContainsProductXml()
    {
        var gldfBytes = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
        File.WriteAllBytes(_tempFile, gldfBytes);
        using var memoryStream = new MemoryStream(gldfBytes);

        var containsRootXml = ZipArchiveReader.ContainsRootXml(memoryStream, false);

        containsRootXml.Should().BeTrue();
    }

    [TestCase("product.xml")]
    [TestCase("Product.xml")]
    [TestCase("PRODUCT.XML")]
    public void ContainsRootXmlFile_ShouldIgnoreCase(string fileName)
    {
        {
            using var stream = new FileStream(_tempFile, FileMode.Create);
            using var zipArchive = new ZipArchive(stream, ZipArchiveMode.Create);
            zipArchive.CreateEntry(fileName);
        }

        var containsRootXml = ZipArchiveReader.ContainsRootXml(_tempFile);

        containsRootXml.Should().BeTrue();
    }

    [TestCase("product.xml")]
    [TestCase("Product.xml")]
    [TestCase("PRODUCT.XML")]
    public void ContainsRootXmlStream_ShouldIgnoreCase(string fileName)
    {
        using var stream = new MemoryStream();
        using var zipArchive = new ZipArchive(stream, ZipArchiveMode.Create, true);
        zipArchive.CreateEntry(fileName);
        zipArchive.Dispose();

        var containsRootXml = ZipArchiveReader.ContainsRootXml(stream, false);

        containsRootXml.Should().BeTrue();
    }

    [Test]
    public void ContainsRootXmlFile_ShouldReturn_False_When_ZipArchive_HasNoProductXml()
    {
        var containsRootXml = ZipArchiveReader.ContainsRootXml(_tempFile);

        containsRootXml.Should().BeFalse();
    }

    [Test]
    public void ContainsRootXmlStream_ShouldReturn_False_When_ZipArchive_HasNoProductXml()
    {
        using var memoryStream = new MemoryStream(File.ReadAllBytes(_tempFile));

        var containsRootXml = ZipArchiveReader.ContainsRootXml(memoryStream, true);

        containsRootXml.Should().BeFalse();
    }

    [Test]
    public void ContainsRootXmlFile_ShouldThrow_When_ZipArchiveIsInvalid()
    {
        File.WriteAllBytes(_tempFile, new byte[1]);

        Action act = () => ZipArchiveReader.ContainsRootXml(_tempFile);

        act.Should().ThrowExactly<InvalidDataException>();
    }

    [Test]
    public void ContainsRootXmlStream_ShouldThrow_When_ZipArchiveIsInvalid()
    {
        Action act = () => ZipArchiveReader.ContainsRootXml(Stream.Null, false);

        act.Should().ThrowExactly<InvalidDataException>();
    }

    [Test]
    public void GetLargeFileNamesFile_ShouldReturn_Expected5MbFile()
    {
        var gldfWithLargeFiles = EmbeddedGldfTestData.GetGldfWithLargeFiles();
        File.WriteAllBytes(_tempFile, gldfWithLargeFiles);

        var largeFileNames = ZipArchiveReader.GetLargeFileNames(_tempFile, 5 * 1024 * 1024).ToList();

        largeFileNames.Should().Contain("doc/5MbTextFile.txt");
        largeFileNames.Should().NotContain("doc/4MbTextFile.txt");
    }

    [Test]
    public void GetLargeFileNamesStream_ShouldReturn_Expected5MbFile()
    {
        var gldfWithLargeFiles = EmbeddedGldfTestData.GetGldfWithLargeFiles();
        using var stream = new MemoryStream(gldfWithLargeFiles);

        var largeFileNames = ZipArchiveReader.GetLargeFileNames(stream, false, 5 * 1024 * 1024).ToList();

        largeFileNames.Should().Contain("doc/5MbTextFile.txt");
        largeFileNames.Should().NotContain("doc/4MbTextFile.txt");
    }

    [Test]
    public void GetLargeFileNamesFile_ShouldThrow_WhenInvalidZipFile()
    {
        File.WriteAllBytes(_tempFile, new byte[1]);

        Action act = () => ZipArchiveReader.GetLargeFileNames(_tempFile, 1);

        act.Should().ThrowExactly<InvalidDataException>();
    }

    [Test]
    public void GetLargeFileNamesStream_ShouldThrow_WhenInvalidZipFile()
    {
        Action act = () => ZipArchiveReader.GetLargeFileNames(Stream.Null, false, 1);

        act.Should().ThrowExactly<InvalidDataException>();
    }

    [Test]
    public void ExtractToDirectory_ShouldExtract_ExpectedContent()
    {
        var tempSubDirectory = Path.Combine(Path.GetTempPath(), $"gldf-{DateTime.Now.Ticks}");
        var gldfWithFiles = EmbeddedGldfTestData.GetGldfWithFiles();
        var expectedDirectoryFilePaths = EmbeddedGldfTestData.ExpectedDirectoryFilePaths;
        File.WriteAllBytes(_tempFile, gldfWithFiles);

        ZipArchiveReader.ExtractToDirectory(_tempFile, tempSubDirectory);
        var options = new EnumerationOptions { RecurseSubdirectories = true };
        var filesInsideDirectory = Directory.EnumerateFiles(tempSubDirectory, "*.*", options).ToList();
        Directory.Delete(tempSubDirectory, true);

        filesInsideDirectory.Should().HaveCount(12);
        expectedDirectoryFilePaths.ForEach(e => filesInsideDirectory.Should().ContainMatch(e));
    }
}