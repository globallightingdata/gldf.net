namespace Gldf.Net.Domain.Typed.Definition.Types
{
    public class DescriptivePhotometryTyped
    {
        public int? LuminaireLuminance { get; set; }

        public double? LightOutputRatio { get; set; }

        public double? LuminousEfficacy { get; set; }

        public double? DownwardFluxFraction { get; set; }

        public double? DownwardLightOutputRatio { get; set; }

        public double? UpwardLightOutputRatio { get; set; }

        public TenthPeakDivergenceTyped TenthPeakDivergence { get; set; }

        public HalfPeakDivergenceTyped HalfPeakDivergence { get; set; }

        public string PhotometricCode { get; set; }

        public string CieFluxCode { get; set; }

        public double? CutOffAngle { get; set; }

        public Ugr4H8HTyped Ugr4H8H { get; set; }

        public string IesnaLightDistributionDefinition { get; set; }

        public string LightDistributionBugRating { get; set; }
    }
}