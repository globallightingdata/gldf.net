using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition.Types
{
    public class SimpleGeometry : Geometry
    {
        [XmlAttribute(DataType = "ID", AttributeName = "id")]
        public string Id { get; set; }

        [XmlElement("Cuboid", typeof(SimpleCuboidGeometry))]
        [XmlElement("Cylinder", typeof(SimpleCylinderGeometry))]
        public SimpleGeometryBase GeometryType { get; set; }

        [XmlElement("RectangularEmitter", typeof(SimpleRectangularEmitter))]
        [XmlElement("CircularEmitter", typeof(SimpleCircularEmitter))]
        public SimpleGeometryEmitterBase EmitterType { get; set; }

        [XmlElement("C-Heights")]
        public CHeights CHeights { get; set; }

        public SimpleCuboidGeometry GetAsCuboidGeometry() => GeometryType as SimpleCuboidGeometry;
        public SimpleCylinderGeometry GetAsCylinderGeometry() => GeometryType as SimpleCylinderGeometry;
        public SimpleRectangularEmitter GetAsRectangularEmitter() => EmitterType as SimpleRectangularEmitter;
        public SimpleCircularEmitter GetAsCircularEmitter() => EmitterType as SimpleCircularEmitter;
    }

}