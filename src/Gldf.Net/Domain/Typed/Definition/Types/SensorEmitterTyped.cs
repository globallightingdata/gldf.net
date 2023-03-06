using Gldf.Net.Domain.Typed.Global;

namespace Gldf.Net.Domain.Typed.Definition.Types
{
    public class SensorEmitterTyped
    {
        public LocaleTyped[] Name { get; set; }

        public RotationTyped Rotation { get; set; }
        
        public SensorTyped Sensor { get; set; }
    }
}