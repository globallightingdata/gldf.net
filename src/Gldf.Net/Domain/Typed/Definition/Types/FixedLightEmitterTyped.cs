namespace Gldf.Net.Domain.Typed.Definition.Types;

public class FixedLightEmitterTyped : EmitterTypedBase
{
    public PhotometryTyped Photometry { get; set; }
    
    public FixedLightSourceTyped FixedLightSource { get; set; }

    public int? ControlGearCount { get; set; }
    
    public ControlGearTyped ControlGear { get; set; }

    public int RatedLuminousFlux { get; set; }

    // ReSharper disable InconsistentNaming
    public int? RatedLuminousFluxRGB { get; set; }

    public double? EmergencyBallastLumenFactor { get; set; }

    public int? EmergencyRatedLuminousFlux { get; set; }
}