using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Parser.DataFlow;
using Gldf.Net.Parser.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Parser;

internal class SpectrumTransform : TransformBase
{
    public static ParserDto Map(ParserDto parserDto)
    {
        return ExecuteSafe(() =>
        {
            var spectrums = parserDto.Container.Product.GeneralDefinitions.Spectrums;
            if (spectrums?.Any() != true) return parserDto;
            foreach (var spectrum in spectrums)
                parserDto.GeneralDefinitions.Spectrums.Add(Map(spectrum, parserDto.GeneralDefinitions.Files));
            return parserDto;
        }, parserDto);
    }

    private static SpectrumTyped Map(Spectrum spectrum, IEnumerable<GldfFileTyped> files)
    {
        return new SpectrumTyped
        {
            Id = spectrum.Id,
            SpectrumFile = files.ToFileTyped(spectrum.FileReference?.FileId),
            Intensities = spectrum.Intensities?.ToTypedArray()
        };
    }
}