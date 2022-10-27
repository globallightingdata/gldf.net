using Gldf.Net.Domain.Xml.Global;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition.Types
{
    public abstract class LightSourceBase
    {
        [XmlAttribute(DataType = "ID", AttributeName = "id")]
        public string Id { get; set; }
        
        public Locale[] Name { get; set; }
        
        public Locale[] Description { get; set; }
        
        public string Manufacturer { get; set; }

        [XmlElement(ElementName = "GTIN")]
        public string Gtin { get; set; }
        
        public double RatedInputPower { get; set; }

        public Voltage RatedInputVoltage { get; set; }
        
        public LightSourcePowerRange PowerRange { get; set; }

        public string LightSourcePositionOfUsage { get; set; }

        [XmlArrayItem("EnergyLabel")]
        public EnergyLabel[] EnergyLabels { get; set; }
        
        public SpectrumReference SpectrumReference { get; set; }

        public ActivePowerTable ActivePowerTable { get; set; }

        public ColorInformation ColorInformation { get; set; }

        public Image[] LightSourceImages { get; set; }
    }
}