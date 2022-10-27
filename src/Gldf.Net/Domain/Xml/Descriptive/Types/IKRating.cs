using System.Xml.Serialization;

// ReSharper disable InconsistentNaming

namespace Gldf.Net.Domain.Xml.Descriptive.Types
{
    public enum IKRating
    {
        IK00,
        IK01,
        IK02,
        IK03,
        IK04,
        IK05,
        IK06,
        IK07,
        IK08,
        IK09,
        IK10,

        [XmlEnum("IK10+")]
        IK10Plus
    }
}