using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Product.Types
{
    public class EmitterReference : GeometryReferenceBase
    {
        [XmlAttribute(DataType = "ID", AttributeName = "emitterId")]
        public string EmitterId { get; set; }
    }
}