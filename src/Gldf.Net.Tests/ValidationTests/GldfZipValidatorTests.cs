using FluentAssertions;
using Gldf.Net.Tests.TestData;
using Gldf.Net.Validation;
using Gldf.Net.Validation.Model;
using NUnit.Framework;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace Gldf.Net.Tests.ValidationTests;

[TestFixture]
public class GldfZipValidatorTests
{
    private GldfZipValidator _gldfZipValidator;
    private string _tempFile;

    [SetUp]
    public void SetUp()
    {
        _gldfZipValidator = new GldfZipValidator();
        _tempFile = Path.GetTempFileName();
    }

    [TearDown]
    public void TearDown()
    {
        File.Delete(_tempFile);
    }

    [Test]
    public void Validate_Filepath_Should_Return_EmptyHintList()
    {
        var gldfWithInvalidRoot = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
        File.WriteAllBytes(_tempFile, gldfWithInvalidRoot);

        var hints = _gldfZipValidator.Validate(_tempFile);

        hints.Should().BeEmpty();
    }

    [Test]
    public void Validate_Filepath_Should_Return_InvalidZipFileError_When_GldfIsInvalid()
    {
        File.WriteAllBytes(_tempFile, new byte[1]);
        var message = $"The GLDF container '{_tempFile}' seems not to be a valid ZIP file or can't be accessed";
        var expected = new ValidationHint(SeverityType.Error, message, ErrorType.InvalidZip);

        var hints = _gldfZipValidator.Validate(_tempFile).ToList();

        hints.Should().HaveCount(5);
        hints.Should().ContainEquivalentOf(expected);
    }

    [Test]
    public void Validate_Filepath_Should_Return_RootMissingError_When_ProductXmlEntryIsMissing()
    {
        ZipFile.Open(_tempFile, ZipArchiveMode.Update).Dispose();
        var message = $"The GLDF container '{_tempFile}' does not contain a product.xml entry.";
        var expected = new ValidationHint(SeverityType.Error, message, ErrorType.ProductXmlNotFound);

        var hints = _gldfZipValidator.Validate(_tempFile).ToList();

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

        var hints = _gldfZipValidator.Validate(_tempFile).ToList();

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
        var expected = ValidationHint.Warning(message, ErrorType.TooLargeFiles);

        var hints = _gldfZipValidator.Validate(_tempFile);

        hints.Should().BeEquivalentTo(expected);
    }
}