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
        var writerSettings = new XmlWriterSettings { Indent = false, Encoding = Encoding.UTF32 };
        var readerSettings = new XmlReaderSettings { IgnoreWhitespace = true };
        _serializer = new GldfXmlSerializer();
        _serializerWithSettings = new GldfXmlSerializer(writerSettings, readerSettings);
        _tempFile = Path.GetTempFileName();
    }

    [TearDown]
    public void TearDown()
    {
        File.Delete(_tempFile);
    }

    [Test]
    public void Ctor_ShouldThrow_WhenWriterSettingIsNull()
    {
        Action act = () => _ = new GldfXmlSerializer(null, new XmlReaderSettings());

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'writerSettings')");
    }

    [Test]
    public void Ctor_ShouldThrow_WhenReaderWriterSettingIsNull()
    {
        Action act = () => _ = new GldfXmlSerializer(new XmlWriterSettings(), null);

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'readerSettings')");
    }

    [Test]
    public void SerializeToXml_ShouldThrow_WhenRootIsNull()
    {
        Action act = () => _serializer.SerializeToXml(null);

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'value')");
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
            .WithMessage("Value cannot be null. (Parameter 'value')");
    }

    [Test]
    public void SerializeToXmlFile_ShouldThrow_WhenFilePathIsNull()
    {
        var act = () => _serializer.SerializeToXmlFile(new Root(), null);

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'xmlFilePath')");
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

        _serializer.SerializeToXmlStream(root, memoryStream, true);

        memoryStream.ToUTF8String().ShouldBe().EquivalentTo(expectedXml);
    }

    [Test]
    public void SerializeToXmlStream_ShouldThrow_WhenRootIsNull()
    {
        var act = () =>
        {
            using var memoryStream = new MemoryStream();
            _serializer.SerializeToXmlStream(null, memoryStream, false);
        };

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'value')");
    }
    
    [Test]
    public void SerializeToXmlStream_ShouldThrow_WhenStreamIsNull()
    {
        var act = () =>
        {
            using var memoryStream = new MemoryStream();
            _serializer.SerializeToXmlStream(new Root(), null, false);
        };

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'xmlStream')");
    }

    [TestCase(true)]
    [TestCase(false)]
    public void SerializeToXmlStream_ShouldReturnExcpectedStreamState(bool leaveOpen)
    {
        var root = EmbeddedXmlTestData.GetHeaderMandatoryModel();
        using var memoryStream = new MemoryStream();

        _serializer.SerializeToXmlStream(root, memoryStream, leaveOpen);

        memoryStream.CanRead.Should().Be(leaveOpen);
        memoryStream.CanWrite.Should().Be(leaveOpen);
    }

    [Test]
    public void SerializeToXmlStream_ShouldThrowGldfException_WhenInvalidRoot()
    {
        var act = () =>
        {
            using var memoryStream = new MemoryStream();
            _serializer.SerializeToXmlStream(new InvalidRoot(), memoryStream, false);
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
    public void DeserializeFromXml_ShouldReturnExpectedRoot()
    {
        var xml = EmbeddedXmlTestData.GetRootWithHeaderXml();
        var expectedRoot = EmbeddedXmlTestData.GetRootWithHeaderModel();

        var root = _serializer.DeserializeFromXml(xml);

        root.Should().BeEquivalentTo(expectedRoot);
    }

    [Test]
    public void DeserializeFromXml_ShouldThrow_WhenInvalidXml()
    {
        const string invalidXml = "<";

        Action act = () => _serializer.DeserializeFromXml(invalidXml);

        act.Should()
            .Throw<GldfException>()
            .WithMessage("Failed to deserialize Root from XML")
            .WithInnerException<InvalidOperationException>()
            .WithMessage("There is an error in XML document (1, 1).");
    }

    [Test]
    public void DeserializeFromFile_ShouldThrow_WhenFilePathIsNull()
    {
        Action act = () => _serializer.DeserializeFromXmlFile(null);

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'xmlFilePath')");
    }

    [Test]
    public void DerserializeFromFile_ShouldReturnExpectedRoot()
    {
        var xml = EmbeddedXmlTestData.GetRootWithHeaderXml();
        var expectedRoot = EmbeddedXmlTestData.GetRootWithHeaderModel();
        File.WriteAllText(_tempFile, xml);

        var root = _serializer.DeserializeFromXmlFile(_tempFile);

        root.Should().BeEquivalentTo(expectedRoot);
    }

    [Test]
    public void DerserializeFromFile_ShouldThrow_WhenInvalidXml()
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

    [Test]
    public void DeserializeFromXmlStream_ShouldThrow_WhenFilePathIsNull()
    {
        Action act = () => _serializer.DeserializeFromXmlStream(null, false);

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'xmlStream')");
    }

    [Test]
    public void DeserializeFromXmlStream_ShouldReturnExpectedRoot()
    {
        var xml = EmbeddedXmlTestData.GetRootWithHeaderXml();
        var expectedRoot = EmbeddedXmlTestData.GetRootWithHeaderModel();
        using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xml));

        var root = _serializer.DeserializeFromXmlStream(memoryStream, false);

        root.Should().BeEquivalentTo(expectedRoot);
    }

    [Test]
    public void DeserializeFromXmlStream_ShouldThrow_WhenInvalidXml()
    {
        var act = () =>
        {
            const string invalidXml = "<";
            using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(invalidXml));
            _serializer.DeserializeFromXmlStream(memoryStream, false);
        };

        act.Should()
            .Throw<GldfException>()
            .WithMessage("Failed to deserialize Root from stream")
            .WithInnerException<InvalidOperationException>()
            .WithMessage("There is an error in XML document (1, 1).");
    }

    [TestCase(true)]
    [TestCase(false)]
    public void DeserializeFromXmlStream_ShouldReturnExpectedStreamState(bool leaveOpen)
    {
        var xml = EmbeddedXmlTestData.GetHeaderMandatoryXml();
        using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xml));

        _serializer.DeserializeFromXmlStream(memoryStream, leaveOpen);

        memoryStream.CanRead.Should().Be(leaveOpen);
        memoryStream.CanWrite.Should().Be(leaveOpen);
    }

    private class InvalidRoot : Root
    {
    }
}