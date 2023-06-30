namespace Gldf.Net.Domain.Typed.Definition.Types;

public class ChangeableLightEmitterTyped : EmitterTypedBase
{
    public PhotometryTyped Photometry { get; set; }

    public EquipmentTyped Equipment { get; set; }
}