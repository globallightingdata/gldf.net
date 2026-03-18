namespace Gldf.Net.Domain.Typed.Definition;

public class EquipmentTyped : TypedBase
{
    public ChangeableLightSourceTyped ChangeableLightSource { get; set; }

    public int? LightSourceCount { get; set; }

    public ControlGearTyped ControlGear { get; set; }

    public int? ControlGearCount { get; set; }

    public double RatedInputPower { get; set; }

    public double? EmergencyBallastLumenFactor { get; set; }

    public int? EmergencyRatedLuminousFlux { get; set; }
}