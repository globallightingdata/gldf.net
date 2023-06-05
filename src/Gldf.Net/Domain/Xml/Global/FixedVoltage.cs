using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Global;

public class FixedVoltage : VoltageValueBase
{
    [XmlText]
    public double Value { get; set; }
}