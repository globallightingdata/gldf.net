using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Parser.Extensions;
using Gldf.Net.Parser.State;

namespace Gldf.Net.Parser
{
    internal class SpectrumTransform
    {
        public static SpectrumTransform Instance { get; } = new();

        public ParserDto<SpectrumTyped> Map(ParserDto<GldfFileTyped> filesDto)
        {
            var parserDto = new ParserDto<SpectrumTyped>(filesDto);
            foreach (var spectrum in filesDto.Container.Product.GeneralDefinitions.Spectrums)
                parserDto.Items.Add(Map(spectrum, filesDto));
            return parserDto;
        }

        private static SpectrumTyped Map(Spectrum spectrum, ParserDto<GldfFileTyped> files)
        {
            return new SpectrumTyped
            {
                Id = spectrum.Id,
                SpectrumFile = files.GetForId(spectrum.Id),
                Intensities = spectrum.Intensities.ToTypedArray()
            };
        }
    }
}