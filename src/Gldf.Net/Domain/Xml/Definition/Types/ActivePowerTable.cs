using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition.Types;

public class ActivePowerTable
{
    [XmlAttribute("type")]
    public ActivePowerTableType Type { get; set; }

    [XmlElement("FluxFactor")]
    public FluxFactor[] FluxFactor { get; set; }
}