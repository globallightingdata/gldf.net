using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition.Types;

public class ModelGeometry : GeometryBase
{
    [XmlElement("GeometryFileReference")]
    public GeometryFileReference[] GeometryFileReferences { get; set; }
}