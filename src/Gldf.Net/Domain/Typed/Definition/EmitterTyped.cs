using Gldf.Net.Domain.Typed.Definition.Types;

namespace Gldf.Net.Domain.Typed.Definition
{
    public class EmitterTyped : TypedBase
    {
        public ChangeableLightEmitterTyped[] ChangeableLightEmitters { get; set; }

        public FixedLightEmitterTyped[] FixedLightEmitters { get; set; }

        public SensorEmitterTyped[] SensorEmitters { get; set; }
    }
}