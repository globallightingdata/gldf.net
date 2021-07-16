using System.Xml.Serialization;

namespace Gldf.Net.Domain.Product.Types
{
    public class GeometryReference : EmissionObjectReference
    {
        [XmlAttribute(DataType = "NCName", AttributeName = "geometryId")]
        public string GeometryId { get; set; }

        [XmlElement("EmissionObjectReference")]
        public GeometryEmissionObjectReference[] EmissionObjectReference { get; set; }
    }
}