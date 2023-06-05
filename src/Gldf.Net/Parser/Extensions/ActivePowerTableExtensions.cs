using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Xml.Definition.Types;
using System.Linq;

namespace Gldf.Net.Parser.Extensions;

public static class ActivePowerTableExtensions
{
    public static ActivePowerTableTyped ToTyped(this ActivePowerTable activePowerTable) =>
        new()
        {
            Type = activePowerTable.Type,
            FluxFactor = activePowerTable.FluxFactor?.Select(factor => new FluxFactorTyped
            {
                InputPower = factor.InputPower,
                FlickerPstLm = factor.FlickerPstLm,
                StroboscopicEffectsSvm = factor.StroboscopicEffectsSvm,
                Description = factor.Description,
                Factor = factor.Factor
            }).ToArray()
        };
}