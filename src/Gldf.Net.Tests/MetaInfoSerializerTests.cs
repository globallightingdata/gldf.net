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
        var settings = new XmlWriterSettings { Indent = false, Encoding = Encoding.UTF32 };
        _serializer = new MetaInfoSerializer();
        _serializerWithSettings = new MetaInfoSerializer(settings);
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
    public void SerializeToString_ShouldThrow_WhenMetaInformationIsNull()
    {
        Action act = () => _serializer.SerializeToString(null);

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'metaInformation')");
    }

    [Test]
    public void SerializeToString_ShouldReturnExpectedXml()
    {
        var expectedXml = EmbeddedXmlTestData.GetMetaInformationXml();
        var metaInformation = EmbeddedXmlTestData.GetMetaInformationModel();

        var xml = _serializer.SerializeToString(metaInformation);

        xml.ShouldBe().EquivalentTo(expectedXml);
    }

    [Test]
    public void SerializeToString_WithSettings_ShouldReturnExpectedXml()
    {
        var expectedXml = EmbeddedXmlTestData.GetMetaInformationXml();
        var metaInformation = EmbeddedXmlTestData.GetMetaInformationModel();

        var xml = _serializerWithSettings.SerializeToString(metaInformation);

        xml.ShouldBe().EquivalentTo(expectedXml);
    }

    [Test]
    public void SerializeToFile_ShouldThrow_WhenMetaInformationIsNull()
    {
        var act = () => _serializer.SerializeToFile(null, "");

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'metaInformation')");
    }

    [Test]
    public void SerializeToFile_ShouldThrow_WhenFilePathIsNull()
    {
        var act = () => _serializer.SerializeToFile(new MetaInformation(), null);

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'filePath')");
    }

    [Test]
    public void SerializeToFile_ShouldSaveExpectedXml()
    {
        var expectedXml = EmbeddedXmlTestData.GetMetaInformationXml();
        var metaInformation = EmbeddedXmlTestData.GetMetaInformationModel();

        _serializer.SerializeToFile(metaInformation, _tempFile);
        var xml = File.ReadAllText(_tempFile);

        xml.ShouldBe().EquivalentTo(expectedXml);
    }

    [Test]
    public void SerializeToFile_WithSettings_ShouldSaveExpectedXml()
    {
        var expectedXml = EmbeddedXmlTestData.GetMetaInformationXml();
        var metaInformation = EmbeddedXmlTestData.GetMetaInformationModel();

        _serializerWithSettings.SerializeToFile(metaInformation, _tempFile);
        var xml = File.ReadAllText(_tempFile);

        xml.ShouldBe().EquivalentTo(expectedXml);
    }

    /************* Deserialize *************/

    [Test]
    public void DeserializeFromString_ShouldThrow_WhenXmlStringIsNull()
    {
        Action act = () => _serializer.DeserializeFromString(null);

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'xml')");
    }

    [Test]
    public void DeserializeFromString_ShouldReturnExpectedRoot()
    {
        var xml = EmbeddedXmlTestData.GetMetaInformationXml();
        var expectedMetaInformation = EmbeddedXmlTestData.GetMetaInformationModel();

        var root = _serializer.DeserializeFromString(xml);

        root.Should().BeEquivalentTo(expectedMetaInformation);
    }

    [Test]
    public void DeserializeFromString_ShouldThrow_WhenInvalidXml()
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
    public void DeserializeFromFile_ShouldThrow_WhenFilePathIsNull()
    {
        Action act = () => _serializer.DeserializeFromFile(null);

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'filePath')");
    }

    [Test]
    public void DerserializeFromFile_ShouldReturnExpectedRoot()
    {
        var xml = EmbeddedXmlTestData.GetMetaInformationXml();
        var expectedMetaInformation = EmbeddedXmlTestData.GetMetaInformationModel();
        File.WriteAllText(_tempFile, xml);

        var root = _serializer.DeserializeFromFile(_tempFile);

        root.Should().BeEquivalentTo(expectedMetaInformation);
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
}