using Gldf.Net.Domain.Typed.Global;
using Gldf.Net.Domain.Xml.Product.Types;

namespace Gldf.Net.Domain.Typed.Definition.Types;

public class ChangeableLightEmitterTyped
{
    public LocaleTyped[] Name { get; set; }

    public RotationTyped Rotation { get; set; }

    public PhotometryTyped Photometry { get; set; }
    
    public EmergencyBehaviour? EmergencyBehaviour { get; set; }

    public EquipmentTyped Equipment { get; set; }
}