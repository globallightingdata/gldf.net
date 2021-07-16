using System.Xml.Serialization;

namespace Gldf.Net.Domain.Global
{
    public enum VoltageFrequency
    {
        [XmlEnum("50")]
        Hz50,

        [XmlEnum("60")]
        Hz60,

        [XmlEnum("50/60")]
        Hz5060,

        [XmlEnum("400")]
        Hz400
    }
}