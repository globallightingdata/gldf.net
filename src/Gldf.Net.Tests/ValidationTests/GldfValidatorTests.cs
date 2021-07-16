using FluentAssertions;
using Gldf.Net.Domain;
using Gldf.Net.Exceptions;
using Gldf.Net.Tests.TestData;
using Gldf.Net.Validation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace Gldf.Net.Tests.ValidationTests
{
    [TestFixture]
    public class GldfValidatorTests
    {
        private GldfXmlValidator _xmlValidator;
        private string _tempFile;
        private static List<TestCaseData> _validXmlTestCases = EmbeddedXmlTestData.ValidXmlTestCases;

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

        [Test, TestCaseSource(nameof(_validXmlTestCases))]
        public void ValidateXml_ValidTestData_Should_Return_EmptyList(string xml)
        {
            var validationResult = _xmlValidator.ValidateXml(xml);

            validationResult.Should().BeEmpty();
        }

        [Test]
        public void ValidateXml_WithNull_Should_Throw_GldfValidationException()
        {
            Action act = () => _xmlValidator.ValidateXml(null);

            act.Should()
                .ThrowExactly<GldfValidationException>().WithMessage("Failed to validate XML. See inner exception")
                .WithInnerException<ArgumentException>().WithMessage("Value cannot be null*");
        }

        [Test]
        public void ValidateXml_WithEmptyXml_Should_Throw_GldfException()
        {
            Action act = () => _xmlValidator.ValidateXml(string.Empty);

            act.Should()
                .ThrowExactly<GldfValidationException>().WithMessage("Failed to validate XML. See inner exception")
                .WithInnerException<GldfException>().WithMessage("Failed to get FormatVersion XML element");
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
        public void ValidateXml_ValidContent_ButWrongXsd_Should_Ignore_And_ValidateWithEmbeddedXsd()
        {
            const string wrongXsd = "https://raw.githubusercontent.com/globallightingdata/l3d/master/xsd/l3d.xsd";
            var currentXsd = new Root().SchemaLocation;
            var xmlWithCurrentXsd = EmbeddedXmlTestData.GetHeaderMandatoryXml();
            var xmlWithWrongXsd = xmlWithCurrentXsd.Replace(currentXsd, wrongXsd);

            var validationResult = _xmlValidator.ValidateXml(xmlWithWrongXsd);

            xmlWithWrongXsd.Should().NotBeEquivalentTo(xmlWithCurrentXsd);
            validationResult.Should().BeEmpty();
        }

        [Test, TestCaseSource(nameof(_validXmlTestCases))]
        public void ValidateXmlFile_ValidTestData_Should_Return_EmptyList(string xml)
        {
            File.WriteAllText(_tempFile, xml);
            var validationResult = _xmlValidator.ValidateXmlFile(_tempFile);

            validationResult.Should().BeEmpty();
        }

        [Test]
        public void ValidateXmlFile_WithNull_Should_Throw_GldfValidationException()
        {
            Action act = () => _xmlValidator.ValidateXmlFile(null);

            act.Should()
                .ThrowExactly<GldfValidationException>()
                .WithMessage("Failed to validate File with path ''. See inner exception")
                .WithInnerException<ArgumentException>()
                .WithMessage("Value cannot be null*");
        }

        [Test]
        public void ValidateXmlFile_WithEmptyXml_Should_Throw_GldfValidationException()
        {
            Action act = () => _xmlValidator.ValidateXmlFile(string.Empty);

            act.Should()
                .ThrowExactly<GldfValidationException>()
                .WithMessage("Failed to validate File with path ''. See inner exception")
                .WithInnerException<ArgumentException>()
                .WithMessage("Empty path name is not legal.");
        }

        [Test]
        public void ValidateXmlFile_WithMissingGeneralDefinition_Should_Return_ExpectedHint()
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
        public void ValidateXmlFile_WithoutXsd_Should_Validate_WithoutError()
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
        public void ValidateXmlFile_ValidContent_ButWrongXsd_Should_Ignore_And_ValidateWithEmbeddedXsd()
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
}