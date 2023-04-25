using FluentAssertions;
using Gldf.Net.Domain.Xml;
using Gldf.Net.Exceptions;
using Gldf.Net.Tests.TestData;
using Gldf.Net.Tests.TestHelper;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using System.Xml;

namespace Gldf.Net.Tests;

[TestFixture]
public class GldfXmlSerializerTests
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
    public void Ctor_ShouldThrow_WhenSettingsIsNull()
    {
        Action act = () => _ = new GldfXmlSerializer(null);

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'settings')");
    }

    [Test]
    public void SerializeToXml_ShouldThrow_WhenRootIsNull()
    {
        Action act = () => _serializer.SerializeToXml(null);

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'root')");
    }

    [Test]
    public void SerializeToXml_ShouldReturnExpectedXml()
    {
        var root = EmbeddedXmlTestData.GetRootWithHeaderModel();
        var expectedXml = EmbeddedXmlTestData.GetRootWithHeaderXml();

        var xml = _serializer.SerializeToXml(root);

        xml.ShouldBe().EquivalentTo(expectedXml);
    }

    [Test]
    public void SerializeToXmlFile_ShouldReturnExpectedXml()
    {
        var root = EmbeddedXmlTestData.GetRootWithHeaderModel();
        var expectedXml = EmbeddedXmlTestData.GetRootWithHeaderXml();

        _serializer.SerializeToXmlFile(root, _tempFile);
        var writtenXml = File.ReadAllText(_tempFile);

        writtenXml.ShouldBe().EquivalentTo(expectedXml);
    }

    [Test]
    public void SerializeToXml_ShouldReturnExpectedXml_WhenSettingsSet()
    {
        var root = EmbeddedXmlTestData.GetRootWithHeaderModel();
        var expectedXml = EmbeddedXmlTestData.GetRootWithHeaderUnintendXml();

        var xml = _serializerWithSettings.SerializeToXml(root);

        xml.ShouldBe().EquivalentTo(expectedXml);
    }

    [Test]
    public void SerializeToXml_ShouldThrowGldfException_WhenInvalidRoot()
    {
        Action act = () => _serializer.SerializeToXml(new InvalidRoot());

        act.Should().Throw<GldfException>();
    }

    [Test]
    public void SerializeToXmlFile_ShouldThrow_WhenRootIsNull()
    {
        var act = () => _serializer.SerializeToXmlFile(null, "");

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'root')");
    }

    [Test]
    public void SerializeToXmlFile_ShouldThrow_WhenFilePathIsNull()
    {
        var act = () => _serializer.SerializeToXmlFile(new Root(), null);

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'filePath')");
    }

    [Test]
    public void SerializeToXmlFile_ShouldSaveExpectedXml()
    {
        var root = EmbeddedXmlTestData.GetRootWithHeaderModel();
        var expectedXml = EmbeddedXmlTestData.GetRootWithHeaderXml();

        _serializer.SerializeToXmlFile(root, _tempFile);
        var xml = File.ReadAllText(_tempFile);

        xml.ShouldBe().EquivalentTo(expectedXml);
    }

    [Test]
    public void SerializeToXmlFile_ShouldSaveExpectedXml_WhenSettingsSet()
    {
        var root = EmbeddedXmlTestData.GetRootWithHeaderModel();
        var expectedXml = EmbeddedXmlTestData.GetRootWithHeaderUnintendXml();

        _serializerWithSettings.SerializeToXmlFile(root, _tempFile);
        var xml = File.ReadAllText(_tempFile);

        xml.ShouldBe().EquivalentTo(expectedXml);
    }

    [Test]
    public void SerializeToXmlFile_ShouldThrowGldfException_WhenInvalidRoot()
    {
        var act = () => _serializer.SerializeToXmlFile(new InvalidRoot(), "/");

        act.Should().Throw<GldfException>();
    }

    [Test]
    public void SerializeToXmlStream_ShouldReturnExpectedXml()
    {
        var root = EmbeddedXmlTestData.GetHeaderMandatoryModel();
        var expectedXml = EmbeddedXmlTestData.GetHeaderMandatoryXml();
        using var memoryStream = new MemoryStream();

        _serializer.SerializeToXmlStream(root, memoryStream);

        memoryStream.ToUTF8String().ShouldBe().EquivalentTo(expectedXml);
    }

    [Test]
    public void SerializeToXmlStream_ShouldThrow_WhenRootIsNull()
    {
        var act = () =>
        {
            using var memoryStream = new MemoryStream();
            _serializer.SerializeToXmlStream(null, memoryStream);
        };

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'root')");
    }

    [Test]
    public void SerializeToXmlStream_ShouldThrowGldfException_WhenInvalidRoot()
    {
        var act = () =>
        {
            using var memoryStream = new MemoryStream();
            _serializer.SerializeToXmlStream(new InvalidRoot(), memoryStream);
        };

        act.Should().Throw<GldfException>();
    }

    /************* Deserialize *************/

    [Test]
    public void DeserializeFromXml_ShouldThrow_WhenXmlStringIsNull()
    {
        Action act = () => _serializer.DeserializeFromXml(null);

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'xml')");
    }

    [Test]
    public void DeserializeFromXml_Should_Return_ExpectedRoot()
    {
        var xml = EmbeddedXmlTestData.GetRootWithHeaderXml();
        var expectedRoot = EmbeddedXmlTestData.GetRootWithHeaderModel();

        var root = _serializer.DeserializeFromXml(xml);

        root.Should().BeEquivalentTo(expectedRoot);
    }

    [Test]
    public void DeserializeFromXml_InvalidXml_Should_Throw()
    {
        const string invalidXml = "<";

        Action act = () => _serializer.DeserializeFromXml(invalidXml);

        act.Should()
            .Throw<GldfException>()
            .WithMessage("Failed to read XML")
            .WithInnerException<InvalidOperationException>()
            .WithMessage("There is an error in XML document (1, 1).");
    }

    [Test]
    public void DeserializeFromFile_ShouldThrow_When_FilePath_IsNull()
    {
        Action act = () => _serializer.DeserializeFromXmlFile(null);

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'xmlFilePath')");
    }

    [Test]
    public void DerserializeFromFile_Should_Return_ExpectedRoot()
    {
        var xml = EmbeddedXmlTestData.GetRootWithHeaderXml();
        var expectedRoot = EmbeddedXmlTestData.GetRootWithHeaderModel();
        File.WriteAllText(_tempFile, xml);

        var root = _serializer.DeserializeFromXmlFile(_tempFile);

        root.Should().BeEquivalentTo(expectedRoot);
    }

    [Test]
    public void DerserializeFromFile_InvalidXml_Should_Throw()
    {
        const string invalidXml = "<";
        File.WriteAllText(_tempFile, invalidXml);

        Action act = () => _serializer.DeserializeFromXmlFile(_tempFile);

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