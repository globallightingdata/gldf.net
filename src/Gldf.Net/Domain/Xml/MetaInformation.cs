using Gldf.Net.Domain.Xml.MetaInfo;
using System;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml;

public class MetaInformation
{
    [XmlAttribute(AttributeName = SchemaAttributeName, Namespace = SchemaAttributePrefixNamespace)]
    public string SchemaLocation
    {
        get => "https://gldf.io/xsd/meta/1.0.0/meta-information.xsd";
        set => _ = value;
    }

    [XmlElement("Property")]
    public Property[] Properties { get; set; } = Array.Empty<Property>();

    private const string SchemaAttributeName = "noNamespaceSchemaLocation";
    private const string SchemaAttributePrefixNamespace = "http://www.w3.org/2001/XMLSchema-instance";
}