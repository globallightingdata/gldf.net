using Gldf.Net.Domain.Definition;
using Gldf.Net.Domain.Head;
using Gldf.Net.Domain.Product;
using System.Xml.Serialization;

namespace Gldf.Net.Domain
{
    public class Root
    {
        [XmlAttribute(AttributeName = SchemaAttributeName, Namespace = SchemaAttributePrefixNamespace)]
        public string SchemaLocation
        {
            get => "https://gldf.io/xsd/gldf/1.0.0-rc.1/gldf.xsd";
            set => _ = value;
        }

        public Header Header { get; set; }

        public GeneralDefinitions GeneralDefinitions { get; set; }

        public ProductDefinitions ProductDefinitions { get; set; }

        private const string SchemaAttributeName = "noNamespaceSchemaLocation";
        private const string SchemaAttributePrefixNamespace = "http://www.w3.org/2001/XMLSchema-instance";
    }
}