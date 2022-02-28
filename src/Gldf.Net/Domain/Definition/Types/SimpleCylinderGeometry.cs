using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public class SimpleCylinderGeometry : SimpleGeometryBase
    {
        [XmlAttribute(AttributeName = "plane")]
        public SimpleCylinderPlane Plane { get; set; }

        public int Diameter { get; set; }

        public int Height { get; set; }
    }
}