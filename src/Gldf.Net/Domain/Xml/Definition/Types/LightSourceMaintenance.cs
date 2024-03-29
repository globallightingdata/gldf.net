﻿using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition.Types;

public class LightSourceMaintenance
{
    private int _lifetime;

    [XmlAttribute("lifetime")]
    public int Lifetime
    {
        get => _lifetime;
        set
        {
            _lifetime = value;
            LifetimeSpecified = value > 0;
        }
    }

    [XmlElement("Cie97LampType", typeof(Cie97LampType))]
    [XmlElement("CieLampMaintenanceFactors", typeof(CieLampMaintenanceFactors))]
    [XmlElement("LedMaintenanceFactor", typeof(LedMaintenanceFactor))]
    public LightSourceMaintenanceTypeBase MaintenanceType { get; set; }

    [XmlIgnore]
    public bool LifetimeSpecified { get; set; }

    public Cie97LampType GetAsCie97LampType() => MaintenanceType as Cie97LampType;

    public CieLampMaintenanceFactors GetAsLampMaintenanceFactors() => MaintenanceType as CieLampMaintenanceFactors;

    public LedMaintenanceFactor GetAsLedMaintenanceFactor() => MaintenanceType as LedMaintenanceFactor;
}