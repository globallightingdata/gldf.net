using Gldf.Net.Domain.Typed.Global;
using Gldf.Net.Domain.Xml.Product.Types;

namespace Gldf.Net.Domain.Typed.Definition.Types;

public class EmitterTypedBase
{
    public EmergencyBehaviour? EmergencyBehaviour { get; set; }
    
    public LocaleTyped[] Name { get; set; }

    public RotationTyped Rotation { get; set; }
}