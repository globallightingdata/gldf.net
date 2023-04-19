using FluentAssertions;
using Gldf.Net.Domain.Xml;
using Gldf.Net.Domain.Xml.Head.Types;
using Gldf.Net.Exceptions;
using Gldf.Net.Tests.TestHelper;
using Gldf.Net.XmlHelper;
using NUnit.Framework;
using System;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace Gldf.Net.Tests.XmlHelperTests;

[TestFixture]
public class GldfEmbeddedXsdLoaderTests
{
    [Test]
    public void KnownVersions_ShouldContainAllEmbeddedXsds()
    {
        var gldfAssembly = Assembly.GetAssembly(typeof(GldfEmbeddedXsdLoader));
        var resourceNames = gldfAssembly!.GetManifestResourceNames();
        var xsdResources = resourceNames
            .Where(res => res.StartsWith("Gldf.Net.Xsd"))
            .Select(res => res[13..^4])
            .OrderBy(val => val);
        var knownVersion = GldfEmbeddedXsdLoader.KnownVersions
            .Select(versin => versin.ToString())
            .OrderBy(val => val);
        knownVersion.Should().BeEquivalentTo(xsdResources);
    }

    [Test]
    public void LoadXsd_ShouldLoadAllKnownVersions()
    {
        foreach (var knownVersion in GldfEmbeddedXsdLoader.KnownVersions)
        {
            var xsd = GldfEmbeddedXsdLoader.LoadXsd(knownVersion);
            const string expectedXsdRow = @"<?xml version=""1.0"" encoding=""UTF-8""?>";
            xsd.Should().StartWith(expectedXsdRow);
        }
    }

    [Test]
    public async Task LoadXsd_ShouldBeEquivalentTo_XsdStoredOnGldfIo()
    {
        var formatVersion = new FormatVersion { Major = 1, Minor = 0, PreRelease = 2 };
        using var httpClient = new HttpClient();
        var xsdSchemaLocation = new Root().SchemaLocation;
        var xsdSchema = await httpClient.GetStringAsync(xsdSchemaLocation);
        var embeddedXsd = GldfEmbeddedXsdLoader.LoadXsd(formatVersion);

        embeddedXsd.ShouldBe().EquivalentTo(xsdSchema);
    }

    [Test]
    public void LoadXsd_ShouldThrow_WhenUnknownFormatVersion()
    {
        var invalidFormatVersion = new FormatVersion { Major = -1, Minor = -2, PreRelease = -3 };
        Action act = () => GldfEmbeddedXsdLoader.LoadXsd(invalidFormatVersion);
        act.Should().Throw<GldfException>().WithMessage("Failed to get embedded XSD*");
    }
}