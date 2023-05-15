using Gldf.Net.Domain.Xml.Head.Types;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace Gldf.Net.XmlHelper;

public static class GldfXmlSchemaFactory
{
    public static XmlSchemaSet GetEmbeddedXmlSchema(string xml) =>
        GetEmbeddedXmlSchema(GldfFormatVersionReader.GetFromXml(xml));

    public static XmlSchemaSet GetEmbeddedXmlSchema(FormatVersion formatVersion) =>
        CreateXmlSchema(GldfEmbeddedXsdLoader.Load(formatVersion));

    public static XmlSchemaSet CreateXmlSchema(string xsd)
    {
        using var xsdStringReader = new StringReader(xsd);
        using var schemaDoc = XmlReader.Create(xsdStringReader);
        var schemaSet = new XmlSchemaSet();
        schemaSet.Add(string.Empty, schemaDoc);
        return schemaSet;
    }
}