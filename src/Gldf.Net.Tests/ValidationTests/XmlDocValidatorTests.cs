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
public class XmlDocValidatorTests
{
    private XmlDocValidator _validator;
    private static List<TestCaseData> _validXmlTestCases = EmbeddedXmlTestData.ValidXmlTestCases;

    [SetUp]
    public void SetUp()
    {
        _validator = new XmlDocValidator();
    }

    [Test, TestCaseSource(nameof(_validXmlTestCases))]
    public void ValidateString_ValidTestData_Should_Return_EmptyList(string xml)
    {
        var validationResult = _validator.ValidateString(xml);

        validationResult.Should().BeEmpty();
    }

    [Test]
    public void ValidateString_WithNull_Should_Throw_ArgumentNullException()
    {
        Action act = () => _validator.ValidateString(null);

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null*");
    }

    [Test]
    public void ValidateString_WithEmptyXml_Should_Throw_GldfException()
    {
        Action act = () => _validator.ValidateString(string.Empty);

        act.Should()
            .Throw<GldfException>()
            .WithMessage("Failed to get FormatVersion. See inner expcetion");
    }

    [Test]
    public void ValidateString_WithInvalidXml_Should_Return_ExpectedHint()
    {
        const string invalidXml = "<";
        const string expectedMessage = "Data at the root level is invalid. Line 1, position 1.";
        var expectedHint = new ValidationHint(SeverityType.Error, expectedMessage, ErrorType.XmlSchema);
        var validator = new XmlDocValidatorTestClass();

        var validationResult = validator.CallValidateWithSchemaSet(invalidXml);

        validationResult.Should().ContainEquivalentOf(expectedHint);
    }

    [Test]
    public void ValidateString_WithMissingGeneralDefinition_Should_Return_ExpectedHint()
    {
        var xml = EmbeddedXmlTestData.GetRootWithHeaderXml();
        var expectedMmessage = "The element 'Root' has incomplete content. " +
                               "List of possible elements expected: 'GeneralDefinitions'.";
        var expectedHint = new ValidationHint(SeverityType.Error, expectedMmessage, ErrorType.XmlSchema);

        var validationResult = _validator.ValidateString(xml);

        validationResult.Should().ContainEquivalentOf(expectedHint);
    }

    [Test]
    public void ValidateString_WithoutXsd_Should_Validate_WithoutError()
    {
        var xsdLocationString = $@"xsi:noNamespaceSchemaLocation=""{new Root().SchemaLocation}""";
        var xmlWithXsd = EmbeddedXmlTestData.GetHeaderMandatoryXml();
        var xmlWithoutXsd = xmlWithXsd.Replace(xsdLocationString, string.Empty);

        var validationResult = _validator.ValidateString(xmlWithoutXsd);

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

        var validationResult = _validator.ValidateString(xmlWithWrongXsd);

        xmlWithWrongXsd.Should().NotBeEquivalentTo(xmlWithCurrentXsd);
        validationResult.Should().BeEmpty();
    }
}

internal class XmlDocValidatorTestClass : XmlDocValidator
{
    public IEnumerable<ValidationHint> CallValidateWithSchemaSet(string xml)
    {
        using var stringReader = new StringReader(xml);
        return ValidateWithSchemaSet(stringReader, null);
    }
}