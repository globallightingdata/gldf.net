using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Parser.DataFlow;
using Gldf.Net.Parser.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Parser;

internal class PhotometryTransform : TransformBase
{
    public static ParserDto Map(ParserDto parserDto)
    {
        return ExecuteSafe(() =>
        {
            var photometries = parserDto.Container.Product.GeneralDefinitions.Photometries;
            if (photometries?.Any() != true) return parserDto;
            parserDto.GeneralDefinitions.Photometries =
                photometries.Select(x => Map(x, parserDto.GeneralDefinitions.Files)).ToList();
            return parserDto;
        }, parserDto);
    }

    private static PhotometryTyped Map(Photometry photometry, IEnumerable<GldfFileTyped> files)
    {
        return new PhotometryTyped
        {
            Id = photometry.Id,
            PhotometryFile = files.ToFileTyped(photometry.GetAsFileReference()?.FileId),
            DescriptivePhotometry = photometry.DescriptivePhotometry != null
                ? new DescriptivePhotometryTyped
                {
                    LuminaireLuminance = photometry.DescriptivePhotometry?.LuminaireLuminance,
                    LightOutputRatio = photometry.DescriptivePhotometry?.LightOutputRatio,
                    LuminousEfficacy = photometry.DescriptivePhotometry?.LuminousEfficacy,
                    DownwardFluxFraction = photometry.DescriptivePhotometry?.DownwardFluxFraction,
                    DownwardLightOutputRatio = photometry.DescriptivePhotometry?.DownwardLightOutputRatio,
                    UpwardLightOutputRatio = photometry.DescriptivePhotometry?.UpwardLightOutputRatio,
                    TenthPeakDivergence = photometry.DescriptivePhotometry?.TenthPeakDivergence?.ToTyped(),
                    HalfPeakDivergence = photometry.DescriptivePhotometry?.HalfPeakDivergence?.ToTyped(),
                    PhotometricCode = photometry.DescriptivePhotometry?.PhotometricCode,
                    CieFluxCode = photometry.DescriptivePhotometry?.CieFluxCode,
                    CutOffAngle = photometry.DescriptivePhotometry?.CutOffAngle,
                    Ugr4H8H = photometry.DescriptivePhotometry?.Ugr4H8H?.ToTyped(),
                    IesnaLightDistributionDefinition = photometry.DescriptivePhotometry?.IesnaLightDistributionDefinition,
                    LightDistributionBugRating = photometry.DescriptivePhotometry?.LightDistributionBugRating
                }
                : null
        };
    }
}