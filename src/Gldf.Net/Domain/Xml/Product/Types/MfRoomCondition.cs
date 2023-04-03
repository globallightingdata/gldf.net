using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Product.Types;

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