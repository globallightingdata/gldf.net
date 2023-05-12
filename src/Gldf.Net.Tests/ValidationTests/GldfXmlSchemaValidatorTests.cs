using FluentAssertions;
using Gldf.Net.Domain.Xml;
using Gldf.Net.Exceptions;
using Gldf.Net.Tests.TestData;
using Gldf.Net.Validation;
using Gldf.Net.Validation.Model;
using Gldf.Net.XmlHelper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Schema;

namespace Gldf.Net.Tests.ValidationTests;

[TestFixture]
public class GldfXmlSchemaValidatorTests
{
    private readonly GldfXmlSchemaValidator _xmlValidator = new();
    private static TestCaseData[] _validXmlTestCases = EmbeddedXmlTestData.ValidXmlTestCases;

    [Test, TestCaseSource(nameof(_validXmlTestCases))]
    public void ValidateXml_ShouldReturnEmptyList_WhenValidTestData(string xml)
    {
        var validationResult = _xmlValidator.ValidateXml(xml);
        validationResult.Should().BeEmpty();
    }

    [Test]
    public void GetEmbeddedXmlSchema_ShouldReturnExpectedSchema_WhenGldfXmlParameter()
    {
        const string xml = @"<Root><Header><FormatVersion major=""0"" minor=""9"" pre-release=""9"" /></Header></Root>";
        var xmlSchema = GldfXmlSchemaFactory.GetEmbeddedXmlSchema(xml);
        xmlSchema.Schemas().Count.Should().Be(1);
        foreach (var generatedSchema in xmlSchema.Schemas())
        {
            using var stringWriter = new StringWriter();
            generatedSchema.As<XmlSchema>().Write(stringWriter);
            stringWriter.ToString().Should().Contain(@"xs:schema version=""0.9-beta.9""");
        }
    }

    [Test]
    public void ValidateXml_ShouldThrowArgumentNullException_WhenNull()
    {
        Action act = () => _xmlValidator.ValidateXml(null);

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null*");
    }

    [Test]
    public void ValidateXml_ShouldThrowGldfException_WhenEmptyString()
    {
        Action act = () => _xmlValidator.ValidateXml(string.Empty);

        act.Should()
            .Throw<GldfException>()
            .WithMessage("Failed to get FormatVersion. See inner exception");
    }

    [Test]
    public void ValidateXml_ShouldReturnExpectedHint_WhenInvalidXml()
    {
        const string invalidXml = "<";
        const string expectedMessage = "Data at the root level is invalid. Line 1, position 1.";
        var expectedHint = new ValidationHint(SeverityType.Error, expectedMessage, ErrorType.XmlSchema);
        var validator = new GldfXmlSchemaValidatorTestClass();

        var validationResult = validator.CallValidateWithSchemaSet(invalidXml);

        validationResult.Should().ContainEquivalentOf(expectedHint);
    }

    [Test]
    public void ValidateXml_ShouldReturnExpectedHint_WhenMissingGeneralDefinition()
    {
        var xml = EmbeddedXmlTestData.GetRootWithHeaderXml();
        const string expectedMmessage = "The element 'Root' has incomplete content. " +
                                        "List of possible elements expected: 'GeneralDefinitions'.";
        var expectedHint = new ValidationHint(SeverityType.Error, expectedMmessage, ErrorType.XmlSchema);

        var validationResult = _xmlValidator.ValidateXml(xml);

        validationResult.Should().ContainEquivalentOf(expectedHint);
    }

    [Test]
    public void ValidateXml_ShouldValidate_WhenMissingXsd()
    {
        var xsdLocationString = $@"xsi:noNamespaceSchemaLocation=""{new Root().SchemaLocation}""";
        var xmlWithXsd = EmbeddedXmlTestData.GetHeaderMandatoryXml();
        var xmlWithoutXsd = xmlWithXsd.Replace(xsdLocationString, string.Empty);

        var validationResult = _xmlValidator.ValidateXml(xmlWithoutXsd);

        xmlWithoutXsd.ToLower().Should().NotContain("xsd");
        validationResult.Should().BeEmpty();
    }

    [Test]
    public void ValidateXml_ShouldIgnoreInvalidXsd()
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
    public void ValidateXmlFile_ShouldReturnEmptyList_WhenValidTestData(string xml)
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
    public void ValidateXmlFile_ShouldThrow_WhenPathIsNull()
    {
        Action act = () => _xmlValidator.ValidateXmlFile(null);

        act.Should()
            .Throw<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'path')");
    }

    [Test]
    public void ValidateXmlFile_ShouldThrow_WhenPathIsEmpty()
    {
        Action act = () => _xmlValidator.ValidateXmlFile(string.Empty);

        act.Should()
            .Throw<ArgumentException>()
            .WithMessage("Empty path name is not legal. (Parameter 'path')");
    }

    [Test]
    public void ValidateXmlFile_ShouldThrow_WhenPathIsInvalid()
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

    [Test, TestCaseSource(nameof(_validXmlTestCases))]
    public void ValidateXmlStream_ShouldReturnEmptyList_WhenValidTestData(string xml)
    {
        using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
        var validationResult = _xmlValidator.ValidateXmlStream(memoryStream, false);
        validationResult.Should().BeEmpty();
    }

    [TestCase(true)]
    [TestCase(false)]
    public void ValidateXmlStream_ShouldLeaveStreamInExpectedState(bool leaveOpen)
    {
        var xml = EmbeddedXmlTestData.GetHeaderMandatoryXml();
        using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
        _ = _xmlValidator.ValidateXmlStream(memoryStream, leaveOpen);
        memoryStream.CanRead.Should().Be(leaveOpen);
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