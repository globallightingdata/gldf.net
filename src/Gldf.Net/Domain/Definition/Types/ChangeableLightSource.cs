using Gldf.Net.Domain.Global;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public class ChangeableLightSource : LightSourceType
    {
        public string Manufacturer { get; set; }

        [XmlElement(ElementName = "GTIN")]
        public string Gtin { get; set; }

        [XmlElement(ElementName = "ILCOS")]
        public string Ilcos { get; set; }

        [XmlElement(ElementName = "ZVEI")]
        public string Zvei { get; set; }

        public string Socket { get; set; }

        public double RatedInputPower { get; set; }

        public Voltage RatedInputVoltage { get; set; }

        public int RatedLuminousFlux { get; set; }

        public LightSourcePowerRange PowerRange { get; set; }

        public string LightSourcePositionOfUsage { get; set; }

        [XmlArrayItem("EnergyLabel")]
        public EnergyLabel[] EnergyLabels { get; set; }
    }
}