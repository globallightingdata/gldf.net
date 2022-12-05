using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Parser.DataFlow;
using Gldf.Net.Parser.Extensions;
using System.Linq;

namespace Gldf.Net.Parser;

internal class ChangeableLightSourceTransform : TransformBase
{
    public static ParserDto Map(ParserDto[] parserDtos)
    {
        return ExecuteSafe(() =>
        {
            var parserDto = parserDtos[0];
            var changeableLightSources = parserDto.Container.Product.GeneralDefinitions.LightSources?.OfType<ChangeableLightSource>().ToList();
            if (changeableLightSources?.Any() != true) return parserDto;
            foreach (var changeableLightSource in changeableLightSources)
                parserDto.GeneralDefinitions.ChangeableLightSources.Add(Map(changeableLightSource, parserDto.GeneralDefinitions));
            return parserDto;
        }, parserDtos[0]);
    }

    private static ChangeableLightSourceTyped Map(ChangeableLightSource lightSource, GeneralDefinitionsTyped definitions)
    {
        return new ChangeableLightSourceTyped
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
            Spectrum = definitions.Spectrums?.GetTyped(lightSource.SpectrumReference?.SpectrumId),
            ActivePowerTable = lightSource.ActivePowerTable?.ToTyped(),
            ColorInformation = lightSource.ColorInformation?.ToTyped(),
            LightSourceImages = definitions.Files?.ToImageTypedArray(lightSource.LightSourceImages),
            Zvei = lightSource.Zvei,
            Socket = lightSource.Socket,
            Ilcos = lightSource.Ilcos,
            RatedLuminousFlux = lightSource.RatedLuminousFlux,
            RatedLuminousFluxRGB = lightSource.RatedLuminousFluxRGB,
            Photometry = lightSource.PhotometryReference != null
                ? new PhotometryTyped
                {
                    PhotometryFile = definitions.Photometries.GetTyped(lightSource.PhotometryReference.PhotometryId)?.PhotometryFile,
                    DescriptivePhotometry = definitions.Photometries.GetTyped(lightSource.PhotometryReference.PhotometryId)?.DescriptivePhotometry
                }
                : null,
            Maintenance = lightSource.Maintenance?.ToTyped()
        };
    }
}