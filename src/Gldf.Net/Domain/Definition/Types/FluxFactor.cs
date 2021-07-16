using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public class FluxFactor
    {
        [XmlAttribute("inputPower")]
        public double InputPower { get; set; }

        [XmlAttribute("description")]
        public string Description { get; set; }

        [XmlText]
        public double Factor { get; set; }
    }
}