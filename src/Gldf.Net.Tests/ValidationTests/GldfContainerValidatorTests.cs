using FluentAssertions;
using Gldf.Net.Container;
using Gldf.Net.Tests.TestData;
using Gldf.Net.Validation;
using Gldf.Net.Validation.Model;
using NUnit.Framework;
using System.IO;
using System.Linq;

namespace Gldf.Net.Tests.ValidationTests;

[TestFixture]
public class GldfContainerValidatorTests
{
    private GldfContainerValidator _validator;
    private string _tempFile;

    [SetUp]
    public void SetUp()
    {
        _validator = new GldfContainerValidator();
        _tempFile = Path.GetTempFileName();
    }

    [TearDown]
    public void TearDown()
    {
        File.Delete(_tempFile);
    }

    [Test]
    public void ValidateContainer_ShouldReturnMissingFiles()
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

        var hints = _validator.ValidateGldf(gldfContainer).ToList();

        hints.Should().HaveCount(1);
        hints.Should().ContainEquivalentOf(expected);
    }

    [Test]
    public void ValidateContainer_ShouldReturnOrphanedFiles()
    {
        var gldfWithLargeFiles = EmbeddedGldfTestData.GetGldfWithOrphanedFiles();
        var zipArchiveReader = new ZipArchiveReader();
        File.WriteAllBytes(_tempFile, gldfWithLargeFiles);
        var container = zipArchiveReader.ReadContainer(_tempFile);
        const string message = "The GLDF container contains assets that are not referenced in " +
                               "the Product. They should be deleted: orphan.txt";
        var expected = new ValidationHint(SeverityType.Warning, message, ErrorType.OrphanedContainerAssets);

        var hints = _validator.ValidateGldf(container).ToList();

        hints.Should().HaveCount(1);
        hints.Should().ContainEquivalentOf(expected);
    }

    [Test]
    public void ValidateFile_ShouldReturnInvalidZipFileError_WhenGldfIsInvalid()
    {
        File.WriteAllBytes(_tempFile, new byte[1]);
        var message = $"The GLDF container '{_tempFile}' seems not to be a valid ZIP file or can't be accessed";
        var expected = new ValidationHint(SeverityType.Error, message, ErrorType.InvalidZip);
        var hints = _validator.ValidateGldfFile(_tempFile).ToList();
        hints.Should().ContainEquivalentOf(expected);
    }

    [Test]
    public void ValidateFile_ShouldReturnEmptyHintList_WhenMandatoryGldf()
    {
        var gldfWithInvalidRoot = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
        File.WriteAllBytes(_tempFile, gldfWithInvalidRoot);
        var hints = _validator.ValidateGldfFile(_tempFile);
        hints.Should().BeEmpty();
    }

    [Test]
    public void ValidateFile_ShouldReturnEmptyHintList_WhenCompleteGldf()
    {
        var gldfWithInvalidRoot = EmbeddedGldfTestData.GetGldfWithFilesComplete();
        File.WriteAllBytes(_tempFile, gldfWithInvalidRoot);
        var hints = _validator.ValidateGldfFile(_tempFile);
        hints.Should().BeEmpty();
    }

    [Test]
    public void ValidateFile_ShouldReturnInvalidRootError_WhenProductXmlIsInvalid()
    {
        var gldfWithInvalidRoot = EmbeddedGldfTestData.GetGldfWithInvalidRoot();
        File.WriteAllBytes(_tempFile, gldfWithInvalidRoot);
        const string message = "Failed to read XML";
        var expected = new ValidationHint(SeverityType.Error, message, ErrorType.GenericError);

        var hints = _validator.ValidateGldfFile(_tempFile).ToList();

        hints.Should().HaveCount(1);
        hints.Should().ContainEquivalentOf(expected);
    }

    [Test]
    public void ValidateFilepath_ShouldReturnMissingFiles()
    {
        var gldfWithLargeFiles = EmbeddedGldfTestData.GetGldfWithMissingFiles();
        File.WriteAllBytes(_tempFile, gldfWithLargeFiles);
        const string message = "The product.xml contains File definitions that are missing in the GLDF " +
                               "container: file.ldt (LdcEulumdat), file.ies (LdcIes), file.xml (LdcIesXml), " +
                               "file.l3d (GeoL3d), file.m3d (GeoM3d), file.r3d (GeoR3d), file.pdf (DocPdf), " +
                               "file.jpg (ImageJpg), file.png (ImagePng), file.svg (ImageSvg), file.ldt " +
                               "(SensorSensLdt), file.xml (SensorSensXml), file.txt (SpectrumText), file.dxf " +
                               "(SymbolDxf), file.svg (SymbolSvg), file.doc (Other)";
        var expected = ValidationHint.Error(message, ErrorType.MissingContainerAssets);

        var hints = _validator.ValidateGldfFile(_tempFile).ToList();

        hints.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ValidateFile_ShouldReturnOrphanedFiles()
    {
        var gldfWithLargeFiles = EmbeddedGldfTestData.GetGldfWithOrphanedFiles();
        File.WriteAllBytes(_tempFile, gldfWithLargeFiles);
        const string message = "The GLDF container contains assets that are not referenced in the Product. " +
                               "They should be deleted: orphan.txt";
        var expected = ValidationHint.Warning(message, ErrorType.OrphanedContainerAssets);

        var hints = _validator.ValidateGldfFile(_tempFile).ToList();

        hints.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ValidateContainer_ShouldReturnExpected_WhenContainerIsNull()
    {
        var expected = ValidationHint.Error("The GLDF is null", ErrorType.GenericError);
        var validationHints = _validator.ValidateGldf(null).ToList();
        validationHints.Should().BeEquivalentTo(expected);
    }
}