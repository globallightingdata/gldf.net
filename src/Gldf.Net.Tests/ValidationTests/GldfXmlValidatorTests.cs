using FluentAssertions;
using Gldf.Net.Domain.Xml;
using Gldf.Net.Tests.TestData;
using Gldf.Net.Validation.Model;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;

namespace Gldf.Net.Tests.ValidationTests;

[TestFixture]
public class GldfXmlValidatorTests
{
    private GldfXmlValidator _xmlValidator;
    private string _tempFile;
    private static readonly TestCaseData[] ValidXmlTestCases = EmbeddedXmlTestData.ValidXmlTestCases;

    [SetUp]
    public void SetUp()
    {
        _xmlValidator = new GldfXmlValidator();
        _tempFile = Path.GetTempFileName();
    }

    [TearDown]
    public void TearDown()
    {
        File.Delete(_tempFile);
    }

    [Test]
    public void Ctor_ShouldThrow_WhenEncodingIsNull()
    {
        Action act = () => _ = new GldfXmlValidator(null);

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'encoding')");
    }

    [TestCase(null)]
    [TestCase("")]
    public void ValidateXml_ShouldReturnExpected_WhenXmlIsNullOrEmpty(string xml)
    {
        var expected = ValidationHint.Error("Failed to validate XML Schema*", ErrorType.XmlSchema);
        var hints = _xmlValidator.ValidateXml(xml);

        hints.Should().BeEquivalentTo(expected, o => o
            .Using<string>(s => s.Subject.Should().Match(s.Expectation))
            .When(p => p.Path.EndsWith(nameof(ValidationHint.Message))));
    }

    [Test]
    public void ValidateXml_ShouldReturnXmlSchemaHint_WhenXmlIncomplete()
    {
        var xml = EmbeddedXmlTestData.GetRootWithHeaderXml();
        var expectedMmessage = "The element 'Root' has incomplete content. " +
                               "List of possible elements expected: 'GeneralDefinitions'.";
        var expectedHint = new ValidationHint(SeverityType.Error, expectedMmessage, ErrorType.XmlSchema);

        var validationResult = _xmlValidator.ValidateXml(xml);

        validationResult.Should().ContainEquivalentOf(expectedHint);
    }

    [Test]
    public void ValidateXml_ShouldReturnEmptyList_WhenNoXsdSet()
    {
        var xsdLocationString = $@"xsi:noNamespaceSchemaLocation=""{new Root().SchemaLocation}""";
        var xmlWithXsd = EmbeddedXmlTestData.GetHeaderMandatoryXml();
        xmlWithXsd.Should().Contain(xsdLocationString);
        var xmlWithoutXsd = xmlWithXsd.Replace(xsdLocationString, string.Empty);

        var validationResult = _xmlValidator.ValidateXml(xmlWithoutXsd);

        xmlWithoutXsd.ToLower().Should().NotContain("xsd");
        validationResult.Should().BeEmpty();
    }

    [Test]
    public void ValidateXml_ShouldReturnEmptyList_WhenXmlIsValid_AndXsdIsInvalid()
    {
        const string wrongXsd = "https://gldf.io/xsd/l3d/l3d.xsd";
        var currentXsd = new Root().SchemaLocation;
        var xmlWithCurrentXsd = EmbeddedXmlTestData.GetHeaderMandatoryXml();
        xmlWithCurrentXsd.Should().Contain(currentXsd);
        var xmlWithWrongXsd = xmlWithCurrentXsd.Replace(currentXsd, wrongXsd);

        var validationResult = _xmlValidator.ValidateXml(xmlWithWrongXsd);

        xmlWithWrongXsd.Should().NotBeEquivalentTo(xmlWithCurrentXsd);
        validationResult.Should().BeEmpty();
    }

    [Test, TestCaseSource(nameof(ValidXmlTestCases))]
    public void ValidateXml_ShouldReturnEmptyList_WhendXmlIsValid(string xml)
    {
        var validationResult = _xmlValidator.ValidateXml(xml);
        validationResult.Should().BeEmpty();
    }

    [TestCase("")]
    [TestCase(null)]
    public void ValidateFile_ShouldReturnExpected_WhenFileIsInvalid(string filepath)
    {
        var expected = ValidationHint.Error("Failed to validate XML Schema*", ErrorType.XmlSchema);
        var hints = _xmlValidator.ValidateXmlFile(filepath);

        hints.Should().BeEquivalentTo(expected, o => o
            .Using<string>(s => s.Subject.Should().Match(s.Expectation))
            .When(p => p.Path.EndsWith(nameof(ValidationHint.Message))));
    }

    [Test]
    public void ValidateFile_ShouldReturnExpected_WhenMissingGeneralDefinition()
    {
        var xml = EmbeddedXmlTestData.GetRootWithHeaderXml();
        var expectedMmessage = "The element 'Root' has incomplete content. " +
                               "List of possible elements expected: 'GeneralDefinitions'.";
        var expectedHint = new ValidationHint(SeverityType.Error, expectedMmessage, ErrorType.XmlSchema);
        File.WriteAllText(_tempFile, xml);

        var validationResult = _xmlValidator.ValidateXmlFile(_tempFile);
        validationResult.Should().ContainEquivalentOf(expectedHint);
    }

    [Test]
    public void ValidateFile_ShouldReturnEmptyList_WhenNoXsdSet()
    {
        var xsdLocationString = $@"xsi:noNamespaceSchemaLocation=""{new Root().SchemaLocation}""";
        var xmlWithXsd = EmbeddedXmlTestData.GetHeaderMandatoryXml();
        var xmlWithoutXsd = xmlWithXsd.Replace(xsdLocationString, string.Empty);

        File.WriteAllText(_tempFile, xmlWithoutXsd);
        var validationResult = _xmlValidator.ValidateXmlFile(_tempFile);

        xmlWithoutXsd.ToLower().Should().NotContain("xsd");
        validationResult.Should().BeEmpty();
    }

    [Test]
    public void ValidateFile_ShouldReturnEmptyList_WhenXmlIsValid_AndXsdIsInvalid()
    {
        const string wrongXsd = "https://gldf.io/xsd/l3d/l3d.xsd";
        var currentXsd = new Root().SchemaLocation;
        var xmlWithCurrentXsd = EmbeddedXmlTestData.GetHeaderMandatoryXml();
        var xmlWithWrongXsd = xmlWithCurrentXsd.Replace(currentXsd, wrongXsd);

        File.WriteAllText(_tempFile, xmlWithWrongXsd);
        var validationResult = _xmlValidator.ValidateXmlFile(_tempFile);

        xmlWithWrongXsd.Should().NotBeEquivalentTo(xmlWithCurrentXsd);
        validationResult.Should().BeEmpty();
    }

    [Test, TestCaseSource(nameof(ValidXmlTestCases))]
    public void ValidateFile_ShouldReturnEmptyList_WhenDataIsValid(string xml)
    {
        File.WriteAllText(_tempFile, xml);
        var validationResult = _xmlValidator.ValidateXmlFile(_tempFile);

        validationResult.Should().BeEmpty();
    }

    [Test, TestCaseSource(nameof(ValidXmlTestCases))]
    public void ValidateXmlStream_ShouldReturnEmptyList_WhenDataIsValid(string xml)
    {
        using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
        var validationResult = _xmlValidator.ValidateXmlStream(memoryStream, false);

        validationResult.Should().BeEmpty();
    }

    [Test]
    public void ValidateGldfFile_ShouldReturnEmptyList_WhenDataIsValid()
    {
        var gldf = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
        File.WriteAllBytes(_tempFile, gldf);
        var validationResult = _xmlValidator.ValidateGldfFile(_tempFile);

        validationResult.Should().BeEmpty();
    }

    [Test]
    public void ValidateGldfStream_ShouldReturnEmptyList_WhenDataIsValid()
    {
        var gldf = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
        using var memoryStream = new MemoryStream(gldf);
        var validationResult = _xmlValidator.ValidateGldfStream(memoryStream, false);

        validationResult.Should().BeEmpty();
    }
}