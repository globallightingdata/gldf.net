using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Global
{
    public class Voltage
    {
        [XmlElement(ElementName = "VoltageValueType")]
        [XmlElement("VoltageRange", typeof(VoltageRange))]
        [XmlElement("FixedVoltage", typeof(FixedVoltage))]
        public VoltageValueBase Value { get; set; }

        public VoltageType? Type { get; set; }

        public VoltageFrequency? Frequency { get; set; }

        public bool ShouldSerializeType() => Type != null;

        public bool ShouldSerializeFrequency() => Frequency != null;

        public VoltageRange GetAsVoltageRange() => Value as VoltageRange;

        public FixedVoltage GetAsFixedVoltage() => Value as FixedVoltage;
    }
}