using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public enum DetectionMethod
    {
        [XmlEnum("Passive Infrared")]
        PassiveInfrared,

        [XmlEnum("High Frequency")]
        HighFrequency,

        Microwave,

        Ultrasonic,

        Camera,

        Other
    }
}