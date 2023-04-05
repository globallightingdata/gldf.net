using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Parser.DataFlow;
using Gldf.Net.Parser.Extensions;
using System.Linq;

namespace Gldf.Net.Parser;

internal class EquipmentTransform : TransformBase
{
    public static ParserDto Map(ParserDto[] parserDtos)
    {
        return ExecuteSafe(() =>
        {
            var parserDto = parserDtos[0];
            var equipments = parserDto.Container.Product.GeneralDefinitions.Equipments?.ToArray();
            if (equipments?.Any() != true) return parserDto;
            parserDto.GeneralDefinitions.Equipments = equipments.Select(x => Map(x, parserDto.GeneralDefinitions)).ToList();
            return parserDto;
        }, parserDtos[0]);
    }

    private static EquipmentTyped Map(Equipment equipment, GeneralDefinitionsTyped definitions)
    {
        return new EquipmentTyped
        {
            Id = equipment.Id,
            ChangeableLightSource = definitions.ChangeableLightSources.GetChangeableTyped(equipment.LightSourceReference),
            LightSourceCount = equipment.LightSourceReference?.LightSourceCountSpecified == true
                ? equipment.LightSourceReference?.LightSourceCount
                : null,
            ControlGearCount = equipment.ControlGearReference?.ControlGearCountSpecified == true
                ? equipment.ControlGearReference?.ControlGearCount
                : null,
            ControlGear = definitions.ControlGears.GetTyped(equipment.ControlGearReference),
            RatedInputPower = equipment.RatedInputPower,
            EmergencyBallastLumenFactor = equipment.GetEmergencyModeOutputAsLumenFactor()?.ToTyped(),
            EmergencyRatedLuminousFlux = equipment.GetEmergencyModeOutputAsLuminousFlux()?.ToTyped()
        };
    }
}