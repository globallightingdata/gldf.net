using Gldf.Net.Validation.Model;
using Gldf.Net.XmlHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Gldf.Net.Validation;

internal class GldfXmlSchemaValidator
{
    private readonly Encoding _encoding;
    private readonly XmlSchemaSet _xmlSchema;

    public GldfXmlSchemaValidator() : this(Encoding.UTF8)
    {
    }

    public GldfXmlSchemaValidator(Encoding encoding)
    {
        _encoding = encoding;
    }
    
    public GldfXmlSchemaValidator(XmlSchemaSet xmlSchema) : this()
    {
        _xmlSchema = xmlSchema;
    }
    
    public GldfXmlSchemaValidator(Encoding encoding, XmlSchemaSet xmlSchema)
    {
        _encoding = encoding;
        _xmlSchema = xmlSchema;
    }

    public IEnumerable<ValidationHint> ValidateXml(string xml)
    {
        using var stringReader = new StringReader(xml);
        var xmlSchema = _xmlSchema ?? GldfXmlSchemaFactory.GetEmbeddedXmlSchema(xml);
        return Validate(stringReader, xmlSchema);
    }

    public IEnumerable<ValidationHint> ValidateXmlFile(string xmlFilePath)
    {
        var xml = File.ReadAllText(xmlFilePath, _encoding);
        return ValidateXml(xml);
    }

    public IEnumerable<ValidationHint> ValidateXmlStream(Stream stream, bool leaveOpen)
    {
        using var streamReader = new StreamReader(stream, _encoding, leaveOpen: leaveOpen);
        var xml = streamReader.ReadToEnd();
        return ValidateXml(xml);
    }

    protected static IEnumerable<ValidationHint> Validate(TextReader reader, XmlSchemaSet xmlSchema)
    {
        var resultList = new List<ValidationHint>();

        void SchemaErrorHandler(object _, ValidationEventArgs e)
            => resultList.Add(new ValidationHint(MapSeverityType(e.Severity), e.Message, ErrorType.XmlSchema));

        try
        {
            var xmlDoc = XDocument.Load(reader);
            xmlDoc.Validate(xmlSchema, SchemaErrorHandler);
        }
        catch (Exception e)
        {
            var validationHint = new ValidationHint(SeverityType.Error, e.Message, ErrorType.XmlSchema);
            resultList.Add(validationHint);
        }
        return resultList;
    }

    private static SeverityType MapSeverityType(XmlSeverityType xmlSeverityType) =>
        xmlSeverityType == XmlSeverityType.Warning ? SeverityType.Warning : SeverityType.Error;
}