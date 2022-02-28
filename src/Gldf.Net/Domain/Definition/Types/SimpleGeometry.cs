using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public class SimpleGeometry : Geometry
    {
        [XmlAttribute(DataType = "ID", AttributeName = "id")]
        public string Id { get; set; }

        [XmlElement("Cuboid", typeof(SimpleCuboidGeometry))]
        [XmlElement("Cylinder", typeof(SimpleCylinderGeometry))]
        public SimpleGeometryBase SimpleGeometryType { get; set; }

        [XmlElement("RectangularEmitter", typeof(SimpleRectangularEmitter))]
        [XmlElement("CircularEmitter", typeof(SimpleCircularEmitter))]
        public SimpleGeometryEmitterBase SimpleGeometryEmitterType { get; set; }

        public SimpleCuboidGeometry GetAsCuboidGeometry() => SimpleGeometryType as SimpleCuboidGeometry;
        public SimpleCylinderGeometry GetAsCylinderGeometry() => SimpleGeometryType as SimpleCylinderGeometry;

        public SimpleRectangularEmitter GetAsRectangularEmitter() => SimpleGeometryEmitterType as SimpleRectangularEmitter;
        public SimpleCircularEmitter GetAsCircularEmitter() => SimpleGeometryEmitterType as SimpleCircularEmitter;
    }
}