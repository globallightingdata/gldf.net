using FluentAssertions;
using Gldf.Net.Domain.Xml;
using Gldf.Net.Exceptions;
using Gldf.Net.Tests.TestData;
using Gldf.Net.Validation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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
    public void Ctor_ShouldThrow_When_Encoding_IsNull()
    {
        Action act = () => _ = new GldfXmlValidator(null);

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'encoding')");
    }

    [Test, TestCaseSource(nameof(ValidXmlTestCases))]
    public void ValidateString_ValidTestData_Should_Return_EmptyList(string xml)
    {
        var validationResult = _xmlValidator.ValidateString(xml);

        validationResult.Should().BeEmpty();
    }

    [Test]
    public void ValidateString_ShouldThrow_When_XmlString_IsNull()
    {
        Action act = () => _xmlValidator.ValidateString(null);

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'xml')");
    }

    [Test]
    public void ValidateString_WithEmptyXml_Should_Throw_GldfException()
    {
        Action act = () => _xmlValidator.ValidateString(string.Empty);

        act.Should()
            .ThrowExactly<GldfValidationException>().WithMessage("Failed to validate XML. See inner exception")
            .WithInnerException<GldfException>().WithMessage("Failed to get FormatVersion. See inner exception");
    }

    [Test]
    public void ValidateString_WithMissingGeneralDefinition_Should_Return_ExpectedHint()
    {
        var xml = EmbeddedXmlTestData.GetRootWithHeaderXml();
        var expectedMmessage = "The element 'Root' has incomplete content. " +
                               "List of possible elements expected: 'GeneralDefinitions'.";
        var expectedHint = new ValidationHint(SeverityType.Error, expectedMmessage, ErrorType.XmlSchema);

        var validationResult = _xmlValidator.ValidateString(xml);

        validationResult.Should().ContainEquivalentOf(expectedHint);
    }

    [Test]
    public void ValidateString_WithoutXsd_Should_Validate_WithoutError()
    {
        var xsdLocationString = $@"xsi:noNamespaceSchemaLocation=""{new Root().SchemaLocation}""";
        var xmlWithXsd = EmbeddedXmlTestData.GetHeaderMandatoryXml();
        var xmlWithoutXsd = xmlWithXsd.Replace(xsdLocationString, string.Empty);

        var validationResult = _xmlValidator.ValidateString(xmlWithoutXsd);

        xmlWithoutXsd.ToLower().Should().NotContain("xsd");
        validationResult.Should().BeEmpty();
    }

    [Test]
    public void ValidateString_ValidContent_ButWrongXsd_Should_Ignore_And_ValidateWithEmbeddedXsd()
    {
        const string wrongXsd = "https://raw.githubusercontent.com/globallightingdata/l3d/master/xsd/l3d.xsd";
        var currentXsd = new Root().SchemaLocation;
        var xmlWithCurrentXsd = EmbeddedXmlTestData.GetHeaderMandatoryXml();
        var xmlWithWrongXsd = xmlWithCurrentXsd.Replace(currentXsd, wrongXsd);

        var validationResult = _xmlValidator.ValidateString(xmlWithWrongXsd);

        xmlWithWrongXsd.Should().NotBeEquivalentTo(xmlWithCurrentXsd);
        validationResult.Should().BeEmpty();
    }

    [Test, TestCaseSource(nameof(ValidXmlTestCases))]
    public void ValidateFileValidTestData_Should_Return_EmptyList(string xml)
    {
        File.WriteAllText(_tempFile, xml);
        var validationResult = _xmlValidator.ValidateFile(_tempFile);

        validationResult.Should().BeEmpty();
    }

    [Test]
    public void ValidateFile_ShouldThrow_When_FilePath_IsNull()
    {
        Action act = () => _xmlValidator.ValidateFile(null);

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'filePath')");
    }

    [Test]
    public void ValidateFileWithEmptyXml_Should_Throw_GldfValidationException()
    {
        Action act = () => _xmlValidator.ValidateFile(string.Empty);

        act.Should()
            .ThrowExactly<GldfValidationException>()
            .WithMessage("Failed to validate File with path ''. See inner exception")
            .WithInnerException<ArgumentException>()
            .WithMessage("Empty path name is not legal.");
    }

    [Test]
    public void ValidateFileWithMissingGeneralDefinition_Should_Return_ExpectedHint()
    {
        var xml = EmbeddedXmlTestData.GetRootWithHeaderXml();
        var expectedMmessage = "The element 'Root' has incomplete content. " +
                               "List of possible elements expected: 'GeneralDefinitions'.";
        var expectedHint = new ValidationHint(SeverityType.Error, expectedMmessage, ErrorType.XmlSchema);

        File.WriteAllText(_tempFile, xml);
        var validationResult = _xmlValidator.ValidateFile(_tempFile);

        validationResult.Should().ContainEquivalentOf(expectedHint);
    }

    [Test]
    public void ValidateFileWithoutXsd_Should_Validate_WithoutError()
    {
        var xsdLocationString = $@"xsi:noNamespaceSchemaLocation=""{new Root().SchemaLocation}""";
        var xmlWithXsd = EmbeddedXmlTestData.GetHeaderMandatoryXml();
        var xmlWithoutXsd = xmlWithXsd.Replace(xsdLocationString, string.Empty);

        File.WriteAllText(_tempFile, xmlWithoutXsd);
        var validationResult = _xmlValidator.ValidateFile(_tempFile);

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
        var validationResult = _xmlValidator.ValidateFile(_tempFile);

        xmlWithWrongXsd.Should().NotBeEquivalentTo(xmlWithCurrentXsd);
        validationResult.Should().BeEmpty();
    }
}