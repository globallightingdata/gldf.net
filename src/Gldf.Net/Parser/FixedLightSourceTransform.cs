using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Parser.Extensions;
using Gldf.Net.Parser.State;
using System;
using System.Linq;

namespace Gldf.Net.Parser
{
    internal class FixedLightSourceTransform
    {
        public static FixedLightSourceTransform Instance { get; } = new();

        public ParserDto<FixedLightSourceTyped> Map(Tuple<ParserDto<GldfFileTyped>, ParserDto<PhotometryTyped>, ParserDto<SpectrumTyped>> dtos)
        {
            var files = dtos.Item1;
            var photometries = dtos.Item2;
            var spectrums = dtos.Item3;
            var gfldfRoot = dtos.Item1.Container.Product;
            var result = new ParserDto<FixedLightSourceTyped>(dtos.Item1);
            var changeableLightSources = gfldfRoot.GeneralDefinitions.LightSources.OfType<FixedLightSource>().ToList();

            if (!changeableLightSources.Any()) return result;
            foreach (var changeableLightSource in changeableLightSources)
                result.Items.Add(Map(changeableLightSource, files, spectrums));
            return result;
        }

        private FixedLightSourceTyped Map(FixedLightSource lightSource, ParserDto<GldfFileTyped> files, ParserDto<SpectrumTyped> spectrums)
        {
            return new FixedLightSourceTyped
            {
                Id = lightSource.Id,
                Name = lightSource.Name.ToTypedArray(),
                Description = lightSource.Description.ToTypedArray(),
                Manufacturer = lightSource.Manufacturer,
                Gtin = lightSource.Gtin,
                RatedInputPower = lightSource.RatedInputPower,
                RatedInputVoltage = lightSource.RatedInputVoltage.ToTyped(),
                PowerRange = lightSource.PowerRange.ToTyped(),
                LightSourcePositionOfUsage = lightSource.LightSourcePositionOfUsage,
                EnergyLabels = lightSource.EnergyLabels.ToTypedArray(),
                Spectrum = spectrums.GetTyped(lightSource.SpectrumReference.SpectrumId),
                ActivePowerTable = lightSource.ActivePowerTable.ToTyped(),
                ColorInformation = lightSource.ColorInformation.ToTyped(),
                LightSourceImages = files.GetImagesTyped(lightSource.LightSourceImages),
                ZhagaStandard = lightSource.ZhagaStandard,
                Maintenance = lightSource.Maintenance.ToTyped()
            };
        }
    }
}