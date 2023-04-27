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
public class MetaInfoSerializerTests
{
    private MetaInfoSerializer _serializer;
    private MetaInfoSerializer _serializerWithSettings;
    private string _tempFile;

    [SetUp]
    public void SetUp()
    {
        var writerSettings = new XmlWriterSettings { Indent = false, Encoding = Encoding.UTF32 };
        var readerSettings = new XmlReaderSettings { IgnoreWhitespace = true };
        _serializer = new MetaInfoSerializer();
        _serializerWithSettings = new MetaInfoSerializer(writerSettings, readerSettings);
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
        Action act = () => _ = new MetaInfoSerializer(null, new XmlReaderSettings());

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'writerSettings')");
    }
    
    [Test]
    public void Ctor_ShouldThrow_WhenReaderWriterSettingIsNull()
    {
        Action act = () => _ = new MetaInfoSerializer(new XmlWriterSettings(), null);

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'readerSettings')");
    }

    [Test]
    public void SerializeToString_ShouldThrow_WhenMetaInformationIsNull()
    {
        Action act = () => _serializer.SerializeToXml(null);

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'value')");
    }

    [Test]
    public void SerializeToString_ShouldReturnExpectedXml()
    {
        var expectedXml = EmbeddedXmlTestData.GetMetaInformationXml();
        var metaInformation = EmbeddedXmlTestData.GetMetaInformationModel();

        var xml = _serializer.SerializeToXml(metaInformation);

        xml.ShouldBe().EquivalentTo(expectedXml);
    }

    [Test]
    public void SerializeToString_WithSettings_ShouldReturnExpectedXml()
    {
        var expectedXml = EmbeddedXmlTestData.GetMetaInformationXml();
        var metaInformation = EmbeddedXmlTestData.GetMetaInformationModel();

        var xml = _serializerWithSettings.SerializeToXml(metaInformation);

        xml.ShouldBe().EquivalentTo(expectedXml);
    }

    [Test]
    public void SerializeToXmlFile_ShouldThrow_WhenMetaInformationIsNull()
    {
        var act = () => _serializer.SerializeToXmlFile(null, "");

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'value')");
    }

    [Test]
    public void SerializeToXmlFile_ShouldThrow_WhenFilePathIsNull()
    {
        var act = () => _serializer.SerializeToXmlFile(new MetaInformation(), null);

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'xmlFilePath')");
    }

    [Test]
    public void SerializeToXmlFile_ShouldSaveExpectedXml()
    {
        var expectedXml = EmbeddedXmlTestData.GetMetaInformationXml();
        var metaInformation = EmbeddedXmlTestData.GetMetaInformationModel();

        _serializer.SerializeToXmlFile(metaInformation, _tempFile);
        var xml = File.ReadAllText(_tempFile);

        xml.ShouldBe().EquivalentTo(expectedXml);
    }

    [Test]
    public void SerializeToXmlFile_WithSettings_ShouldSaveExpectedXml()
    {
        var expectedXml = EmbeddedXmlTestData.GetMetaInformationXml();
        var metaInformation = EmbeddedXmlTestData.GetMetaInformationModel();

        _serializerWithSettings.SerializeToXmlFile(metaInformation, _tempFile);
        var xml = File.ReadAllText(_tempFile);

        xml.ShouldBe().EquivalentTo(expectedXml);
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
        var xml = EmbeddedXmlTestData.GetMetaInformationXml();
        var expectedMetaInformation = EmbeddedXmlTestData.GetMetaInformationModel();

        var root = _serializer.DeserializeFromXml(xml);

        root.Should().BeEquivalentTo(expectedMetaInformation);
    }

    [Test]
    public void DeserializeFromXml_ShouldThrow_WhenInvalidXml()
    {
        const string invalidXml = "<";

        Action act = () => _serializer.DeserializeFromXml(invalidXml);

        act.Should()
            .Throw<GldfException>()
            .WithMessage("Failed to deserialize MetaInformation from XML")
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
        var xml = EmbeddedXmlTestData.GetMetaInformationXml();
        var expectedMetaInformation = EmbeddedXmlTestData.GetMetaInformationModel();
        File.WriteAllText(_tempFile, xml);

        var root = _serializer.DeserializeFromXmlFile(_tempFile);

        root.Should().BeEquivalentTo(expectedMetaInformation);
    }

    [Test]
    public void DerserializeFromFile_InvalidXml_Should_Throw()
    {
        const string invalidXml = "<";
        File.WriteAllText(_tempFile, invalidXml);

        Action act = () => _serializer.DeserializeFromXmlFile(_tempFile);

        act.Should()
            .Throw<GldfException>()
            .WithMessage($"Failed to deserialize MetaInformation from filepath '{_tempFile}'")
            .WithInnerException<InvalidOperationException>()
            .WithMessage("There is an error in XML document (1, 1).");
    }
}