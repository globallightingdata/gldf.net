using Gldf.Net.Domain.Xml.Head.Types;
using Gldf.Net.Validation.Model;
using Gldf.Net.XmlHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Gldf.Net.Validation;

internal class GldfXmlSchemaValidator
{
    public IEnumerable<ValidationHint> ValidateXml(string xml)
    {
        using var stringReader = new StringReader(xml);
        var schemaSet = GetSchema(xml);
        return Validate(stringReader, schemaSet);
    }

    public IEnumerable<ValidationHint> ValidateXmlFile(string xmlFilePath)
    {
        var xml = File.ReadAllText(xmlFilePath);
        return ValidateXml(xml);
    }

    protected static IEnumerable<ValidationHint> Validate(TextReader reader, XmlSchemaSet schema)
    {
        var resultList = new List<ValidationHint>();
        void SchemaErrorHandler(object _, ValidationEventArgs e)
            => resultList.Add(new ValidationHint(MapSeverityType(e.Severity), e.Message, ErrorType.XmlSchema));

        try
        {
            var xmlDoc = XDocument.Load(reader);
            xmlDoc.Validate(schema, SchemaErrorHandler);
        }
        catch (Exception e)
        {
            var validationHint = new ValidationHint(SeverityType.Error, e.Message, ErrorType.XmlSchema);
            resultList.Add(validationHint);
        }
        return resultList;
    }

    private static XmlSchemaSet GetSchema(string xml)
    {
        var formatVersion = GldfFormatVersionReader.Get(xml);
        var schemaSet = CreateSchemaSet(formatVersion);
        return schemaSet;
    }

    private static XmlSchemaSet CreateSchemaSet(FormatVersion formatVersion)
    {
        var embeddedXsd = GldfEmbeddedXsdLoader.Load(formatVersion);
        using var xsdStringReader = new StringReader(embeddedXsd);
        using var schemaDoc = XmlReader.Create(xsdStringReader);
        var schemaSet = new XmlSchemaSet();
        schemaSet.Add(string.Empty, schemaDoc);
        return schemaSet;
    }

    private static SeverityType MapSeverityType(XmlSeverityType xmlSeverityType) =>
        xmlSeverityType == XmlSeverityType.Warning ? SeverityType.Warning : SeverityType.Error;
}