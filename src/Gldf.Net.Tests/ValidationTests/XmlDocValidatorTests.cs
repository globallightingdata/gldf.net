using FluentAssertions;
using Gldf.Net.Domain.Xml;
using Gldf.Net.Exceptions;
using Gldf.Net.Tests.TestData;
using Gldf.Net.Validation;
using Gldf.Net.Validation.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace Gldf.Net.Tests.ValidationTests;

[TestFixture]
public class XmlDocValidatorTests
{
    private readonly GldfXmlSchemaValidator _xmlValidator = new();
    private static TestCaseData[] _validXmlTestCases = EmbeddedXmlTestData.ValidXmlTestCases;

    [Test, TestCaseSource(nameof(_validXmlTestCases))]
    public void ValidateString_ShouldReturnEmptyList_WhenValidTestData(string xml)
    {
        var validationResult = _xmlValidator.ValidateXml(xml);
        validationResult.Should().BeEmpty();
    }

    [Test]
    public void ValidateString_ShouldThrowArgumentNullException_WhenNull()
    {
        Action act = () => _xmlValidator.ValidateXml(null);

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null*");
    }

    [Test]
    public void ValidateString_ShouldThrowGldfException_WhenEmptyString()
    {
        Action act = () => _xmlValidator.ValidateXml(string.Empty);

        act.Should()
            .Throw<GldfException>()
            .WithMessage("Failed to get FormatVersion. See inner exception");
    }

    [Test]
    public void ValidateString_ShouldReturnExpectedHint_WhenInvalidXml()
    {
        const string invalidXml = "<";
        const string expectedMessage = "Data at the root level is invalid. Line 1, position 1.";
        var expectedHint = new ValidationHint(SeverityType.Error, expectedMessage, ErrorType.XmlSchema);
        var validator = new GldfXmlSchemaValidatorTestClass();

        var validationResult = validator.CallValidateWithSchemaSet(invalidXml);

        validationResult.Should().ContainEquivalentOf(expectedHint);
    }

    [Test]
    public void ValidateString_ShouldReturnExpectedHint_WhenMissingGeneralDefinition()
    {
        var xml = EmbeddedXmlTestData.GetRootWithHeaderXml();
        var expectedMmessage = "The element 'Root' has incomplete content. " +
                               "List of possible elements expected: 'GeneralDefinitions'.";
        var expectedHint = new ValidationHint(SeverityType.Error, expectedMmessage, ErrorType.XmlSchema);

        var validationResult = _xmlValidator.ValidateXml(xml);

        validationResult.Should().ContainEquivalentOf(expectedHint);
    }

    [Test]
    public void ValidateString_ShouldValidate_WhenMissingXsd()
    {
        var xsdLocationString = $@"xsi:noNamespaceSchemaLocation=""{new Root().SchemaLocation}""";
        var xmlWithXsd = EmbeddedXmlTestData.GetHeaderMandatoryXml();
        var xmlWithoutXsd = xmlWithXsd.Replace(xsdLocationString, string.Empty);

        var validationResult = _xmlValidator.ValidateXml(xmlWithoutXsd);

        xmlWithoutXsd.ToLower().Should().NotContain("xsd");
        validationResult.Should().BeEmpty();
    }

    [Test]
    public void ValidateString_ShouldIgnoreInvalidXsd()
    {
        const string wrongXsd = "https://gldf.io/xsd/l3d/l3d.xsd";
        var currentXsd = new Root().SchemaLocation;
        var xmlWithCurrentXsd = EmbeddedXmlTestData.GetHeaderMandatoryXml();
        var xmlWithWrongXsd = xmlWithCurrentXsd.Replace(currentXsd, wrongXsd);

        var validationResult = _xmlValidator.ValidateXml(xmlWithWrongXsd);

        xmlWithWrongXsd.Should().NotBeEquivalentTo(xmlWithCurrentXsd);
        validationResult.Should().BeEmpty();
    }

    [Test, TestCaseSource(nameof(_validXmlTestCases))]
    public void ValidateFile_ShouldReturnEmptyList_WhenValidTestData(string xml)
    {
        var tempFileName = Path.GetTempFileName();
        try
        {
            File.WriteAllText(tempFileName, xml);
            var validationResult = _xmlValidator.ValidateXmlFile(tempFileName);
            validationResult.Should().BeEmpty();
        }
        finally
        {
            File.Delete(tempFileName);
        }
    }

    [Test]
    public void ValidateFile_ShouldThrow_WhenPathIsNull()
    {
        Action act = () => _xmlValidator.ValidateXmlFile(null);

        act.Should()
            .Throw<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'path')");
    }

    [Test]
    public void ValidateFile_ShouldThrow_WhenPathIsEmpty()
    {
        Action act = () => _xmlValidator.ValidateXmlFile(string.Empty);

        act.Should()
            .Throw<ArgumentException>()
            .WithMessage("Empty path name is not legal. (Parameter 'path')");
    }

    [Test]
    public void ValidateFile_ShouldThrow_WhenPathIsInvalid()
    {
        var tempFileName = Path.GetTempFileName();
        try
        {
            var act = () => _xmlValidator.ValidateXmlFile(tempFileName);

            act.Should()
                .Throw<GldfException>()
                .WithMessage("Failed to get FormatVersion*");
        }
        finally
        {
            File.Delete(tempFileName);
        }
    }
}

internal class GldfXmlSchemaValidatorTestClass : GldfXmlSchemaValidator
{
    public IEnumerable<ValidationHint> CallValidateWithSchemaSet(string xml)
    {
        using var stringReader = new StringReader(xml);
        return Validate(stringReader, null);
    }
}