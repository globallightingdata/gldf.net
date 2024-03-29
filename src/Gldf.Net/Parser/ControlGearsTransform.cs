using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Parser.DataFlow;
using Gldf.Net.Parser.Extensions;
using System.Linq;

namespace Gldf.Net.Parser;

internal class ControlGearsTransform : TransformBase
{
    public static ParserDto Map(ParserDto parserDto)
    {
        return ExecuteSafe(() =>
        {
            var controlGears = parserDto.Container.Product.GeneralDefinitions.ControlGears;
            if (controlGears?.Any() != true) return parserDto;
            parserDto.GeneralDefinitions.ControlGears = controlGears.Select(Map).ToList();
            return parserDto;
        }, parserDto);
    }

    private static ControlGearTyped Map(ControlGear controlGear)
    {
        return new ControlGearTyped
        {
            Id = controlGear.Id,
            Name = controlGear.Name?.ToTypedArray(),
            Description = controlGear.Description?.ToTypedArray(),
            NominalVoltage = controlGear.NominalVoltage?.ToTyped(),
            StandbyPower = controlGear.StandbyPower,
            ConstantLightOutputStartPower = controlGear.ConstantLightOutputStartPower,
            ConstantLightOutputEndPower = controlGear.ConstantLightOutputEndPower,
            PowerConsumptionControls = controlGear.PowerConsumptionControls,
            IsDimmable = controlGear.IsDimmable,
            IsColorControllable = controlGear.IsColorControllable,
            Interfaces = controlGear.Interfaces,
            EnergyLabels = controlGear.EnergyLabels?.ToTypedArray()
        };
    }
}