using System.Xml.Serialization;

// ReSharper disable InconsistentNaming

namespace Gldf.Net.Domain.Xml.Descriptive.Types.Atex;

public enum AtexEquipmentGroup
{
    [XmlEnum("I")]
    GroupI,

    [XmlEnum("II")]
    GroupII
}