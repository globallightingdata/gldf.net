using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Product.Types;

public enum TargetModelType
{
    [XmlEnum("l3d")]
    // ReSharper disable once InconsistentNaming
    L3d,

    [XmlEnum("m3d")]
    // ReSharper disable once InconsistentNaming
    M3d,

    [XmlEnum("r3d")]
    // ReSharper disable once InconsistentNaming
    R3d
}