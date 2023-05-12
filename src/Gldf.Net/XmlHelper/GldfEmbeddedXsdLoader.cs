using Gldf.Net.Domain.Xml.Head.Types;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Gldf.Net.XmlHelper;

public static class GldfEmbeddedXsdLoader
{
    public static IEnumerable<FormatVersion> KnownVersions => new List<FormatVersion>
    {
        new(0, 9, 9),
        new(1, 0, 1),
        new(1, 0, 2)
    };

    public static string Load(FormatVersion version)
    {
        var schemaVersionToLoad = KnownVersions.Any(toCompare => toCompare.CompareTo(version) == 0)
            ? version
            : KnownVersions.Max();
        return ReadResourceFromAssembly(schemaVersionToLoad);
    }

    private static string ReadResourceFromAssembly(FormatVersion version)
    {
        var xsdResourceName = $"Gldf.Net.Xsd.{version}.xsd";
        var currentAssembly = Assembly.GetAssembly(typeof(GldfXmlSerializer));
        using var xsdResource = currentAssembly!.GetManifestResourceStream(xsdResourceName);
        using var reader = new StreamReader(xsdResource!, Encoding.UTF8);
        return reader.ReadToEnd();
    }
}