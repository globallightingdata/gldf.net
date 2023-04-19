using Gldf.Net.Domain.Xml.Head.Types;
using Gldf.Net.Exceptions;
using System;
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

    public static string LoadXsd(FormatVersion version)
    {
        try
        {
            ThrowOnUnknownVersion(version);
            return ReadResourceFromAssembly(version);
        }
        catch (Exception e)
        {
            var errorMessage = $"Failed to get embedded XSD for {nameof(FormatVersion)}{version}";
            throw new GldfException(errorMessage, e);
        }
    }

    private static string ReadResourceFromAssembly(FormatVersion version)
    {
        var xsdResourceName = $"Gldf.Net.Xsd.{version}.xsd";
        var currentAssembly = Assembly.GetAssembly(typeof(GldfXmlSerializer));
        using var xsdResource = currentAssembly!.GetManifestResourceStream(xsdResourceName);
        using var reader = new StreamReader(xsdResource!, Encoding.UTF8);
        return reader.ReadToEnd();
    }

    private static void ThrowOnUnknownVersion(FormatVersion version)
    {
        if (!KnownVersions.Any(toCompare =>
                toCompare.Major == version.Major &&
                toCompare.Minor == version.Minor &&
                toCompare.PreRelease == version.PreRelease &&
                toCompare.PreReleaseSpecified == version.PreReleaseSpecified
            ))
            throw new ArgumentException($"Unknown {nameof(FormatVersion)}");
    }
}