using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.MetaInfo;

public class Property
{
    [XmlAttribute(DataType = "string", AttributeName = "name")]
    public string Name { get; set; }

    [XmlText]
    public string Content { get; set; }
}