using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition.Types;

public class FixedLightSourceReference
{
    [XmlAttribute(DataType = "NCName", AttributeName = "fixedLightSourceId")]
    public string FixedLightSourceId { get; set; }
}