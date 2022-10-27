using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Product.Types
{
    public class ModelGeometryReference : GeometryReferenceBase
    {
        [XmlAttribute(DataType = "NCName", AttributeName = "geometryId")]
        public string GeometryId { get; set; }

        [XmlElement("EmitterReference")]
        public GeometryEmitterReference[] EmitterReferences { get; set; }
    }
}