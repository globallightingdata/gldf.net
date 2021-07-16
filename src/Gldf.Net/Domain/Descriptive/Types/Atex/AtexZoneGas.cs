using System.Xml.Serialization;

namespace Gldf.Net.Domain.Descriptive.Types.Atex
{
    public enum AtexZoneGas
    {
        [XmlEnum("0")]
        Zone0,

        [XmlEnum("1")]
        Zone1,

        [XmlEnum("2")]
        Zone2
    }
}