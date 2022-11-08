using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public class ModelGeometry : GeometryBase
    {
        [XmlElement("GeometryFileReference")]
        public GeometryFileReference[] GeometryFileReferences { get; set; }
    }
}