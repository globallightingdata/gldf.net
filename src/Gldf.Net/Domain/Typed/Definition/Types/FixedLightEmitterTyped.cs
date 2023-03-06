using Gldf.Net.Domain.Typed.Global;
using Gldf.Net.Domain.Xml.Product.Types;

namespace Gldf.Net.Domain.Typed.Definition.Types;

public class FixedLightEmitterTyped
{
    public LocaleTyped[] Name { get; set; }

    public RotationTyped Rotation { get; set; }

    public PhotometryTyped Photometry { get; set; }
    
    public EmergencyBehaviour? EmergencyBehaviour { get; set; }

    public FixedLightSourceTyped FixedLightSource { get; set; }

    public int? ControlGearCount { get; set; }
    
    public ControlGearTyped ControlGear { get; set; }

    public int RatedLuminousFlux { get; set; }

    // ReSharper disable InconsistentNaming
    public int? RatedLuminousFluxRGB { get; set; }

    public double? EmergencyBallastLumenFactor { get; set; }

    public int? EmergencyRatedLuminousFlux { get; set; }
}