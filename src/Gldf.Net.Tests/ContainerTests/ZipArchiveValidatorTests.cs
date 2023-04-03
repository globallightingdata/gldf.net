using FluentAssertions;
using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Tests.TestData;
using Gldf.Net.Validation;
using Gldf.Net.Validation.Rules.Container;
using Gldf.Net.Validation.Rules.Zip;
using NUnit.Framework;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace Gldf.Net.Tests.ContainerTests;

[TestFixture]
public class ZipArchiveValidatorTests
{
    private ZipArchiveValidator _zipArchiveValidator;
    private string _tempFile;

    [SetUp]
    public void SetUp()
    {
        _zipArchiveValidator = new ZipArchiveValidator();
        _tempFile = Path.GetTempFileName();
    }

    [TearDown]
    public void TearDown()
    {
        File.Delete(_tempFile);
    }

    [Test]
    public void GetValidationRules_ZipRules_Should_ReturnExpectedRules()
    {
        var zipRules = _zipArchiveValidator.GetValidationRules<IZipArchiveValidationRule>().ToList();

        zipRules.Should().HaveCount(5);
        zipRules.Should().Contain(rule => rule.GetType().IsAssignableFrom(typeof(CanDeserializeProductXmlRule)));
        zipRules.Should().Contain(rule => rule.GetType().IsAssignableFrom(typeof(ContainsProductXmlRule)));
        zipRules.Should().Contain(rule => rule.GetType().IsAssignableFrom(typeof(HasNoLargeFilesRule)));
        zipRules.Should().Contain(rule => rule.GetType().IsAssignableFrom(typeof(IsValidProductXmlRule)));
        zipRules.Should().Contain(rule => rule.GetType().IsAssignableFrom(typeof(IsValidZipArchiveRule)));
    }

    [Test]
    public void GetValidationRules_ContainerRules_Should_ReturnExpectedRuleCount()
    {
        var containerRules = _zipArchiveValidator.GetValidationRules<IContainerValidationRule>().ToList();

        containerRules.Should().HaveCount(2);
        containerRules.Should().Contain(rule => rule.GetType().IsAssignableFrom(typeof(HasNoMissingAssetsRule)));
        containerRules.Should().Contain(rule => rule.GetType().IsAssignableFrom(typeof(HasNoOrphanAssetsRule)));
    }

    [Test]
    public void Validate_Filepath_Should_Return_EmptyHintList()
    {
        var gldfWithInvalidRoot = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
        File.WriteAllBytes(_tempFile, gldfWithInvalidRoot);

        var hints = _zipArchiveValidator.Validate(_tempFile);

        hints.Should().BeEmpty();
    }

    [Test]
    public void Validate_Filepath_Should_Return_InvalidZipFileError_When_GldfIsInvalid()
    {
        File.WriteAllBytes(_tempFile, new byte[1]);
        var message = $"The GLDF container '{_tempFile}' seems not to be a valid ZIP file or can't be accessed";
        var expected = new ValidationHint(SeverityType.Error, message, ErrorType.InvalidZipFile);

        var hints = _zipArchiveValidator.Validate(_tempFile).ToList();

        hints.Should().HaveCount(5);
        hints.Should().ContainEquivalentOf(expected);
    }

    [Test]
    public void Validate_Filepath_Should_Return_RootMissingError_When_ProductXmlEntryIsMissing()
    {
        ZipFile.Open(_tempFile, ZipArchiveMode.Update).Dispose();
        var message = $"The GLDF container '{_tempFile}' does not contain a product.xml entry.";
        var expected = new ValidationHint(SeverityType.Error, message, ErrorType.ProductXmlNotFound);

        var hints = _zipArchiveValidator.Validate(_tempFile).ToList();

        hints.Should().HaveCount(3);
        hints.Should().ContainEquivalentOf(expected);
    }

    [Test]
    public void Validate_Filepath_Should_Return_InvalidRootError_When_ProductXmlIsInvalid()
    {
        var gldfWithInvalidRoot = EmbeddedGldfTestData.GetGldfWithInvalidRoot();
        File.WriteAllBytes(_tempFile, gldfWithInvalidRoot);
        const string message = "The 'contentType' attribute is invalid - " +
                               "The value 'invalid' is invalid according to its datatype 'String' - " +
                               "The Enumeration constraint failed.";
        var expected = new ValidationHint(SeverityType.Error, message, ErrorType.XmlSchema);

        var hints = _zipArchiveValidator.Validate(_tempFile).ToList();

        hints.Should().HaveCount(2);
        hints.Should().ContainEquivalentOf(expected);
    }

    [Test]
    public void Validate_Filepath_Should_Return_LargeFileWarning()
    {
        var gldfWithLargeFiles = EmbeddedGldfTestData.GetGldfWithLargeFiles();
        File.WriteAllBytes(_tempFile, gldfWithLargeFiles);
        const string message = "Large files found. It is recommended to limit the maximum file " +
                               "size to 5MB each: doc/5MbTextFile.txt";
        var expected = new ValidationHint(SeverityType.Warning, message, ErrorType.TooLargeFiles);

        var hints = _zipArchiveValidator.Validate(_tempFile).ToList();

        hints.Should().HaveCount(1);
        hints.Should().ContainEquivalentOf(expected);
    }

    [Test]
    public void Validate_Filepath_Should_Return_MissingFiles()
    {
        var gldfWithLargeFiles = EmbeddedGldfTestData.GetGldfWithMissingFiles();
        File.WriteAllBytes(_tempFile, gldfWithLargeFiles);
        const string message = "The product.xml contains File definitions that are missing in the GLDF " +
                               "container: file.ldt (LdcEulumdat), file.ies (LdcIes), file.xml (LdcIesXml), " +
                               "file.l3d (GeoL3d), file.m3d (GeoM3d), file.r3d (GeoR3d), file.pdf (DocPdf), " +
                               "file.jpg (ImageJpg), file.png (ImagePng), file.svg (ImageSvg), file.ldt " +
                               "(SensorSensLdt), file.xml (SensorSensXml), file.txt (SpectrumText), file.dxf " +
                               "(SymbolDxf), file.svg (SymbolSvg), file.doc (Other)";
        var expected = new ValidationHint(SeverityType.Error, message, ErrorType.MissingContainerAssets);

        var hints = _zipArchiveValidator.Validate(_tempFile).ToList();

        hints.Should().HaveCount(1);
        hints.Should().ContainEquivalentOf(expected);
    }

    [Test]
    public void Validate_Filepath_Should_Return_OrphanedFiles()
    {
        var gldfWithLargeFiles = EmbeddedGldfTestData.GetGldfWithOrphanedFiles();
        File.WriteAllBytes(_tempFile, gldfWithLargeFiles);
        const string message = "The GLDF container contains assets that are not referenced in the product.xml. " +
                               "They should be deleted: orphan.txt";
        var expected = new ValidationHint(SeverityType.Warning, message, ErrorType.OrphanedContainerAssets);

        var hints = _zipArchiveValidator.Validate(_tempFile).ToList();

        hints.Should().HaveCount(1);
        hints.Should().ContainEquivalentOf(expected);
    }

    [Test]
    public void Validate_Container_Should_Return_MissingFiles()
    {
        var gldfWithLargeFiles = EmbeddedGldfTestData.GetGldfWithMissingFiles();
        var zipArchiveReader = new ZipArchiveReader();
        File.WriteAllBytes(_tempFile, gldfWithLargeFiles);
        var gldfContainer = zipArchiveReader.ReadContainer(_tempFile);
        const string message = "The product.xml contains File definitions that are missing in the GLDF " +
                               "container: file.ldt (LdcEulumdat), file.ies (LdcIes), file.xml (LdcIesXml), " +
                               "file.l3d (GeoL3d), file.m3d (GeoM3d), file.r3d (GeoR3d), file.pdf (DocPdf), " +
                               "file.jpg (ImageJpg), file.png (ImagePng), file.svg (ImageSvg), file.ldt " +
                               "(SensorSensLdt), file.xml (SensorSensXml), file.txt (SpectrumText), file.dxf " +
                               "(SymbolDxf), file.svg (SymbolSvg), file.doc (Other)";
        var expected = new ValidationHint(SeverityType.Error, message, ErrorType.MissingContainerAssets);

        var hints = _zipArchiveValidator.Validate(gldfContainer).ToList();

        hints.Should().HaveCount(1);
        hints.Should().ContainEquivalentOf(expected);
    }

    [Test]
    public void Validate_Container_Should_Return_OrphanedFiles()
    {
        var gldfWithLargeFiles = EmbeddedGldfTestData.GetGldfWithOrphanedFiles();
        var zipArchiveReader = new ZipArchiveReader();
        File.WriteAllBytes(_tempFile, gldfWithLargeFiles);
        var container = zipArchiveReader.ReadContainer(_tempFile);
        const string message = "The GLDF container contains assets that are not referenced in " +
                               "the product.xml. They should be deleted: orphan.txt";
        var expected = new ValidationHint(SeverityType.Warning, message, ErrorType.OrphanedContainerAssets);

        var hints = _zipArchiveValidator.Validate(container).ToList();

        hints.Should().HaveCount(1);
        hints.Should().ContainEquivalentOf(expected);
    }
}