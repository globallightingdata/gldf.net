using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition.Types;

public class EmergencyRatedLuminousFlux : EmergencyModeOutputBase
{
    [XmlText]
    public int Flux { get; set; }
}