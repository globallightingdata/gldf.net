namespace Gldf.Net.Domain.Typed.Definition.Types;

public class MultiChannelLightEmitterTyped : EmitterTypedBase
{
    public MultiChannelLightSourceTyped MultiChannelLightSource { get; set; }

    public ControlGearTyped ControlGear { get; set; }
    
    public int? ControlGearCount { get; set; }
}