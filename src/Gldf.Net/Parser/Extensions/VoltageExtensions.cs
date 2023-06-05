using Gldf.Net.Domain.Typed.Global;
using Gldf.Net.Domain.Xml.Global;

namespace Gldf.Net.Parser.Extensions;

public static class VoltageExtensions
{
    public static VoltageTyped ToTyped(this Voltage voltage)
    {
        var fixedVoltage = voltage.GetAsFixedVoltage();
        var voltageRange = voltage.GetAsVoltageRange();
        return new VoltageTyped
        {
            FixedVoltage = fixedVoltage?.Value,
            VoltageRangeMin = voltageRange?.Min,
            VoltageRangeMax = voltageRange?.Max,
            Type = voltage.Type,
            Frequency = voltage.Frequency
        };
    }
}