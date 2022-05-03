using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public class FixedLightSourceReference
    {
        [XmlAttribute(DataType = "NCName", AttributeName = "fixedLightSourceId")]
        public string FixedLightSourceId { get; set; }
    }
}