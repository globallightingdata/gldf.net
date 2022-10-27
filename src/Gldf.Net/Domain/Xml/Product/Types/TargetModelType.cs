using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Product.Types
{
    public enum TargetModelType
    {
        [XmlEnum("l3d")]
        L3d,

        [XmlEnum("m3d")]
        M3d,

        [XmlEnum("r3d")]
        R3d
    }
}