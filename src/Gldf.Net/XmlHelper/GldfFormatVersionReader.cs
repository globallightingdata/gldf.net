using Gldf.Net.Exceptions;
using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Gldf.Net.XmlHelper;

internal static class GldfFormatVersionReader
{
    public static string GetFormatVersion(string xml)
    {
        try
        {
            var formatElement = GetFormatElement(xml);
            return formatElement!.Value;
        }
        catch (Exception e)
        {
            throw new GldfException("Failed to get FormatVersion. See inner expcetion", e);
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