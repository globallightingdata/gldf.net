using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Domain.Xml.Head;
using Gldf.Net.Domain.Xml.Product;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml;

public class Root
{
    [XmlAttribute(AttributeName = SchemaAttributeName, Namespace = SchemaAttributePrefixNamespace)]
    public string SchemaLocation
    {
        get => "https://gldf.io/xsd/gldf/1.0.0-rc.2/gldf.xsd";
        set => _ = value;
    }

    public Header Header { get; set; }

    public GeneralDefinitions GeneralDefinitions { get; set; }

    public ProductDefinitions ProductDefinitions { get; set; }

    private const string SchemaAttributeName = "noNamespaceSchemaLocation";
    private const string SchemaAttributePrefixNamespace = "http://www.w3.org/2001/XMLSchema-instance";
}