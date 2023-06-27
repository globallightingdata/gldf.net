using Gldf.Net.Domain.Xml.Product.Types;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition.Types;

public class MultiChannelLightEmitter : EmitterBase
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

    public MultiChannelLightSourceReference LightSourceReference { get; set; }

    public ControlGearReference ControlGearReference { get; set; }

    [XmlIgnore]
    public bool EmergencyBehaviourSpecified { get; set; }

    private EmergencyBehaviour _emergencyBehaviour;
}