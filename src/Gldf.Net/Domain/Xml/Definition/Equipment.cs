using Gldf.Net.Domain.Xml.Definition.Types;
using System.Xml.Serialization;

// ReSharper disable InconsistentNaming

namespace Gldf.Net.Domain.Xml.Definition
{
    public class Equipment
    {
        [XmlAttribute(DataType = "ID", AttributeName = "id")]
        public string Id { get; set; }

        public LightSourceReference LightSourceReference { get; set; }

        public ControlGearReference ControlGearReference { get; set; }

        public double RatedInputPower { get; set; }

        [XmlElement("EmergencyBallastLumenFactor", typeof(EmergencyBallastLumenFactor))]
        [XmlElement("EmergencyRatedLuminousFlux", typeof(EmergencyRatedLuminousFlux))]
        public EmergencyModeOutputBase EmergencyModeOutput { get; set; }

        [XmlIgnore]
        public bool EmergencyBehaviourSpecified { get; set; }

        public EmergencyBallastLumenFactor GetEmergencyModeOutputAsLumenFactor() =>
            EmergencyModeOutput as EmergencyBallastLumenFactor;

        public EmergencyRatedLuminousFlux GetEmergencyModeOutputAsLuminousFlux() =>
            EmergencyModeOutput as EmergencyRatedLuminousFlux;
    }
}