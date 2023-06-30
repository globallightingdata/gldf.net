using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition.Types;

public class MultiChannelLightSourceReference
{
    [XmlAttribute(DataType = "NCName", AttributeName = "multiChannelLightSourceId")]
    public string MultiChannelLightSourceId { get; set; }
}