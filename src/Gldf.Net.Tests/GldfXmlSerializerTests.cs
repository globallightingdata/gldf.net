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
    public void Ctor_ShouldThrow_When_Settings_IsNull()
    {
        Action act = () => _ = new GldfXmlSerializer(null);

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'settings')");
    }

    [Test]
    public void SerializeToString_ShouldThrow_When_Root_IsNull()
    {
        Action act = () => _serializer.SerializeToXml(null);

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'root')");
    }

    [Test]
    public void SerializeToString_Should_Return_ExpectedXml()
    {
        var root = EmbeddedXmlTestData.GetRootWithHeaderModel();
        var expectedXml = EmbeddedXmlTestData.GetRootWithHeaderXml();

        var xml = _serializer.SerializeToXml(root);

        xml.ShouldBe().EquivalentTo(expectedXml);
    }

    [Test]
    public void SerializeToString_WithSettings_Should_Return_ExpectedXml()
    {
        var root = EmbeddedXmlTestData.GetRootWithHeaderModel();
        var expectedXml = EmbeddedXmlTestData.GetRootWithHeaderUnintendXml();

        var xml = _serializerWithSettings.SerializeToXml(root);

        xml.ShouldBe().EquivalentTo(expectedXml);
    }

    [Test]
    public void SerializeToString_InvalidObject_Should_Throw_GldfException()
    {
        Action act = () => _serializer.SerializeToXml(new InvalidRoot());

        act.Should().Throw<GldfException>();
    }

    [Test]
    public void SerializeToFile_ShouldThrow_When_Root_IsNull()
    {
        Action act = () => _serializer.SerializeToXmlFile(null, "");

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'root')");
    }

    [Test]
    public void SerializeToFile_ShouldThrow_When_FilePath_IsNull()
    {
        Action act = () => _serializer.SerializeToXmlFile(new Root(), null);

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'filePath')");
    }

    [Test]
    public void SerializeToFile_Should_Save_ExpectedXml()
    {
        var root = EmbeddedXmlTestData.GetRootWithHeaderModel();
        var expectedXml = EmbeddedXmlTestData.GetRootWithHeaderXml();

        _serializer.SerializeToXmlFile(root, _tempFile);
        var xml = File.ReadAllText(_tempFile);

        xml.ShouldBe().EquivalentTo(expectedXml);
    }

    [Test]
    public void SerializeToFile_WithSettings_Should_Save_ExpectedXml()
    {
        var root = EmbeddedXmlTestData.GetRootWithHeaderModel();
        var expectedXml = EmbeddedXmlTestData.GetRootWithHeaderUnintendXml();

        _serializerWithSettings.SerializeToXmlFile(root, _tempFile);
        var xml = File.ReadAllText(_tempFile);

        xml.ShouldBe().EquivalentTo(expectedXml);
    }

    [Test]
    public void SerializeToFile_InvalidObject_Should_Throw_GldfException()
    {
        Action act = () => _serializer.SerializeToXmlFile(new InvalidRoot(), "/");

        act.Should().Throw<GldfException>();
    }

    /************* Deserialize *************/

    [Test]
    public void DeserializeFromString_ShouldThrow_When_XmlString_IsNull()
    {
        Action act = () => _serializer.DeserializeFromXml(null);

        act.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'xml')");
    }

    [Test]
    public void DeserializeFromString_Should_Return_ExpectedRoot()
    {
        var xml = EmbeddedXmlTestData.GetRootWithHeaderXml();
        var expectedRoot = EmbeddedXmlTestData.GetRootWithHeaderModel();

        var root = _serializer.DeserializeFromXml(xml);

        root.Should().BeEquivalentTo(expectedRoot);
    }

    [Test]
    public void DeserializeFromString_InvalidXml_Should_Throw()
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