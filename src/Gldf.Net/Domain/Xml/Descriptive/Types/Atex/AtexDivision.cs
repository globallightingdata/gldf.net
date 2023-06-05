using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Descriptive.Types.Atex;

public enum AtexDivision
{
    [XmlEnum("1")]
    Division1,

    [XmlEnum("2")]
    Division2
}