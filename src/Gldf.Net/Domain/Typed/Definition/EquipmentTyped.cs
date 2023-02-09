using Gldf.Net.Domain.Typed.Definition.Types;

// ReSharper disable InconsistentNaming

namespace Gldf.Net.Domain.Typed.Definition
{
    public class EquipmentTyped : TypedBase
    {
        public int? ChangeableLightSourceCount { get; set; }
        
        public ChangeableLightSourceTyped ChangeableLightSource { get; set; }
        
        public int? LightSourceCount { get; set; }

        public ControlGearTyped ControlGear { get; set; }
        
        public int? ControlGearCount { get; set; }

        public double RatedInputPower { get; set; }

        public EmergencyBallastLumenFactorTyped EmergencyBallastLumenFactor { get; set; }

        public EmergencyRatedLuminousFluxTyped EmergencyRatedLuminousFlux { get; set; }
    }
}