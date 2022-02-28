using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public class ModelGeometry : Geometry
    {
        [XmlAttribute(DataType = "ID", AttributeName = "id")]
        public string Id { get; set; }

        [XmlElement("GeometryFileReference")]
        public GeometryFileReference[] GeometryFileReferences { get; set; }
    }
}