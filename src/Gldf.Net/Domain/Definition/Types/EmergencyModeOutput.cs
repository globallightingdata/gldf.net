using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public abstract class EmergencyModeOutput
    {
    }

    public class EmergencyRatedLuminousFlux : EmergencyModeOutput
    {
        [XmlText]
        public int Flux { get; set; }
    }

    public class EmergencyBallastLumenFactor : EmergencyModeOutput
    {
        [XmlText]
        public double Factor { get; set; }
    }
}