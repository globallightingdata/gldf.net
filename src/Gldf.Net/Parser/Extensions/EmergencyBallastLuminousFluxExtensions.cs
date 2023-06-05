using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Xml.Definition.Types;

namespace Gldf.Net.Parser.Extensions;

public static class EmergencyBallastLuminousFluxExtensions
{
    public static EmergencyBallastLumenFactorTyped ToTyped(this EmergencyBallastLumenFactor lumenFactor) =>
        new()
        {
            Factor = lumenFactor.Factor
        };
}