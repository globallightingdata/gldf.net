using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Parser.Extensions;
using Gldf.Net.Parser.State;
using System.Linq;

namespace Gldf.Net.Parser
{
    internal class SpectrumTransform
    {
        public static SpectrumTransform Instance { get; } = new();

        public ParserDto<SpectrumTyped> Map(ParserDto<GldfFileTyped> filesDto)
        {
            var parserDto = new ParserDto<SpectrumTyped>(filesDto);
            if (filesDto.Container.Product.GeneralDefinitions.Spectrums?.Any() != true) return parserDto;
            foreach (var spectrum in filesDto.Container.Product.GeneralDefinitions.Spectrums)
                parserDto.Items.Add(Map(spectrum, filesDto));
            return parserDto;
        }

        private static SpectrumTyped Map(Spectrum spectrum, ParserDto<GldfFileTyped> files)
        {
            return new SpectrumTyped
            {
                Id = spectrum.Id,
                SpectrumFile = spectrum.FileReference != null ? files.GetFileTyped(spectrum.FileReference?.FileId) : null,
                Intensities = spectrum.Intensities?.ToTypedArray()
            };
        }
    }
}