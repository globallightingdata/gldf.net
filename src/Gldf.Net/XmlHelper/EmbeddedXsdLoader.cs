using Gldf.Net.Domain.Xml.Head.Types;
using Gldf.Net.Exceptions;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Gldf.Net.XmlHelper
{
    internal static class EmbeddedXsdLoader
    {
        public static string LoadXsd(FormatVersion version)
        {
            try
            {
                var xsdResourceName = $"Gldf.Net.Xsd.{version}.xsd";
                var currentAssembly = Assembly.GetAssembly(typeof(GldfXmlSerializer));
                using var xsdResource = currentAssembly.GetManifestResourceStream(xsdResourceName);
                using var reader = new StreamReader(xsdResource!, Encoding.UTF8);
                return reader.ReadToEnd();
            }
            catch (Exception e)
            {
                var errorMessage = $"Failed to get embedded XSD for {nameof(FormatVersion)}{version.ToString()}";
                throw new GldfException(errorMessage, e);
            }
        }
    }
}