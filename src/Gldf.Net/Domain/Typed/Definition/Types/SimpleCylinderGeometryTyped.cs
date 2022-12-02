using Gldf.Net.Domain.Xml.Definition.Types;

namespace Gldf.Net.Domain.Typed.Definition.Types
{
    public class SimpleCylinderGeometryTyped
    {
        public SimpleCylinderPlane Plane { get; set; }

        public int Diameter { get; set; }

        public int Height { get; set; }
    }
}