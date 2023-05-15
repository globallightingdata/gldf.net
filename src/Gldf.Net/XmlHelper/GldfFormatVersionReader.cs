using Gldf.Net.Container;
using Gldf.Net.Domain.Xml.Head.Types;
using Gldf.Net.Exceptions;
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Gldf.Net.XmlHelper;

public static class GldfFormatVersionReader
{
    public static FormatVersion GetFromXml(string xml)
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
            throw new GldfException("Failed to get FormatVersion from XML. See inner exception", e);
        }
    }

    public static FormatVersion GetFromXmlFile(string xmlFilePath) =>
        GetFromXmlFile(xmlFilePath, Encoding.UTF8);

    public static FormatVersion GetFromXmlFile(string xmlFilePath, Encoding encoding)
    {
        try
        {
            var xml = File.ReadAllText(xmlFilePath, encoding);
            return GetFromXml(xml);
        }
        catch (Exception e)
        {
            throw new GldfException("Failed to get FormatVersion from XML file. See inner exception", e);
        }
    }

    public static FormatVersion GetFromGldfFile(string gldfFilePath) =>
        GetFromGldfFile(gldfFilePath, Encoding.UTF8);

    public static FormatVersion GetFromGldfFile(string gldfFilePath, Encoding encoding)
    {
        try
        {
            var xml = new ZipArchiveReader(encoding).ReadRootXml(gldfFilePath);
            return GetFromXml(xml);
        }
        catch (Exception e)
        {
            throw new GldfException("Failed to get FormatVersion from GLDF file. See inner exception", e);
        }
    }

    public static FormatVersion GetFromGldfStream(Stream gldfStream, bool leaveOpen) =>
        GetFromGldfStream(gldfStream, leaveOpen, Encoding.UTF8);

    public static FormatVersion GetFromGldfStream(Stream gldfStream, bool leaveOpen, Encoding encoding)
    {
        try
        {
            var xml = new ZipArchiveReader(encoding).ReadRootXml(gldfStream, leaveOpen);
            return GetFromXml(xml);
        }
        catch (Exception e)
        {
            throw new GldfException("Failed to get FormatVersion from GLDF stream. See inner exception", e);
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