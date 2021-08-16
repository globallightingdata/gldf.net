using FluentAssertions;
using Gldf.Net.Domain;
using Gldf.Net.Exceptions;
using Gldf.Net.Tests.TestData;
using Gldf.Net.Tests.TestHelper;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using System.Xml;

namespace Gldf.Net.Tests
{
    [TestFixture]
    public class GldfDeserializTests
    {
        private GldfXmlSerializer _serializer;
        private GldfXmlSerializer _serializerWithSettings;
        private string _tempFile;

        [SetUp]
        public void SetUp()
        {
            var settings = new XmlWriterSettings { Indent = false, Encoding = Encoding.UTF32 };
            _serializer = new GldfXmlSerializer();
            _serializerWithSettings = new GldfXmlSerializer(settings);
            _tempFile = Path.GetTempFileName();
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(_tempFile);
        }

        [Test]
        public void SerializeToString_Should_Return_ExpectedXml()
        {
            var root = EmbeddedXmlTestData.GetRootWithHeaderModel();
            var expectedXml = EmbeddedXmlTestData.GetRootWithHeaderXml();

            var xml = _serializer.SerializeToString(root);

            xml.ShouldBe().EquivalentTo(expectedXml);
        }

        [Test]
        public void SerializeToString_WithSettings_Should_Return_ExpectedXml()
        {
            var root = EmbeddedXmlTestData.GetRootWithHeaderModel();
            var expectedXml = EmbeddedXmlTestData.GetRootWithHeaderUnintendXml();

            var xml = _serializerWithSettings.SerializeToString(root);

            xml.ShouldBe().EquivalentTo(expectedXml);
        }

        [Test]
        public void SerializeToString_InvalidObject_Should_Throw_GldfException()
        {
            Action act = () => _serializer.SerializeToString(new InvalidRoot());

            act.Should().Throw<GldfException>();
        }

        [Test]
        public void SerializeToFile_Should_Save_ExpectedXml()
        {
            var root = EmbeddedXmlTestData.GetRootWithHeaderModel();
            var expectedXml = EmbeddedXmlTestData.GetRootWithHeaderXml();

            _serializer.SerializeToFile(root, _tempFile);
            var xml = File.ReadAllText(_tempFile);

            xml.ShouldBe().EquivalentTo(expectedXml);
        }

        [Test]
        public void SerializeToFile_WithSettings_Should_Save_ExpectedXml()
        {
            var root = EmbeddedXmlTestData.GetRootWithHeaderModel();
            var expectedXml = EmbeddedXmlTestData.GetRootWithHeaderUnintendXml();

            _serializerWithSettings.SerializeToFile(root, _tempFile);
            var xml = File.ReadAllText(_tempFile);

            xml.ShouldBe().EquivalentTo(expectedXml);
        }

        [Test]
        public void SerializeToFile_InvalidObject_Should_Throw_GldfException()
        {
            Action act = () => _serializer.SerializeToFile(new InvalidRoot(), "/");

            act.Should().Throw<GldfException>();
        }

        /************* Deserialize *************/

        [Test]
        public void DeserializeFromString_Should_Return_ExpectedRoot()
        {
            var xml = EmbeddedXmlTestData.GetRootWithHeaderXml();
            var expectedRoot = EmbeddedXmlTestData.GetRootWithHeaderModel();

            var root = _serializer.DeserializeFromString(xml);

            root.Should().BeEquivalentTo(expectedRoot);
        }

        [Test]
        public void DeserializeFromString_InvalidXml_Should_Throw()
        {
            const string invalidXml = "<";

            Action act = () => _serializer.DeserializeFromString(invalidXml);

            act.Should()
                .Throw<GldfException>()
                .WithMessage("Failed to read XML")
                .WithInnerException<InvalidOperationException>()
                .WithMessage("There is an error in XML document (1, 1).");
        }

        [Test]
        public void DerserializeFromFile_Should_Return_ExpectedRoot()
        {
            var xml = EmbeddedXmlTestData.GetRootWithHeaderXml();
            var expectedRoot = EmbeddedXmlTestData.GetRootWithHeaderModel();
            File.WriteAllText(_tempFile, xml);

            var root = _serializer.DeserializeFromFile(_tempFile);

            root.Should().BeEquivalentTo(expectedRoot);
        }

        [Test]
        public void DerserializeFromFile_InvalidXml_Should_Throw()
        {
            const string invalidXml = "<";
            File.WriteAllText(_tempFile, invalidXml);

            Action act = () => _serializer.DeserializeFromFile(_tempFile);

            act.Should()
                .Throw<GldfException>()
                .WithMessage($"Failed to deserialize Root from filepath '{_tempFile}'")
                .WithInnerException<InvalidOperationException>()
                .WithMessage("There is an error in XML document (1, 1).");
        }

        private class InvalidRoot : Root
        {
        }
    }
}