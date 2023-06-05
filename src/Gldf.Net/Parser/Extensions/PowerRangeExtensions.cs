using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Xml.Definition.Types;

namespace Gldf.Net.Parser.Extensions;

public static class PowerRangeExtensions
{
    public static LightSourcePowerRangeTyped ToTyped(this LightSourcePowerRange powerRange) =>
        new()
        {
            Lower = powerRange.Lower,
            Upper = powerRange.Upper,
            Default = powerRange.Default
        };
}