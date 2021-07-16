using System.Xml.Serialization;

namespace Gldf.Net.Domain.Descriptive.Types.Atex
{
    public enum AtexDivision
    {
        [XmlEnum("1")]
        Division1,

        [XmlEnum("2")]
        Division2
    }
}