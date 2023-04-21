using FluentAssertions;
using Gldf.Net.Domain.Xml;
using Gldf.Net.Tests.TestData;
using Gldf.Net.Validation.Model;
using NUnit.Framework;
using System;
using System.IO;

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

    [Test, TestCaseSource(nameof(ValidXmlTestCases))]
    public void ValidateXml_ShouldReturnEmptyList_WhendDataIsValid(string xml)
    {
        var validationResult = _xmlValidator.ValidateXml(xml);
        validationResult.Should().BeEmpty();
    }

    [TestCase(null)]
    [TestCase("")]
    public void ValidateXml_ShouldReturnExpected_WhenXmlIsInvalid(string xml)
    {
        var expected = ValidationHint.Error("Failed to validate XML Schema*", ErrorType.XmlSchema);
        var hints = _xmlValidator.ValidateXml(xml);

        hints.Should().BeEquivalentTo(expected, o => o
            .Using<string>(s => s.Subject.Should().Match(s.Expectation))
            .When(p => p.Path.EndsWith(nameof(ValidationHint.Message))));
    }

    [Test]
    public void ValidateXml_WithMissingGeneralDefinition_Should_Return_ExpectedHint()
    {
        var xml = EmbeddedXmlTestData.GetRootWithHeaderXml();
        var expectedMmessage = "The element 'Root' has incomplete content. " +
                               "List of possible elements expected: 'GeneralDefinitions'.";
        var expectedHint = new ValidationHint(SeverityType.Error, expectedMmessage, ErrorType.XmlSchema);

        var validationResult = _xmlValidator.ValidateXml(xml);

        validationResult.Should().ContainEquivalentOf(expectedHint);
    }

    [Test]
    public void ValidateXml_WithoutXsd_Should_Validate_WithoutError()
    {
        var xsdLocationString = $@"xsi:noNamespaceSchemaLocation=""{new Root().SchemaLocation}""";
        var xmlWithXsd = EmbeddedXmlTestData.GetHeaderMandatoryXml();
        var xmlWithoutXsd = xmlWithXsd.Replace(xsdLocationString, string.Empty);

        var validationResult = _xmlValidator.ValidateXml(xmlWithoutXsd);

        xmlWithoutXsd.ToLower().Should().NotContain("xsd");
        validationResult.Should().BeEmpty();
    }

    [Test]
    public void ValidateXml_ShouldValidateWithEmbeddedXsd()
    {
        const string wrongXsd = "https://raw.githubusercontent.com/globallightingdata/l3d/master/xsd/l3d.xsd";
        var currentXsd = new Root().SchemaLocation;
        var xmlWithCurrentXsd = EmbeddedXmlTestData.GetHeaderMandatoryXml();
        var xmlWithWrongXsd = xmlWithCurrentXsd.Replace(currentXsd, wrongXsd);

        var validationResult = _xmlValidator.ValidateXml(xmlWithWrongXsd);

        xmlWithWrongXsd.Should().NotBeEquivalentTo(xmlWithCurrentXsd);
        validationResult.Should().BeEmpty();
    }

    [Test, TestCaseSource(nameof(ValidXmlTestCases))]
    public void ValidateFile_ShouldReturnEmptyList_WhenValidData(string xml)
    {
        File.WriteAllText(_tempFile, xml);
        var validationResult = _xmlValidator.ValidateXmlFile(_tempFile);

        validationResult.Should().BeEmpty();
    }

    [TestCase("")]
    [TestCase(null)]
    public void ValidateFile_ShouldReturnExpected_WhenInvalidFile(string filepath)
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
    public void ValidateFileWithoutXsd_Should_Validate_WithoutError()
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
    public void ValidateFileValidContent_ButWrongXsd_Should_Ignore_And_ValidateWithEmbeddedXsd()
    {
        const string wrongXsd = "https://raw.githubusercontent.com/globallightingdata/l3d/master/xsd/l3d.xsd";
        var currentXsd = new Root().SchemaLocation;
        var xmlWithCurrentXsd = EmbeddedXmlTestData.GetHeaderMandatoryXml();
        var xmlWithWrongXsd = xmlWithCurrentXsd.Replace(currentXsd, wrongXsd);

        File.WriteAllText(_tempFile, xmlWithWrongXsd);
        var validationResult = _xmlValidator.ValidateXmlFile(_tempFile);

        xmlWithWrongXsd.Should().NotBeEquivalentTo(xmlWithCurrentXsd);
        validationResult.Should().BeEmpty();
    }
}