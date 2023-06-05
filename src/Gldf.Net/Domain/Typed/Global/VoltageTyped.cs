using Gldf.Net.Domain.Xml.Global;

namespace Gldf.Net.Domain.Typed.Global;

public class VoltageTyped
{
    public double? FixedVoltage { get; set; }
        
    public double? VoltageRangeMin { get; set; }

    public double? VoltageRangeMax { get; set; }

    public VoltageType? Type { get; set; }

    public VoltageFrequency? Frequency { get; set; }
}