using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Descriptive.Types;

public enum LightDistribution
{
    [XmlEnum("Laterally symmetrical narrow")]
    LaterallySymmetricalNarrow,

    [XmlEnum("Laterally symmetrical medium")]
    LaterallySymmetricalMedium,

    [XmlEnum("Laterally symmetrical wide")]
    LaterallySymmetricalWide,

    [XmlEnum("Symmetrical in each quadrant")]
    SymmetricalInEachQuadrant,

    [XmlEnum("Symmetric about 0-180 plane")]
    SymmetricAbout0To180Plane,

    [XmlEnum("Symmetric about 90-270 plane")]
    SymmetricAbout90To270Plane,

    [XmlEnum("Asymmetrical")]
    Asymmetrical,

    [XmlEnum("Asymmetrical flood")]
    AsymmetricalFlood,

    [XmlEnum("Asymmetrical wide flood")]
    AsymmetricalWideFlood,

    [XmlEnum("Diffuse half spherical")]
    DiffuseHalfSpherical,

    [XmlEnum("Diffuse full spherical")]
    DiffuseFullSpherical,

    [XmlEnum("Direct")]
    Direct,

    [XmlEnum("Indirect")]
    Indirect,

    [XmlEnum("Direct indirect")]
    DirectIndirect,

    [XmlEnum("Other")]
    Other
}