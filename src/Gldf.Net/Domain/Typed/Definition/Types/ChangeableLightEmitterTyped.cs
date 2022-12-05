using Gldf.Net.Domain.Xml.Product.Types;

namespace Gldf.Net.Domain.Typed.Definition.Types;

public class ChangeableLightEmitterTyped : EmitterBaseTyped
{
    public EmergencyBehaviour? EmergencyBehaviour { get; set; }

    public EquipmentTyped Equipment { get; set; }
}