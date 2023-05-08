using FluentAssertions;
using Gldf.Net.Tests.TestData;
using Gldf.Net.Validation.Model;
using NUnit.Framework;
using System.IO;

namespace Gldf.Net.Tests;

[TestFixture]
public class GldfValidatorTests
{

    private string _tempGldfPath;

    private static readonly TestCaseData[] ValidGldfTestCases = EmbeddedGldfTestData.ValidGldfTestCases;

    [OneTimeSetUp]
    public void SetUp()
    {
        _tempGldfPath = Path.GetTempFileName();
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        File.Delete(_tempGldfPath);
    }

    [Test, TestCaseSource(nameof(ValidGldfTestCases))]
    public void ValidateGldf_ShouldReturnNoHints(byte[] gldf)
    {
        using var memoryStream = new MemoryStream(gldf);
        var container = new GldfContainerReader().ReadFromGldfStream(memoryStream, false);
        var gldfValidator = new GldfValidator();
        var validationHints = gldfValidator.ValidateGldf(container);
        validationHints.Should().HaveCount(0);
    }
    
    [Test, TestCaseSource(nameof(ValidGldfTestCases))]
    public void ValidateGldfFile_ShouldReturnNoHints(byte[] gldf)
    {
        File.WriteAllBytes(_tempGldfPath, gldf);
        var gldfValidator = new GldfValidator();
        var validationHints = gldfValidator.ValidateGldfFile(_tempGldfPath, ValidationFlags.All);
        validationHints.Should().HaveCount(0);
    }
    
    [Test, TestCaseSource(nameof(ValidGldfTestCases))]
    public void ValidateGldfStream_ShouldReturnNoHints(byte[] gldf)
    {
        using var memoryStream = new MemoryStream(gldf);
        var gldfValidator = new GldfValidator();
        var validationHints = gldfValidator.ValidateGldfStream(memoryStream, false, ValidationFlags.All);
        validationHints.Should().HaveCount(0);
    }
}