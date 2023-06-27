using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Parser.DataFlow;
using Gldf.Net.Parser.Extensions;
using System.Linq;

namespace Gldf.Net.Parser;

internal class MultiChannelLightSourceTransform : TransformBase
{
    public static ParserDto Map(ParserDto[] parserDtos)
    {
        return ExecuteSafe(() =>
        {
            var parserDto = parserDtos[0];
            var mcLightSources = parserDto.Container.Product.GeneralDefinitions.GetAsMultiChannelLightSources();
            if (!mcLightSources.Any()) return parserDto;
            parserDto.GeneralDefinitions.MultiChannelLightSources =
                mcLightSources.Select(ls => Map(ls, parserDto.GeneralDefinitions)).ToList();
            return parserDto;
        }, parserDtos[0]);
    }

    private static MultiChannelLightSourceTyped Map(MultiChannelLightSource lightSource, GeneralDefinitionsTyped definitions)
    {
        return new MultiChannelLightSourceTyped
        {
            Id = lightSource.Id,
            Name = lightSource.Name?.ToTypedArray(),
            Description = lightSource.Description?.ToTypedArray(),
            Manufacturer = lightSource.Manufacturer,
            Gtin = lightSource.Gtin,
            RatedInputPower = lightSource.RatedInputPower,
            RatedInputVoltage = lightSource.RatedInputVoltage?.ToTyped(),
            PowerRange = lightSource.PowerRange?.ToTyped(),
            LightSourcePositionOfUsage = lightSource.LightSourcePositionOfUsage,
            EnergyLabels = lightSource.EnergyLabels?.ToTypedArray(),
            ActivePowerTable = lightSource.ActivePowerTable?.ToTyped(),
            ColorInformation = lightSource.ColorInformation?.ToTyped(),
            LightSourceImages = definitions.Files.ToImageTypedArray(lightSource.LightSourceImages),
            Channels = lightSource.Channels?.ToTypedArray(definitions),
            Maintenance = lightSource.Maintenance?.ToTyped(),
            EmergencyBallastLumenFactor = lightSource.EmergencyBallastLumenFactor
        };
    }
}