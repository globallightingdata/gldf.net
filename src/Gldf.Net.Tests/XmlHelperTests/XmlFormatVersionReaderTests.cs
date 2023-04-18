using FluentAssertions;
using Gldf.Net.Domain.Xml.Head.Types;
using Gldf.Net.Exceptions;
using Gldf.Net.XmlHelper;
using NUnit.Framework;
using System;
using System.Xml;

namespace Gldf.Net.Tests.XmlHelperTests;

[TestFixture]
public class XmlFormatVersionReaderTests
{

    [Test]
    public void GetFormatVersion_ShouldBeExpected_WhenPreReleaseIsSet()
    {
        var expected = new FormatVersion { Major = 1, Minor = 2, PreRelease = 3 };
        const string xml = "<Root><Header><FormatVersion major='1' minor='2' pre-release='3' /></Header></Root>";

        var formatVersion = GldfFormatVersionReader.GetFormatVersion(xml);

        formatVersion.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void GetFormatVersion_ShouldBeExpected_WhenPreReleaseIsNull()
    {
        var expected = new FormatVersion { Major = 1, Minor = 2, PreReleaseSpecified = false };
        const string xml = "<Root><Header><FormatVersion major='1' minor='2' /></Header></Root>";

        var formatVersion = GldfFormatVersionReader.GetFormatVersion(xml);

        formatVersion.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void GetFormatVersion_Should_Throw_When_InvalidXml()
    {
        const string xml = "notValidXml";

        Action act = () => GldfFormatVersionReader.GetFormatVersion(xml);

        act.Should()
            .ThrowExactly<GldfException>()
            .WithMessage("Failed to get FormatVersion. See inner exception")
            .WithInnerException<Exception>()
            .WithMessage("Data at the root level is invalid. Line 1, position 1.");
    }

    [Test]
    public void GetFormatVersion_Should_Throw_When_MissingFormatElement()
    {
        const string xml = "<Root><Header></Header></Root>";

        Action act = () => GldfFormatVersionReader.GetFormatVersion(xml);

        act.Should()
            .ThrowExactly<GldfException>()
            .WithMessage("Failed to get FormatVersion. See inner exception")
            .WithInnerExceptionExactly<XmlException>()
            .WithMessage("Path Root/Header/FormatVersion not found");
    }

    [Test]
    public void GetFormatVersion_Should_Throw_When_InvalidVersion()
    {
        const string xml = "<Root><Header></Header></Root>";

        Action act = () => GldfFormatVersionReader.GetFormatVersion(xml);

        act.Should()
            .ThrowExactly<GldfException>()
            .WithMessage("Failed to get FormatVersion. See inner exception");
    }
}