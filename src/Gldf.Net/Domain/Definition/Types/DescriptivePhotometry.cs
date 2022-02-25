using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public class DescriptivePhotometry
    {
        public int? LuminaireLuminance { get; set; }

        public double? LightOutputRatio { get; set; }

        public int? LuminousEfficacy { get; set; }

        public double? DownwardFluxFraction { get; set; }

        public double? DownwardLightOutputRatio { get; set; }

        public double? UpwardLightOutputRatio { get; set; }

        public TenthPeakDivergence TenthPeakDivergence { get; set; }

        public HalfPeakDivergence HalfPeakDivergence { get; set; }

        public string PhotometricCode { get; set; }

        [XmlElement("CIE-FluxCode")]
        public string CieFluxCode { get; set; }

        public double? CutOffAngle { get; set; }

        [XmlElement("UGR-4H8H-70-50-20-LQ")]
        public Ugr4H8H Ugr4H8H { get; set; }

        [XmlElement("IESNA-LightDistributionDefinition")]
        public string IesnaLightDistributionDefinition { get; set; }

        [XmlElement("LightDistributionBUG-Rating")]
        public string LightDistributionBugRating { get; set; }

        public bool ShouldSerializeLuminaireLuminance() => LuminaireLuminance != null;

        public bool ShouldSerializeLightOutputRatio() => LightOutputRatio != null;

        public bool ShouldSerializeLuminousEfficacy() => LuminousEfficacy != null;

        public bool ShouldSerializeDownwardFluxFraction() => DownwardFluxFraction != null;

        public bool ShouldSerializeDownwardLightOutputRatio() => DownwardLightOutputRatio != null;

        public bool ShouldSerializeUpwardLightOutputRatio() => UpwardLightOutputRatio != null;

        public bool ShouldSerializeTenthPeakDivergence() => TenthPeakDivergence != null;

        public bool ShouldSerializeHalfPeakDivergence() => HalfPeakDivergence != null;

        public bool ShouldSerializeCutOffAngle() => CutOffAngle != null;
    }
}