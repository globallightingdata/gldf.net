using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition.Types
{
    public class EmergencyBallastLumenFactor : EmergencyModeOutputBase
    {
        [XmlText]
        public double Factor { get; set; }
    }
}