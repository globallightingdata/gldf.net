using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public class SensorEmitter : EmitterBase
    {
        [XmlAttribute(DataType = "NCName", AttributeName = "sensorId")]
        public string SensorId { get; set; }
    }
}