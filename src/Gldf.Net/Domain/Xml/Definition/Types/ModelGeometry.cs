using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition.Types
{
    public class ModelGeometry : GeometryBase
    {
        [XmlAttribute(DataType = "ID", AttributeName = "id")]
        public string Id { get; set; }

        [XmlElement("GeometryFileReference")]
        public GeometryFileReference[] GeometryFileReferences { get; set; }
    }
}