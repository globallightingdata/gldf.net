using FluentAssertions;
using Gldf.Net.Container;
using Gldf.Net.Parser;
using Gldf.Net.Tests.TestData;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;

namespace Gldf.Net.Tests.ParserTests;

[TestFixture]
public class GldfParserTests
{

    private string _tempGldfPath;

    private static readonly TestCaseData[] ValidXmlTestCases = EmbeddedXmlTestData.ValidXmlTestCases;
    private static readonly TestCaseData[] ValidGldfTestCases = EmbeddedGldfTestData.ValidGldfTestCases;

    [OneTimeSetUp]
    public void SetUp()
    {
        _tempGldfPath = Path.GetTempFileName();
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        File.Delete(_tempGldfPath);
    }

    [Test, TestCaseSource(nameof(ValidXmlTestCases))]
    public void ParseFromXml_ShouldProcessAllXml(string xml)
    {
        var settings = new ParserSettings(LocalFileLoadBehaviour.Skip);
        var gldfParser = new GldfParser(settings);
        var rootTyped = gldfParser.ParseFromXml(xml, out _);
        rootTyped.Should().NotBeNull();
    }

    [Test, TestCaseSource(nameof(ValidXmlTestCases))]
    public void ParseFromXmlStream_ShouldProcessAllXml(string xml)
    {
        using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
        var settings = new ParserSettings(LocalFileLoadBehaviour.Skip);
        var gldfParser = new GldfParser(settings);
        var rootTyped = gldfParser.ParseFromXmlStream(memoryStream, false, out _);
        rootTyped.Should().NotBeNull();
    }

    [Test, TestCaseSource(nameof(ValidXmlTestCases))]
    public void ParseFromXmlFile_ShouldProcessAllXml(string xml)
    {
        File.WriteAllText(_tempGldfPath, xml);
        var settings = new ParserSettings(LocalFileLoadBehaviour.Skip);
        var gldfParser = new GldfParser(settings);
        var rootTyped = gldfParser.ParseFromXmlFile(_tempGldfPath, out _);
        rootTyped.Should().NotBeNull();
    }

    [Test, TestCaseSource(nameof(ValidGldfTestCases))]
    public void ParseFromRoot_ShouldProcessAllGldfs(byte[] gldf)
    {
        using var memoryStream = new MemoryStream(gldf);
        var container = new GldfContainerReader().ReadFromGldfStream(memoryStream, false);
        var settings = new ParserSettings(LocalFileLoadBehaviour.Skip);
        var gldfParser = new GldfParser(settings);
        var rootTyped = gldfParser.ParseFromRoot(container.Product, out _);
        rootTyped.Should().NotBeNull();
    }

    [Test, TestCaseSource(nameof(ValidGldfTestCases))]
    public void ParseFromGldf_ShouldProcessAllGldfs(byte[] gldf)
    {
        using var memoryStream = new MemoryStream(gldf);
        var container = new GldfContainerReader().ReadFromGldfStream(memoryStream, false);
        var settings = new ParserSettings(LocalFileLoadBehaviour.Skip);
        var gldfParser = new GldfParser(settings);
        var rootTyped = gldfParser.ParseFromGldf(container, out _);
        rootTyped.Should().NotBeNull();
    }

    [Test, TestCaseSource(nameof(ValidGldfTestCases))]
    public void ParseFromGldfFile_ShouldProcessAllGldfs(byte[] gldf)
    {
        File.WriteAllBytes(_tempGldfPath, gldf);
        var settings = new ParserSettings(LocalFileLoadBehaviour.Skip);
        var gldfParser = new GldfParser(settings);
        var rootTyped = gldfParser.ParseFromGldfFile(_tempGldfPath, out _);
        rootTyped.Should().NotBeNull();
    }

    [Test, TestCaseSource(nameof(ValidGldfTestCases))]
    public void ParseFromGldfStream_ShouldProcessAllGldfs(byte[] gldf)
    {
        using var memoryStream = new MemoryStream(gldf);
        var settings = new ParserSettings(LocalFileLoadBehaviour.Skip);
        var gldfParser = new GldfParser(settings);
        var rootTyped = gldfParser.ParseFromGldfStream(memoryStream, false, out _);
        rootTyped.Should().NotBeNull();
    }

    [Test]
    public void ParseFromXml_ShouldReturnExpected()
    {
        var xml = EmbeddedXmlTestData.GetHeaderMandatoryXml();
        var expected = EmbeddedXmlTestData.GetHeaderMandatoryTyped();
        var gldfParser = new GldfParser();
        var rootTyped = gldfParser.ParseFromXml(xml, out _);
        rootTyped.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ParseFromXmlFile_ShouldReturnExpected()
    {
        var xml = EmbeddedXmlTestData.GetHeaderMandatoryXml();
        var expected = EmbeddedXmlTestData.GetHeaderMandatoryTyped();
        File.WriteAllText(_tempGldfPath, xml);
        var gldfParser = new GldfParser();
        var rootTyped = gldfParser.ParseFromXmlFile(_tempGldfPath, out _);
        rootTyped.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ParseFromXmlStream_ShouldReturnExpected()
    {
        var xml = EmbeddedXmlTestData.GetHeaderMandatoryXml();
        var expected = EmbeddedXmlTestData.GetHeaderMandatoryTyped();
        using var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
        var gldfParser = new GldfParser();
        var rootTyped = gldfParser.ParseFromXmlStream(memoryStream, false, out _);
        rootTyped.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ParseFromRoot_ShouldReturnExpected()
    {
        var root = EmbeddedXmlTestData.GetHeaderMandatoryModel();
        var expected = EmbeddedXmlTestData.GetHeaderMandatoryTyped();
        var gldfParser = new GldfParser();
        var rootTyped = gldfParser.ParseFromRoot(root, out _);
        rootTyped.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ParseFromGldf_ShouldReturnExpected()
    {
        var root = EmbeddedXmlTestData.GetHeaderMandatoryModel();
        var expected = EmbeddedXmlTestData.GetHeaderMandatoryTyped();
        var gldfParser = new GldfParser();
        var rootTyped = gldfParser.ParseFromGldf(new GldfContainer(root), out _);
        rootTyped.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ParseFromGldfFile_ShouldReturnExpected()
    {
        var root = EmbeddedXmlTestData.GetHeaderMandatoryModel();
        var gldfContainer = new GldfContainer(root);
        new GldfContainerWriter().WriteToGldfFile(_tempGldfPath, gldfContainer);
        var expected = EmbeddedXmlTestData.GetHeaderMandatoryTyped();
        var gldfParser = new GldfParser();
        var rootTyped = gldfParser.ParseFromGldfFile(_tempGldfPath, out _);
        rootTyped.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void ParseFromGldfStream_ShouldReturnExpected()
    {
        var root = EmbeddedXmlTestData.GetHeaderMandatoryModel();
        var gldfContainer = new GldfContainer(root);
        using var memoryStream = new MemoryStream();
        new GldfContainerWriter().WriteToGldfStream(memoryStream, true, gldfContainer);
        var expected = EmbeddedXmlTestData.GetHeaderMandatoryTyped();
        var gldfParser = new GldfParser();
        memoryStream.Seek(0, SeekOrigin.Begin);
        var rootTyped = gldfParser.ParseFromGldfStream(memoryStream, false, out _);
        rootTyped.Should().BeEquivalentTo(expected);
    }
}