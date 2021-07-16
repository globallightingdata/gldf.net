using System.Xml.Serialization;

namespace Gldf.Net.Domain.Global
{
    public class FixedVoltage : VoltageValue
    {
        [XmlText]
        public double Value { get; set; }
    }
}