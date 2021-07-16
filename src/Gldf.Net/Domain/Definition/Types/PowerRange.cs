using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public class LightSourcePowerRange
    {
        public double Lower { get; set; }

        public double Upper { get; set; }

        [XmlElement(ElementName = "DefaultLightSourcePower")]
        public double Default { get; set; }
    }
}