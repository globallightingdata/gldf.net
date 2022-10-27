using FluentAssertions;
using Gldf.Net.Exceptions;
using Gldf.Net.XmlHelper;
using NUnit.Framework;
using System;
using System.Xml;

namespace Gldf.Net.Tests.XmlHelperTests
{
    [TestFixture]
    public class XmlFormatVersionReaderTests
    {
        [Test]
        public void GetFormatVersion_Should_BeExpected()
        {
            const string expected = "1.0.0-rc.1";
            const string xml = $"<Root><Header><FormatVersion>{expected}</FormatVersion></Header></Root>";

            var formatVersion = GldfFormatVersionReader.GetFormatVersion(xml);

            formatVersion.Should().Be(expected);
        }

        [Test]
        public void GetFormatVersion_Should_Throw_When_InvalidXml()
        {
            const string xml = "notValidXml";

            Action act = () => GldfFormatVersionReader.GetFormatVersion(xml);

            act.Should()
                .ThrowExactly<GldfException>()
                .WithMessage("Failed to get FormatVersion. See inner expcetion")
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
                .WithMessage("Failed to get FormatVersion. See inner expcetion")
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
                .WithMessage("Failed to get FormatVersion. See inner expcetion");
        }
    }
}