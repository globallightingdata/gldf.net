using System.Xml.Serialization;

namespace Gldf.Net.Domain.Global
{
    public class FixedVoltage : VoltageValueBase
    {
        [XmlText]
        public double Value { get; set; }
    }
}