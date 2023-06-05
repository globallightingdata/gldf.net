using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Product.Types;

public enum DdRoomCondition
{
    [XmlEnum("Very Clean")]
    VeryClean,

    [XmlEnum("Clean")]
    Clean,

    [XmlEnum("Moderate")]
    Moderate,

    [XmlEnum("Dirty")]
    Dirty,

    [XmlEnum("Very Dirty")]
    VeryDirty
}