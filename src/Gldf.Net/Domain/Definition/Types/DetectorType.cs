using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public enum DetectorType
    {
        [XmlEnum("Motion Detector")]
        MotionDetector,

        [XmlEnum("Presence Detector")]
        PresenceDetector,

        [XmlEnum("Daylight Detector")]
        DaylightDetector,

        [XmlEnum("Other")]
        Other
    }
}