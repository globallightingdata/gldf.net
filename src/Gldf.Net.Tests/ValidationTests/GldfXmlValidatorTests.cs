using FluentAssertions;
using Gldf.Net.Domain.Xml;
using Gldf.Net.Domain.Xml.Head.Types;
using Gldf.Net.Tests.TestData;
using Gldf.Net.Validation.Model;
using Gldf.Net.XmlHelper;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using System.Xml.Schema;

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
        Action act = () => _ = new GldfXmlValidator((Encoding)null);

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'encoding')");
    }

    [Test]
    public void Ctor_ShouldThrow_WhenXmlSchemaSetEncodingIsNull()
    {
        Action act = () => _ = new GldfXmlValidator((XmlSchemaSet)null);

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'xmlSchema')");
    }

    [Test]
    public void Ctor_ShouldThrow_WhenEncodingIsNull_AndOrXmlSchemaSetIsNull()
    {
        void Test(Action test, string expectedMessage) => test.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage(expectedMessage);

        Test(() => _ = new GldfXmlValidator(null, null), "Value cannot be null. (Parameter 'encoding')");
        Test(() => _ = new GldfXmlValidator(null, new XmlSchemaSet()), "Value cannot be null. (Parameter 'encoding')");
        Test(() => _ = new GldfXmlValidator(Encoding.UTF8, null), "Value cannot be null. (Parameter 'xmlSchema')");
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
        const string expectedMmessage = "The element 'Root' has incomplete content. " +
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

    [Test, TestCaseSource(nameof(ValidXmlTestCases))]
    public void ValidateXml_ShouldReturnEmptyList_WhendXmlIsValid_AndSchemaSetProvided(string xml)
    {
        var xsd = GldfEmbeddedXsdLoader.Load(new FormatVersion(1, 0, 3));
        var xmlSchema = GldfXmlSchemaFactory.CreateXmlSchema(xsd);
        var xmlValidator = new GldfXmlValidator(xmlSchema);
        var validationResult = xmlValidator.ValidateXml(xml);
        validationResult.Should().BeEmpty();
    }

    [Test, TestCaseSource(nameof(ValidXmlTestCases))]
    public void ValidateXml_ShouldReturnSchemaError_WhendXmlAndSchemaDoNotMatch(string xml)
    {
        var xsd = GldfEmbeddedXsdLoader.Load(new FormatVersion(0, 9, 9));
        var xmlSchema = GldfXmlSchemaFactory.CreateXmlSchema(xsd);
        var xmlValidator = new GldfXmlValidator(xmlSchema);
        var validationResult = xmlValidator.ValidateXml(xml);
        validationResult.Should().Contain(vh => vh.ErrorType == ErrorType.XmlSchema);
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
    public void ValidateFile_ShouldReturnEmptyList_WhenDataIsValid_AndXmlSchemaIsProvided(string xml)
    {
        var xsd = GldfEmbeddedXsdLoader.Load(new FormatVersion(1, 0, 3));
        var xmlSchema = GldfXmlSchemaFactory.CreateXmlSchema(xsd);
        File.WriteAllText(_tempFile, xml);
        var xmlValidator = new GldfXmlValidator(xmlSchema);
        var validationResult = xmlValidator.ValidateXmlFile(_tempFile);

        validationResult.Should().BeEmpty();
    }

    [Test, TestCaseSource(nameof(ValidXmlTestCases))]
    public void ValidateFile_ShouldReturnSchemaError_WhenDataAndXmlSchemaDoNotMatch(string xml)
    {
        var xsd = GldfEmbeddedXsdLoader.Load(new FormatVersion(0, 9, 9));
        var xmlSchema = GldfXmlSchemaFactory.CreateXmlSchema(xsd);
        var xmlValidator = new GldfXmlValidator(xmlSchema);
        File.WriteAllText(_tempFile, xml);
        var validationResult = xmlValidator.ValidateXmlFile(_tempFile);

        validationResult.Should().Contain(vh => vh.ErrorType == ErrorType.XmlSchema);
    }

    [Test, TestCaseSource(nameof(ValidXmlTestCases))]
    public void ValidateXmlStream_ShouldReturnEmptyList_WhenDataIsValid(string xml)
    {
        using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
        var validationResult = _xmlValidator.ValidateXmlStream(memoryStream, false);

        validationResult.Should().BeEmpty();
    }

    [Test, TestCaseSource(nameof(ValidXmlTestCases))]
    public void ValidateXmlStream_ShouldReturnEmptyList_WhenDataIsValid_AndXmlSchemaIsProvided(string xml)
    {
        var xsd = GldfEmbeddedXsdLoader.Load(new FormatVersion(1, 0, 3));
        var xmlSchema = GldfXmlSchemaFactory.CreateXmlSchema(xsd);
        var xmlValidator = new GldfXmlValidator(xmlSchema);
        using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
        var validationResult = xmlValidator.ValidateXmlStream(memoryStream, false);

        validationResult.Should().BeEmpty();
    }

    [Test, TestCaseSource(nameof(ValidXmlTestCases))]
    public void ValidateXmlStream_ShouldReturnSchemaError_WhendXmlAndSchemaDoNotMatch(string xml)
    {
        var xsd = GldfEmbeddedXsdLoader.Load(new FormatVersion(0, 9, 9));
        var xmlSchema = GldfXmlSchemaFactory.CreateXmlSchema(xsd);
        var xmlValidator = new GldfXmlValidator(xmlSchema);
        using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
        var validationResult = xmlValidator.ValidateXmlStream(memoryStream, false);
        validationResult.Should().Contain(vh => vh.ErrorType == ErrorType.XmlSchema);
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