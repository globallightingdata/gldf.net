using System.Xml.Serialization;

namespace Gldf.Net.Domain.Product.Types
{
    public class GeometryEmissionObjectReference
    {
        [XmlElement("LightEmitterReference", typeof(LightEmitterReference))]
        [XmlElement("SensorReference", typeof(SensorReference))]
        public EmissionObjectReference[] EmitterReference { get; set; }

        [XmlArray("ExternalEmitterReferences"), XmlArrayItem("ExternalEmitterReference")]
        public ExternalEmitterReference[] ExternalEmitterReferences { get; set; }
    }

}