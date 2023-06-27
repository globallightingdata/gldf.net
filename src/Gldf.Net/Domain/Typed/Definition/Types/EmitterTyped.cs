namespace Gldf.Net.Domain.Typed.Definition.Types;

public class EmitterTyped : TypedBase
{
    public ChangeableLightEmitterTyped[] ChangeableEmitterOptions { get; set; }

    public FixedLightEmitterTyped[] FixedEmitterOptions { get; set; }

    public MultiChannelLightEmitterTyped[] MultiChannelEmitterOptions { get; set; }

    public SensorEmitterTyped[] SensorEmitterOptions { get; set; }
}