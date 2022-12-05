using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Xml.Definition.Types;

namespace Gldf.Net.Parser.Extensions;

public static class EmergencyRatedLuminousFluxExtensions
{
    public static EmergencyRatedLuminousFluxTyped ToTyped(this EmergencyRatedLuminousFlux luminousFlux) =>
        new()
        {
            Flux = luminousFlux.Flux
        };
}