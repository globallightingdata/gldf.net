using System.Xml.Serialization;

namespace Gldf.Net.Domain.Product.Types
{
    public enum JiegRoomCondition
    {
        [XmlEnum("Clean")]
        Clean,

        [XmlEnum("Normal")]
        Normal,

        [XmlEnum("Dirty")]
        Dirty
    }
}