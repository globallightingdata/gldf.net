using Gldf.Net.Domain.Global;
using Gldf.Net.Domain.Product.Types;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
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

        public Locale[] Name { get; set; }

        public Rotation Rotation { get; set; }

        [XmlIgnore]
        public bool EmergencyBehaviourSpecified { get; set; }

        private EmergencyBehaviour _emergencyBehaviour;
    }

}