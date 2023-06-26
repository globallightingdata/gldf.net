using FluentAssertions;
using Gldf.Net.Domain.Xml.Head.Types;
using Gldf.Net.Exceptions;
using Gldf.Net.Tests.TestData;
using Gldf.Net.XmlHelper;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using System.Xml;

namespace Gldf.Net.Tests.XmlHelperTests;

[TestFixture]
public class GldfFormatVersionReaderTests
{
    [Test]
    public void GetFromXml_ShouldBeExpected_WhenPreReleaseIsSet()
    {
        var expected = new FormatVersion { Major = 1, Minor = 2, PreRelease = 3 };
        const string xml = "<Root><Header><FormatVersion major='1' minor='2' pre-release='3' /></Header></Root>";

        var formatVersion = GldfFormatVersionReader.GetFromXml(xml);

        formatVersion.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void GetFormatVersion_ShouldBeExpected_WhenPreReleaseIsMissing()
    {
        var expected = new FormatVersion { Major = 1, Minor = 2, PreReleaseSpecified = false };
        const string xml = "<Root><Header><FormatVersion major='1' minor='2' /></Header></Root>";

        var formatVersion = GldfFormatVersionReader.GetFromXml(xml);

        formatVersion.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void GetFromXml_ShouldThrow_WhenInvalidXml()
    {
        const string xml = "notValidXml";

        Action act = () => GldfFormatVersionReader.GetFromXml(xml);

        act.Should()
            .ThrowExactly<GldfException>()
            .WithMessage("Failed to get FormatVersion from XML. See inner exception")
            .WithInnerException<Exception>()
            .WithMessage("Data at the root level is invalid. Line 1, position 1.");
    }

    [Test]
    public void GetFromXml_ShouldThrow_WhenMissingFormatElement()
    {
        const string xml = "<Root><Header></Header></Root>";

        Action act = () => GldfFormatVersionReader.GetFromXml(xml);

        act.Should()
            .ThrowExactly<GldfException>()
            .WithMessage("Failed to get FormatVersion from XML. See inner exception")
            .WithInnerExceptionExactly<XmlException>()
            .WithMessage("Path Root/Header/FormatVersion not found");
    }

    [TestCase("<Root><Header><FormatVersion major='1' /></Header></Root>")]
    [TestCase("<Root><Header><FormatVersion major='1' pre-release='1' /></Header></Root>")]
    [TestCase("<Root><Header><FormatVersion minor='1' /></Header></Root>")]
    [TestCase("<Root><Header><FormatVersion minor='1' pre-release='1' /></Header></Root>")]
    [TestCase("<Root><Header><FormatVersion pre-release='1' /></Header></Root>")]
    public void GetFromXml_ShouldThrow_WhenInvalidVersion(string xml)
    {
        Action act = () => GldfFormatVersionReader.GetFromXml(xml);

        act.Should()
            .ThrowExactly<GldfException>()
            .WithMessage("Failed to get FormatVersion from XML. See inner exception")
            .WithInnerExceptionExactly<XmlException>()
            .WithMessage("FormatVersion attributes missing*");
    }

    [Test]
    public void GetFromXmlFile_ShouldReturnExpected()
    {
        const string xml = "<Root><Header><FormatVersion major='1' minor='2' pre-release='3' /></Header></Root>";
        var expected = new FormatVersion { Major = 1, Minor = 2, PreRelease = 3 };
        var tempFileName = Path.GetTempFileName();
        File.WriteAllText(tempFileName, xml);

        var formatVersion = GldfFormatVersionReader.GetFromXmlFile(tempFileName);

        formatVersion.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void GetFromXmlFile_ShouldReturnExpected_WhenEncodingIsSet()
    {
        const string xml = "<Root><Header><FormatVersion major='1' minor='2' pre-release='3' /></Header></Root>";
        var expected = new FormatVersion { Major = 1, Minor = 2, PreRelease = 3 };
        var tempFileName = Path.GetTempFileName();
        var encoding = Encoding.ASCII;
        File.WriteAllText(tempFileName, xml, encoding);

        var formatVersion = GldfFormatVersionReader.GetFromXmlFile(tempFileName, Encoding.ASCII);

        formatVersion.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void GetFromXmlFile_ShouldThrow_WhenInvalidXml()
    {
        const string xml = "notValidXml";
        var tempFileName = Path.GetTempFileName();
        File.WriteAllText(tempFileName, xml);

        Action act = () => GldfFormatVersionReader.GetFromXmlFile(tempFileName);

        act.Should()
            .ThrowExactly<GldfException>()
            .WithMessage("Failed to get FormatVersion from XML file. See inner exception");
    }

    [Test]
    public void GetFromGldfFile_ShouldReturnExpected()
    {
        var gldf = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
        var expected = new FormatVersion { Major = 1, Minor = 0, PreRelease = 3 };
        var tempFileName = Path.GetTempFileName();
        File.WriteAllBytes(tempFileName, gldf);

        var formatVersion = GldfFormatVersionReader.GetFromGldfFile(tempFileName);

        formatVersion.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void GetFromGldfFile_ShouldThrow_WhenInvalidGldf()
    {
        var tempFileName = Path.GetTempFileName();
        Action act = () => GldfFormatVersionReader.GetFromGldfFile(tempFileName);
        act.Should()
            .ThrowExactly<GldfException>()
            .WithMessage("Failed to get FormatVersion from GLDF file. See inner exception");
    }

    [Test]
    public void GetFromGldfStream_ShouldReturnExpected()
    {
        var gldf = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
        using var memoryStream = new MemoryStream(gldf);
        var expected = new FormatVersion { Major = 1, Minor = 0, PreRelease = 3 };

        var formatVersion = GldfFormatVersionReader.GetFromGldfStream(memoryStream, false);

        formatVersion.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void GetFromGldfStream_SShouldThrow_WhenInvalidGldfStream()
    {
        var act = () =>
        {
            using var memoryStream = new MemoryStream();
            GldfFormatVersionReader.GetFromGldfStream(memoryStream, false);
        };
        act.Should()
            .ThrowExactly<GldfException>()
            .WithMessage("Failed to get FormatVersion from GLDF stream. See inner exception");
    }
}