using FluentAssertions;
using Gldf.Net.Domain.Xml;
using Gldf.Net.Domain.Xml.Head.Types;
using Gldf.Net.Tests.TestHelper;
using Gldf.Net.XmlHelper;
using NUnit.Framework;
using System.Collections.Generic;
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
        GldfEmbeddedXsdLoader.KnownVersions.Should().HaveCount(3);
        foreach (var knownVersion in GldfEmbeddedXsdLoader.KnownVersions)
        {
            var xsd = GldfEmbeddedXsdLoader.Load(knownVersion);
            const string expectedXsdRow = @"<?xml version=""1.0"" encoding=""UTF-8""?>";
            xsd.Should().StartWith(expectedXsdRow);
        }
    }

    [Test, TestCaseSource(nameof(ExpectedXsdTestData))]
    public void LoadXsd_ShouldLoadExpectedXsds(FormatVersion version, string expectedXsdVersion)
    {
        var xsd = GldfEmbeddedXsdLoader.Load(version);
        xsd.Should().Contain(expectedXsdVersion);
    }

    [Test]
    public async Task LoadXsd_ShouldBeEquivalentTo_NewestVersionOnline_WhenLoadMaxVersion()
    {
        using var httpClient = new HttpClient();
        var newestEmbeddedVersion = GldfEmbeddedXsdLoader.KnownVersions.Max();
        var newestEmbeddedXsd = GldfEmbeddedXsdLoader.Load(newestEmbeddedVersion);
        var xsdSchemaLocation = new Root().SchemaLocation;
        var xsdSchemaOnline = await httpClient.GetStringAsync(xsdSchemaLocation);
        newestEmbeddedXsd.ShouldBe().EquivalentTo(xsdSchemaOnline);
    }

    [Test]
    public void LoadXsd_ShouldLoadNewest_WhenUnknownFormatVersion()
    {
        var invalidFormatVersion = new FormatVersion(-1, -2, -3);
        var xsd = GldfEmbeddedXsdLoader.Load(invalidFormatVersion);
        xsd.Should().Contain(@"version=""1.0.0-rc.2""");
    }

    private static IEnumerable<TestCaseData> ExpectedXsdTestData => new[]
    {
        new TestCaseData(new FormatVersion(0, 9, 9), @"version=""0.9-beta.9"""),
        new TestCaseData(new FormatVersion(1, 0, 1), @"version=""1.0.0-rc.1"""),
        new TestCaseData(new FormatVersion(1, 0, 2), @"version=""1.0.0-rc.2""")
    };
}