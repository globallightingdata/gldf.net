using Gldf.Net.Domain.Xml.Definition.Types;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition
{
    public class Emitter
    {
        [XmlAttribute(DataType = "ID", AttributeName = "id")]
        public string Id { get; set; }

        [XmlElement("ChangeableLightEmitter", typeof(ChangeableLightEmitter))]
        [XmlElement("FixedLightEmitter", typeof(FixedLightEmitter))]
        [XmlElement("Sensor", typeof(SensorEmitter))]
        public EmitterBase[] PossibleFittings { get; set; }

        public IEnumerable<ChangeableLightEmitter> GetChangeableLightEmitters() => PossibleFittings?.OfType<ChangeableLightEmitter>();
        
        public IEnumerable<FixedLightEmitter> GetFixedLightEmitters() => PossibleFittings?.OfType<FixedLightEmitter>();

        public IEnumerable<SensorEmitter> GetSensorEmitters() => PossibleFittings?.OfType<SensorEmitter>();
    }
}