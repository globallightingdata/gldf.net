using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Parser.Extensions;
using Gldf.Net.Parser.State;
using System.Linq;

namespace Gldf.Net.Parser
{
    internal class PhotometryTransform
    {
        public static PhotometryTransform Instance { get; } = new();

        public ParserDto<PhotometryTyped> Map(ParserDto<GldfFileTyped> filesDto)
        {
            var parserDto = new ParserDto<PhotometryTyped>(filesDto);
            if (filesDto.Container.Product.GeneralDefinitions.Photometries?.Any() != true) return parserDto;
            foreach (var photometry in filesDto.Container.Product.GeneralDefinitions.Photometries)
                parserDto.Items.Add(Map(photometry, filesDto));
            return parserDto;
        }

        private static PhotometryTyped Map(Photometry photometry, ParserDto<GldfFileTyped> files)
        {
            return new PhotometryTyped
            {
                Id = photometry.Id,
                PhotometryFile = files.GetForId(photometry.Id),
                DescriptivePhotometry = new DescriptivePhotometryTyped
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
            };
        }
    }
}