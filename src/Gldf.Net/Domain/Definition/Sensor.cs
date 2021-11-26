using Gldf.Net.Domain.Definition.Types;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition
{
    public class Sensor
    {
        [XmlAttribute(DataType = "ID", AttributeName = "id")]
        public string Id { get; set; }

        public SensorFileReference SensorFileReference { get; set; }

        [XmlArrayItem("DetectorCharacteristic")]
        public DetectorCharacteristic[] DetectorCharacteristics { get; set; }

        [XmlArrayItem("DetectionMethod")]
        public DetectionMethod[] DetectionMethods { get; set; }

        [XmlArrayItem("DetectorType")]
        public DetectorType[] DetectorTypes { get; set; }
    }
}