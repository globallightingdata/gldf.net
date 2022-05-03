using Gldf.Net.Domain.Product.Types;
using System.Xml.Serialization;

// ReSharper disable InconsistentNaming

namespace Gldf.Net.Domain.Definition.Types
{
    public class FixedLightEmitter : EmitterBase
    {
        [XmlAttribute("emergencyBehaviour")]
        public EmergencyBehaviour EmergencyBehaviour
        {
            get => _emergencyBehaviour;
            set
            {
                _emergencyBehaviour = value;
                EmergencyBehaviourSpecified = true;
            }
        }

        public FixedLightSourceReference LightSourceReference { get; set; }

        public ControlGearReference ControlGearReference { get; set; }

        public int RatedLuminousFlux { get; set; }

        public int? RatedLuminousFluxRGB { get; set; }
        
        [XmlElement("EmergencyBallastLumenFactor", typeof(EmergencyBallastLumenFactor))]
        [XmlElement("EmergencyRatedLuminousFlux", typeof(EmergencyRatedLuminousFlux))]
        public EmergencyModeOutputBase EmergencyModeOutput { get; set; }

        [XmlIgnore]
        public bool EmergencyBehaviourSpecified { get; set; }

        private EmergencyBehaviour _emergencyBehaviour;
        
        public bool ShouldSerializeRatedLuminousFluxRGB() => RatedLuminousFluxRGB != null;
        
        public EmergencyBallastLumenFactor GetEmergencyModeOutputAsLumenFactor() =>
            EmergencyModeOutput as EmergencyBallastLumenFactor;

        public EmergencyRatedLuminousFlux GetEmergencyModeOutputAsLuminousFlux() =>
            EmergencyModeOutput as EmergencyRatedLuminousFlux;
    }
}