using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Product.Types;

public enum Cie97LuminaireType
{
    [XmlEnum("Bare Batten")]
    BareBatten,

    [XmlEnum("Open Top Housing (Natural Ventilated)")]
    OpenTopHousingNaturalVentilated,

    [XmlEnum("Closed Top Housing (Unventilated)")]
    ClosedTopHousingUnventilated,

    [XmlEnum("Enclosed IP2X")]
    EnclosedIp2X,

    [XmlEnum("Dust Proof IP5X")]
    DustProofIp5X,

    [XmlEnum("Enclosed Indirect (Uplight)")]
    EnclosedIndirectUplight,

    [XmlEnum("Airhandling, Forced Ventilated")]
    AirhandlingForcedVentilated
}