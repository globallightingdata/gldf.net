using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Parser.DataFlow;
using Gldf.Net.Parser.Extensions;
using System.Linq;

namespace Gldf.Net.Parser;

internal class FixedLightSourceTransform : TransformBase
{
    public static ParserDto Map(ParserDto[] parserDtos)
    {
        return ExecuteSafe(() =>
        {
            var parserDto = parserDtos[0];
            var fixedLightSources = parserDto.Container.Product.GeneralDefinitions.LightSources?.OfType<FixedLightSource>().ToList();
            if (fixedLightSources?.Any() != true) return parserDto;
            foreach (var changeableLightSource in fixedLightSources)
                parserDto.GeneralDefinitions.FixedLightSources.Add(Map(changeableLightSource, parserDto.GeneralDefinitions));
            return parserDto;
        }, parserDtos[0]);
    }

    private static FixedLightSourceTyped Map(FixedLightSource lightSource, GeneralDefinitionsTyped definitions)
    {
        return new FixedLightSourceTyped
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
            Spectrum = definitions.Spectrums.GetTyped(lightSource.SpectrumReference?.SpectrumId),
            ActivePowerTable = lightSource.ActivePowerTable?.ToTyped(),
            ColorInformation = lightSource.ColorInformation?.ToTyped(),
            LightSourceImages = definitions.Files.ToImageTypedArray(lightSource.LightSourceImages),
            ZhagaStandard = lightSource.ZhagaStandard,
            Maintenance = lightSource.Maintenance?.ToTyped()
        };
    }
}