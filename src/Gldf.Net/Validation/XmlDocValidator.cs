using Gldf.Net.Domain.Head.Types;
using Gldf.Net.XmlHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Gldf.Net.Validation
{
    internal class XmlDocValidator
    {
        public List<ValidationHint> ValidateString(string xml)
        {
            var stringReader = new StringReader(xml);
            var xmlFormatVersion = GldfFormatVersionReader.GetFormatVersion(xml);
            var schemaSet = CreateSchemaSet(xmlFormatVersion);
            return ValidateWithSchemaSet(stringReader, schemaSet);
        }

        protected List<ValidationHint> ValidateWithSchemaSet(TextReader textReader, XmlSchemaSet schemaSet)
        {
            var resultList = new List<ValidationHint>();

            void SchemaErrorHandler(object _, ValidationEventArgs e)
                => resultList.Add(new ValidationHint(MapSeverityType(e.Severity), e.Message, ErrorType.XmlSchema));

            static SeverityType MapSeverityType(XmlSeverityType xmlSeverityType) =>
                xmlSeverityType == XmlSeverityType.Warning ? SeverityType.Warning : SeverityType.Error;

            try
            {
                var xmlDoc = XDocument.Load(textReader);
                xmlDoc.Validate(schemaSet, SchemaErrorHandler);
            }
            catch (Exception e)
            {
                var validationHint = new ValidationHint(SeverityType.Error, e.Message, ErrorType.XmlSchema);
                resultList.Add(validationHint);
            }
            return resultList;
        }

        private XmlSchemaSet CreateSchemaSet(FormatVersion xmlFormatVersion)
        {
            var embeddedXsd = EmbeddedXsdLoader.LoadXsd(xmlFormatVersion);
            var xsdStringReader = new StringReader(embeddedXsd);
            var schemaDoc = XmlReader.Create(xsdStringReader);
            var schemaSet = new XmlSchemaSet();
            schemaSet.Add(string.Empty, schemaDoc);
            return schemaSet;
        }
    }
}