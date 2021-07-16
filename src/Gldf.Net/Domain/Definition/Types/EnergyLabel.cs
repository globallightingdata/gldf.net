using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public class EnergyLabel
    {
        [XmlAttribute(AttributeName = "region")]
        public string Region { get; set; }

        [XmlText]
        public string Label { get; set; }
    }
}