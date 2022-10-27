using System.Xml.Serialization;

// ReSharper disable InconsistentNaming

namespace Gldf.Net.Domain.Xml.Descriptive.Types.Atex
{
    public enum AtexZoneGroupGas
    {
        IIC,

        [XmlEnum("IIB + H2")]
        IIBH2,

        IIB,

        IIA
    }
}