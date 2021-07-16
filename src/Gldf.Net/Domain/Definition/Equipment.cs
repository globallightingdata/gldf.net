using Gldf.Net.Domain.Definition.Types;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition
{
    public class Equipment
    {
        [XmlAttribute(DataType = "ID", AttributeName = "id")]
        public string Id { get; set; }

        public LightSourceReference LightSourceReference { get; set; }

        public ControlGearReference ControlGearReference { get; set; }

        public double RatedInputPower { get; set; }

        public int RatedLuminousFlux { get; set; }

        [XmlElement("EmergencyBallastLumenFactor", typeof(EmergencyBallastLumenFactor))]
        [XmlElement("EmergencyRatedLuminousFlux", typeof(EmergencyRatedLuminousFlux))]
        public EmergencyModeOutput EmergencyModeOutput { get; set; }

        public EmergencyBallastLumenFactor GetEmergencyModeOutputAsLumenFactor() =>
            EmergencyModeOutput as EmergencyBallastLumenFactor;

        public EmergencyRatedLuminousFlux GetEmergencyModeOutputAsLuminousFlux() =>
            EmergencyModeOutput as EmergencyRatedLuminousFlux;
    }
}