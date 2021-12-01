using Gldf.Net.Domain.Definition.Types;
using Gldf.Net.Domain.Global;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Product.Types
{
    public class LightEmitter : EmitterBase
    {
        [XmlAttribute(DataType = "NCName", AttributeName = "photometryId")]
        public string PhotometryId { get; set; }

        [XmlAttribute(DataType = "NCName", AttributeName = "equipmentId")]
        public string EquipmentId { get; set; }

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

        public Locale[] DisplayName { get; set; }

        [XmlIgnore]
        public bool EmergencyBehaviourSpecified { get; set; }

        private EmergencyBehaviour _emergencyBehaviour;
    }
}