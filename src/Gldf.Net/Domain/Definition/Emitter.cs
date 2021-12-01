using Gldf.Net.Domain.Definition.Types;
using Gldf.Net.Domain.Product.Types;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition
{
    public class Emitter
    {
        [XmlAttribute(DataType = "ID", AttributeName = "id")]
        public string Id { get; set; }

        [XmlElement("LightEmitter", typeof(LightEmitter))]
        [XmlElement("Sensor", typeof(SensorEmitter))]
        public EmitterBase[] PossibleFittings { get; set; }

        public IEnumerable<LightEmitter> GetLightEmitters() => PossibleFittings?.OfType<LightEmitter>();

        public IEnumerable<SensorEmitter> GetSensorEmitters() => PossibleFittings?.OfType<SensorEmitter>();
    }
}