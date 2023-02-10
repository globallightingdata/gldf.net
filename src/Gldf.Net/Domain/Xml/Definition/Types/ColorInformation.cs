using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition.Types
{
    public class ColorInformation
    {
        public int? ColorRenderingIndex { get; set; }

        public int? CorrelatedColorTemperature { get; set; }

        public ColorTemperatureAdjustingRange ColorTemperatureAdjustingRange { get; set; }

        public Cie1931ColorAppearance Cie1931ColorAppearance { get; set; }

        public MacAdamEllipse? InitialColorTolerance { get; set; }

        public MacAdamEllipse? MaintainedColorTolerance { get; set; }

        public ChromacityCoordinateValues RatedChromacityCoordinateValues { get; set; }

        [XmlElement(ElementName = "TLCI")]
        public int? Tlci { get; set; }

        [XmlElement("IES-TM-30-15")]
        public IesTm3015 IesTm3015 { get; set; }

        public double? MelanopicFactor { get; set; }

        public bool ShouldSerializeColorRenderingIndex() => ColorRenderingIndex != null;

        public bool ShouldSerializeCorrelatedColorTemperature() => CorrelatedColorTemperature != null;
        
        public bool ShouldSerializeInitialColorTolerance() => InitialColorTolerance != null;
        
        public bool ShouldSerializeMaintainedColorTolerance() => MaintainedColorTolerance != null;

        public bool ShouldSerializeTlci() => Tlci != null;

        public bool ShouldSerializeMelanopicFactor() => MelanopicFactor != null;
    }
}