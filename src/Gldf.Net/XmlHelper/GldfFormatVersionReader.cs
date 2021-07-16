using Gldf.Net.Domain.Head.Types;
using Gldf.Net.Exceptions;
using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Gldf.Net.XmlHelper
{
    internal static class GldfFormatVersionReader
    {
        public static FormatVersion GetFormatVersion(string xml)
        {
            var formatElement = GetFormatElement(xml);
            return ParseToFormatVersion(formatElement);
        }

        private static XElement GetFormatElement(string xml)
        {
            try
            {
                var document = XDocument.Load(new StringReader(xml));
                var formatElement = document.XPathSelectElement("Root/Header/FormatVersion");
                return formatElement ?? throw new XmlException("Path Root/Header/FormatVersion not found");
            }
            catch (Exception e)
            {
                throw new GldfException("Failed to get FormatVersion XML element", e);
            }
        }

        private static FormatVersion ParseToFormatVersion(XElement formatElement)
        {
            try
            {
                var formatValue = $"V{formatElement!.Value.Replace(".", string.Empty)}";
                return (FormatVersion) Enum.Parse(typeof(FormatVersion), formatValue);
            }
            catch (Exception e)
            {
                throw new GldfException("Failed to parse FormatVersion element", e);
            }
        }
    }
}