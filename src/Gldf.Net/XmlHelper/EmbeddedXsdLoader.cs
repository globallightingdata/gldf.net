using Gldf.Net.Domain.Xml.Head.Types;
using Gldf.Net.Exceptions;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Gldf.Net.XmlHelper;

internal static class EmbeddedXsdLoader
{
    public static string LoadXsd(FormatVersion version)
    {
        try
        {
            var preRealeaseString = version.PreReleaseSpecified ? $"-rc{version.PreRelease}" : string.Empty;
            var versionString = $"v{version.Major}{version.Minor}{preRealeaseString}";
            var xsdResourceName = $"Gldf.Net.Xsd.{versionString}.xsd";
            var currentAssembly = Assembly.GetAssembly(typeof(GldfXmlSerializer));
            using var xsdResource = currentAssembly!.GetManifestResourceStream(xsdResourceName);
            using var reader = new StreamReader(xsdResource!, Encoding.UTF8);
            return reader.ReadToEnd();
        }
        catch (Exception e)
        {
            var errorMessage = $"Failed to get embedded XSD for {nameof(FormatVersion)}{version}";
            throw new GldfException(errorMessage, e);
        }
    }
}