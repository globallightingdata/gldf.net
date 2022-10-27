using Gldf.Net.Domain.Xml.Product.Types;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition.Types
{
    public class ChangeableLightEmitter : EmitterBase
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

        public EquipmentReference EquipmentReference { get; set; }

        [XmlIgnore]
        public bool EmergencyBehaviourSpecified { get; set; }

        private EmergencyBehaviour _emergencyBehaviour;
    }
}