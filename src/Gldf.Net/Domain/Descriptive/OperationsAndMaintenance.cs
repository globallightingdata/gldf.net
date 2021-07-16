using Gldf.Net.Domain.Descriptive.Types;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Descriptive
{
    public class OperationsAndMaintenance
    {
        [XmlArray("UsefulLifeTimes"), XmlArrayItem("UsefulLife")]
        public string[] UsefulLifeTimes { get; set; }

        [XmlArray("MedianUsefulLifeTimes"), XmlArrayItem("MedianUsefulLife")]
        public string[] MedianUsefulLifeTimes { get; set; }

        public int? RatedAmbientTemperature { get; set; }

        [XmlArrayItem("AbsorptionRate")]
        public AbsorptionRate[] AcousticAbsorptionRates { get; set; }

        public bool ShouldSerializeRatedAmbientTemperature() => RatedAmbientTemperature != null;
    }
}