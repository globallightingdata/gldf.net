using System.Xml.Serialization;

namespace Gldf.Net.Domain.Product.Types
{
    public class SimpleGeometryReference : EmitterReferenceBase
    {
        [XmlAttribute(DataType = "NCName", AttributeName = "geometryId")]
        public string GeometryId { get; set; }

        [XmlAttribute(DataType = "NCName", AttributeName = "emitterId")]
        public string EmitterId { get; set; }
    }
}