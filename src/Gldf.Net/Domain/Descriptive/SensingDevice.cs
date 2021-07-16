using Gldf.Net.Domain.Descriptive.Types;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Descriptive
{
    public class SensingDevice
    {
        [XmlArrayItem("DetectorCharacteristic")]
        public DetectorCharacteristic[] DetectorCharacteristics { get; set; }

        [XmlArrayItem("DetectionMethod")]
        public DetectionMethod[] DetectionMethods { get; set; }

        [XmlArrayItem("DetectorType")]
        public DetectorType[] DetectorTypes { get; set; }
    }
}