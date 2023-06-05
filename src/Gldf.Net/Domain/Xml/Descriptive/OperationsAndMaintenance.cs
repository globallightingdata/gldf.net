using Gldf.Net.Domain.Xml.Descriptive.Types;
using Gldf.Net.Domain.Xml.Descriptive.Types.Atex;
using Gldf.Net.Domain.Xml.Global;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Descriptive;

public class OperationsAndMaintenance
{
    [XmlArray("UsefulLifeTimes"), XmlArrayItem("UsefulLife")]
    public string[] UsefulLifeTimes { get; set; }

    [XmlArray("MedianUsefulLifeTimes"), XmlArrayItem("MedianUsefulLife")]
    public string[] MedianUsefulLifeTimes { get; set; }
        
    public TemperatureRange OperatingTemperature { get; set; }
        
    public TemperatureRange AmbientTemperature { get; set; }

    public int? RatedAmbientTemperature { get; set; }

    [XmlElement(ElementName = "ATEX")]
    public Atex Atex { get; set; }

    [XmlArrayItem("AbsorptionRate")]
    public AbsorptionRate[] AcousticAbsorptionRates { get; set; }

    public bool ShouldSerializeRatedAmbientTemperature() => RatedAmbientTemperature != null;
}