using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public class EmergencyBallastLumenFactor : EmergencyModeOutputBase
    {
        [XmlText]
        public double Factor { get; set; }
    }
}