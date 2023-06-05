using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Descriptive.Types;

public enum EmergencyLightingType
{
    [XmlEnum("Exit Light")]
    ExitLight,

    [XmlEnum("Guide Light")]
    GuideLight,

    [XmlEnum("Evacuation Light")]
    EvacuationLight,

    [XmlEnum("Reference Light")]
    ReferenceLight,

    [XmlEnum("For Signage")]
    ForSignage,

    [XmlEnum("For Lighting")]
    ForLighting
}