using System.Xml.Serialization;

namespace Gldf.Net.Domain.Product.Types
{
    public enum MfRoomCondition
    {
        [XmlEnum("Very Clean")]
        VeryClean,

        [XmlEnum("Clean")]
        Clean,

        [XmlEnum("Normal")]
        Normal,

        [XmlEnum("Dirty")]
        Dirty
    }
}