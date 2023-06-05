namespace Gldf.Net.Domain.Typed.Definition.Types;

public class LightSourceMaintenanceTyped
{
    public int? Lifetime { get; set; }

    public Cie97LampTypeTyped Cie97LampType { get; set; }

    public CieLampMaintenanceFactorTyped[] CieLampMaintenanceFactor { get; set; }

    public LedMaintenanceFactorTyped LedMaintenanceFactor { get; set; }
}