using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Parser.Extensions;
using Gldf.Net.Parser.State;

namespace Gldf.Net.Parser
{
    internal class ControlGearsTransform
    {
        public static ControlGearsTransform Instance { get; } = new();

        public ParserDto<ControlGearTyped> Map(ContainerDto containerDto)
        {
            var parserDto = new ParserDto<ControlGearTyped>(containerDto);
            foreach (var controlGear in containerDto.Container.Product.GeneralDefinitions.ControlGears)
                parserDto.Items.Add(Map(controlGear));
            return parserDto;
        }

        private ControlGearTyped Map(ControlGear controlGear)
        {
            return new ControlGearTyped
            {
                Id = controlGear.Id,
                Name = controlGear.Name.ToTypedArray(),
                Description = controlGear.Description.ToTypedArray(),
                NominalVoltage = controlGear.NominalVoltage.ToTyped(),
                StandbyPower = controlGear.StandbyPower,
                ConstantLightOutputStartPower = controlGear.ConstantLightOutputStartPower,
                ConstantLightOutputEndPower = controlGear.ConstantLightOutputEndPower,
                PowerConsumptionControls = controlGear.PowerConsumptionControls,
                IsDimmable = controlGear.IsDimmable,
                IsColorControllable = controlGear.IsColorControllable,
                Interfaces = controlGear.Interfaces,
                EnergyLabels = controlGear.EnergyLabels.ToTypedArray()
            };
        }
    }
}