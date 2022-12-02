using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Parser.Extensions;
using Gldf.Net.Parser.State;
using System;
using System.Linq;

namespace Gldf.Net.Parser
{
    internal class ChangeableLightSourceTransform
    {
        public static ChangeableLightSourceTransform Instance { get; } = new();

        public ParserDto<ChangeableLightSourceTyped> Map(Tuple<ParserDto<GldfFileTyped>, ParserDto<PhotometryTyped>, ParserDto<SpectrumTyped>> dtos)
        {
            var files = dtos.Item1;
            var photometries = dtos.Item2;
            var spectrums = dtos.Item3;
            var gfldfRoot = dtos.Item1.Container.Product;
            var result = new ParserDto<ChangeableLightSourceTyped>(dtos.Item1);
            var changeableLightSources = gfldfRoot.GeneralDefinitions.LightSources.OfType<ChangeableLightSource>().ToList();

            if (!changeableLightSources.Any()) return result;
            foreach (var changeableLightSource in changeableLightSources)
                result.Items.Add(Map(changeableLightSource, files, photometries, spectrums));
            return result;
        }

        private ChangeableLightSourceTyped Map(ChangeableLightSource lightSource, ParserDto<GldfFileTyped> files,
            ParserDto<PhotometryTyped> photometries, ParserDto<SpectrumTyped> spectrums)
        {
            return new ChangeableLightSourceTyped
            {
                Id = lightSource.Id,
                Name = lightSource.Name.ToTypedArray(),
                Description = lightSource.Description?.ToTypedArray(),
                Manufacturer = lightSource.Manufacturer,
                Gtin = lightSource.Gtin,
                RatedInputPower = lightSource.RatedInputPower,
                RatedInputVoltage = lightSource.RatedInputVoltage?.ToTyped(),
                PowerRange = lightSource.PowerRange?.ToTyped(),
                LightSourcePositionOfUsage = lightSource.LightSourcePositionOfUsage,
                EnergyLabels = lightSource.EnergyLabels?.ToTypedArray(),
                Spectrum = lightSource.SpectrumReference != null ? spectrums?.GetTyped(lightSource.SpectrumReference.SpectrumId) : null,
                ActivePowerTable = lightSource.ActivePowerTable?.ToTyped(),
                ColorInformation = lightSource.ColorInformation?.ToTyped(),
                LightSourceImages = lightSource.LightSourceImages != null ? files?.GetImagesTyped(lightSource.LightSourceImages) : null,
                Zvei = lightSource.Zvei,
                Socket = lightSource.Socket,
                Ilcos = lightSource.Ilcos,
                RatedLuminousFlux = lightSource.RatedLuminousFlux,
                RatedLuminousFluxRGB = lightSource.RatedLuminousFluxRGB,
                Photometry = lightSource.PhotometryReference != null
                    ? new PhotometryTyped
                    {
                        PhotometryFile = photometries.GetTyped(lightSource.PhotometryReference.PhotometryId).PhotometryFile,
                        DescriptivePhotometry = photometries.GetTyped(lightSource.PhotometryReference.PhotometryId).DescriptivePhotometry
                    }
                    : null,
                Maintenance = lightSource.Maintenance?.ToTyped()
            };
        }
    }
}