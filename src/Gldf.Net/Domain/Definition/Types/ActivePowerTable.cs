using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public class ActivePowerTable
    {
        [XmlAttribute("type")]
        public ActivePowerTableType Type { get; set; }

        [XmlElement("FluxFactor")]
        public FluxFactor[] FluxFactor { get; set; }
    }
}