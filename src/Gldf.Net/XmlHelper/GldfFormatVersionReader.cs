using Gldf.Net.Domain.Xml.Head.Types;
using Gldf.Net.Exceptions;
using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Gldf.Net.XmlHelper;

public static class GldfFormatVersionReader
{
    public static FormatVersion Get(string xml)
    {
        try
        {
            var formatElement = GetFormatElement(xml);
            var hasMajor = int.TryParse(formatElement.Attribute("major")?.Value, out var major);
            var hasMinor = int.TryParse(formatElement.Attribute("minor")?.Value, out var minor);
            var hasPreRelease = int.TryParse(formatElement.Attribute("pre-release")?.Value, out var preRelease);
            return (hasMajor, hasMinor, hasPreRelease) switch
            {
                (true, true, true) => new FormatVersion { Major = major, Minor = minor, PreRelease = preRelease },
                (true, true, false) => new FormatVersion { Major = major, Minor = minor },
                _ => throw new XmlException("FormatVersion attributes missing. At least major and minor (:int) required")
            };
        }
        catch (Exception e)
        {
            throw new GldfException("Failed to get FormatVersion. See inner exception", e);
        }
    }

    private static XElement GetFormatElement(string xml)
    {
        using var stringReader = new StringReader(xml);
        var document = XDocument.Load(stringReader);
        var formatElement = document.XPathSelectElement("Root/Header/FormatVersion");
        return formatElement ?? throw new XmlException("Path Root/Header/FormatVersion not found");
    }
}