using Gldf.Net.Domain.Xml.Definition.Types;

namespace Gldf.Net.Domain.Typed.Definition.Types
{
    public class ColorInformationTyped
    {
        public int? ColorRenderingIndex { get; set; }

        public int? CorrelatedColorTemperature { get; set; }

        public ColorTemperatureAdjustingRangeTyped ColorTemperatureAdjustingRange { get; set; }

        public Cie1931ColorAppearanceTyped Cie1931ColorAppearance { get; set; }

        public MacAdamEllipse InitialColorTolerance { get; set; }

        public MacAdamEllipse MaintainedColorTolerance { get; set; }

        public ChromacityCoordinateValuesTyped RatedChromacityCoordinateValues { get; set; }

        public int? Tlci { get; set; }

        public IesTm3015Typed IesTm3015 { get; set; }

        public double? MelanopicFactor { get; set; }
    }
}