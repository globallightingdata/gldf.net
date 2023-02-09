using FluentAssertions;
using Gldf.Net.Parser;
using Gldf.Net.Tests.TestData;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace Gldf.Net.Tests.ParserTests;

[TestFixture]
public class GldfParserTests
{
    private string _tempGldfPath;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _tempGldfPath = Path.GetTempFileName();
        var gldfBytes = EmbeddedGldfTestData.GetGldfWithFilesComplete();
        File.WriteAllBytes(_tempGldfPath, gldfBytes);
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        File.Delete(_tempGldfPath);
    }

    [Test]
    public void ParseFromContainerFile_ShouldReturnNotNull()
    {
        var gldfParser = new GldfParser(new ParserSettings
        {
            LocalFileLoadBehaviour = LocalFileLoadBehaviour.Load,
            OnlineFileLoadBehaviour = OnlineFileLoadBehaviour.Load,
            HttpClient = new HttpClient { Timeout = TimeSpan.FromMilliseconds(10) }
        });

        var rootTyped = gldfParser.ParseFromContainerFile(_tempGldfPath);
        rootTyped.Should().NotBeNull();
    }

    [Test]
    public void ParseFromXml_ShouldReturnNotNull()
    {
        var gldf = EmbeddedXmlTestData.GetChangeableCompleteXml();
        var gldfParser = new GldfParser(new ParserSettings
        {
            LocalFileLoadBehaviour = LocalFileLoadBehaviour.Load,
            OnlineFileLoadBehaviour = OnlineFileLoadBehaviour.Load
        });

        var rootTyped = gldfParser.ParseFromXml(gldf);
        rootTyped.Should().NotBeNull();
    }

    [Test, Explicit]
    public void ParseFromContainerFile_ShouldHaveExpectedHash()
    {
        var gldfParser = new GldfParser(new ParserSettings
        {
            LocalFileLoadBehaviour = LocalFileLoadBehaviour.Skip,
            OnlineFileLoadBehaviour = OnlineFileLoadBehaviour.Skip
        });
        var rootTyped = gldfParser.ParseFromContainerFile(_tempGldfPath);
        
        // Quick test to identify errors for now, todo replace test assert with meaningful validation
        var jsonSettings = new JsonSerializerSettings { Converters = new List<JsonConverter> { new StringEnumConverter() }};
        var rootTypeJson = JsonConvert.SerializeObject(rootTyped, Formatting.Indented, jsonSettings);
        Console.WriteLine(rootTypeJson);
        var hashData = MD5.HashData(Encoding.UTF8.GetBytes(rootTypeJson));
        Convert.ToBase64String(hashData).Should().Be("zwNoQs/8SGjZqA4OZLiwyg==");
    }
}