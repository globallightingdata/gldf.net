using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Descriptive.Types;

public enum Adjustability
{
    [XmlEnum("Fixed")]
    Fixed,
        
    [XmlEnum("Orientation")]
    Orientation,
        
    [XmlEnum("Turn")]
    Turn,
        
    [XmlEnum("Tilt")]
    Tilt,
        
    [XmlEnum("Cardanic")]
    Cardanic,
        
    [XmlEnum("Height adjustable")]
    HeightAdjustable,
        
    [XmlEnum("User defined")]
    UserDefined
}