using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Descriptive.Types.Atex;

public enum AtexEquipmentCategory
{
    [XmlEnum("M1")]
    CategoryM1,

    [XmlEnum("M2")]
    CategoryM2,

    [XmlEnum("1G")]
    Category1G,

    [XmlEnum("2G")]
    Category2G,

    [XmlEnum("3G")]
    Category3G,

    [XmlEnum("1D")]
    Category1D,

    [XmlEnum("2D")]
    Category2D,

    [XmlEnum("3D")]
    Category3D
}