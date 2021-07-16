using System.Xml.Serialization;

namespace Gldf.Net.Domain.Product.Types
{
    public class EmitterReferences
    {
        [XmlElement("GeometryReference", typeof(GeometryReference))]
        [XmlElement("LightEmitterReference", typeof(LightEmitterReference))]
        [XmlElement("SensorReference", typeof(SensorReference))]
        public EmissionObjectReference Reference { get; set; }

        public GeometryReference GetAsGeometryReference() => Reference as GeometryReference;

        public LightEmitterReference GetAsLightEmitterReference() => Reference as LightEmitterReference;

        public SensorReference GetAsSensorReference() => Reference as SensorReference;
    }
}