using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Xml.Definition.Types;

namespace Gldf.Net.Parser.Extensions
{
    public static class ColorInformationExtensions
    {
        public static ColorInformationTyped ToTyped(this ColorInformation colorInformation) =>
            new()
            {
                ColorRenderingIndex = colorInformation.ColorRenderingIndex,
                CorrelatedColorTemperature = colorInformation.CorrelatedColorTemperature,
                ColorTemperatureAdjustingRange = colorInformation.ColorTemperatureAdjustingRange != null
                    ? new ColorTemperatureAdjustingRangeTyped
                    {
                        Lower = colorInformation.ColorTemperatureAdjustingRange.Lower,
                        Upper = colorInformation.ColorTemperatureAdjustingRange.Upper
                    }
                    : null,
                Cie1931ColorAppearance = colorInformation.Cie1931ColorAppearance != null
                    ? new Cie1931ColorAppearanceTyped
                    {
                        X = colorInformation.Cie1931ColorAppearance.X,
                        Y = colorInformation.Cie1931ColorAppearance.Y,
                        Z = colorInformation.Cie1931ColorAppearance.Z
                    }
                    : null,
                InitialColorTolerance = colorInformation.InitialColorTolerance,
                MaintainedColorTolerance = colorInformation.InitialColorTolerance,
                RatedChromacityCoordinateValues = colorInformation.RatedChromacityCoordinateValues != null
                    ? new ChromacityCoordinateValuesTyped
                    {
                        X = colorInformation.RatedChromacityCoordinateValues.X,
                        Y = colorInformation.RatedChromacityCoordinateValues.Y
                    }
                    : null,
                Tlci = colorInformation.Tlci,
                IesTm3015 = colorInformation.IesTm3015 != null
                    ? new IesTm3015Typed
                    {
                        Rf = colorInformation.IesTm3015.Rf,
                        Rg = colorInformation.IesTm3015.Rg
                    }
                    : null,
                MelanopicFactor = colorInformation.MelanopicFactor
            };
    }
}