using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Xml.Definition.Types;
using System.Linq;

namespace Gldf.Net.Parser.Extensions;

public static class LightSourceMaintenanceExtensions
{
    public static LightSourceMaintenanceTyped ToTyped(this LightSourceMaintenance maintenance) =>
        new()
        {
            Lifetime = maintenance.LifetimeSpecified ? maintenance.Lifetime : null,
            Cie97LampType = maintenance.MaintenanceType is Cie97LampType cie
                ? new Cie97LampTypeTyped { Cie97LampTypeEnum = cie.Cie97LampTypeEnum }
                : null,
            CieLampMaintenanceFactor = maintenance.MaintenanceType is CieLampMaintenanceFactors factors
                ? factors.CieLampMaintenanceFactor.Select(factor => new CieLampMaintenanceFactorTyped
                {
                    BurningTime = factor.BurningTime,
                    LampLumenMaintenanceFactor = factor.LampLumenMaintenanceFactor,
                    LampSurvivalFactor = factor.LampSurvivalFactor
                }).ToArray()
                : null,
            LedMaintenanceFactor = maintenance.MaintenanceType is LedMaintenanceFactor ledFactor
                ? new LedMaintenanceFactorTyped { Factor = ledFactor.Factor, Hours = ledFactor.Hours }
                : null
        };
}