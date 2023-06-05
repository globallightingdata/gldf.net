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
    public void ValidateFilepath_ShouldReturnEmptyHintList_WhenZipIsValid()
    {
        var gldfWithInvalidRoot = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
        File.WriteAllBytes(_tempFile, gldfWithInvalidRoot);

        var hints = _gldfZipValidator.ValidateGldfFile(_tempFile);

        hints.Should().BeEmpty();
    }
    
    [Test]
    public void ValidateStream_ShouldReturnEmptyHintList_WhenZipIsValid()
    {
        var gldfWithInvalidRoot = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
        using var memoryStream = new MemoryStream(gldfWithInvalidRoot);

        var hints = _gldfZipValidator.ValidateGldfStream(memoryStream);

        hints.Should().BeEmpty();
    }

    [Test]
    public void ValidateFilepath_ShouldReturnInvalidZip_WhenGldfIsInvalid()
    {
        File.WriteAllBytes(_tempFile, new byte[1]);
        var message = $"The GLDF container '{_tempFile}' seems not to be a valid ZIP file or can't be accessed";
        var expected = new ValidationHint(SeverityType.Error, message, ErrorType.InvalidZip);

        var hints = _gldfZipValidator.ValidateGldfFile(_tempFile).ToList();

        hints.Should().ContainEquivalentOf(expected);
    }

    [Test]
    public void ValidateFilepath_ShouldReturnProductXmlNotFound_WhenProductXmlIsMissing()
    {
        ZipFile.Open(_tempFile, ZipArchiveMode.Update).Dispose();
        var message = $"The GLDF container '{_tempFile}' does not contain a product.xml entry.";
        var expected = new ValidationHint(SeverityType.Error, message, ErrorType.ProductXmlNotFound);

        var hints = _gldfZipValidator.ValidateGldfFile(_tempFile).ToList();

        hints.Should().ContainEquivalentOf(expected);
    }

    [Test]
    public void ValidateFilepath_ShouldReturnNonDeserialisableRoot_WhenProductXmlIsInvalid()
    {
        var gldfWithInvalidRoot = EmbeddedGldfTestData.GetGldfWithInvalidRoot();
        File.WriteAllBytes(_tempFile, gldfWithInvalidRoot);
        const string message = "The product.xml in GLDF container could not be deserialized*";
        var expected = new ValidationHint(SeverityType.Error, message, ErrorType.NonDeserialisableRoot);

        var hints = _gldfZipValidator.ValidateGldfFile(_tempFile).ToList();

        hints.Should().ContainEquivalentOf(expected, o => o
            .Using<string>(s => s.Subject.Should().Match(s.Expectation))
            .When(p => p.Path.EndsWith(nameof(ValidationHint.Message))));
    }

    [Test]
    public void ValidateFilepath_ShouldReturnTooLargeFilesWarning()
    {
        var gldfWithLargeFiles = EmbeddedGldfTestData.GetGldfWithLargeFiles();
        File.WriteAllBytes(_tempFile, gldfWithLargeFiles);
        const string message = "Large files found. It is recommended to limit the maximum file " +
                               "size to 5MB each: doc/5MbTextFile.txt";
        var expected = ValidationHint.Warning(message, ErrorType.TooLargeFiles);

        var hints = _gldfZipValidator.ValidateGldfFile(_tempFile);

        hints.Should().BeEquivalentTo(expected);
    }
}