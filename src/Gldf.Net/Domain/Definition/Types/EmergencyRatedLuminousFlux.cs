using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public class EmergencyRatedLuminousFlux : EmergencyModeOutputBase
    {
        [XmlText]
        public int Flux { get; set; }
    }
}