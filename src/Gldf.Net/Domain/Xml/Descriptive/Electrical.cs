using Gldf.Net.Domain.Xml.Descriptive.Types;

// ReSharper disable InconsistentNaming

namespace Gldf.Net.Domain.Xml.Descriptive;

public class Electrical
{
    public ClampingRange ClampingRange { get; set; }

    public string SwitchingCapacity { get; set; }

    public SafetyClass? ElectricalSafetyClass { get; set; }

    public IngressProtectionIPCode? IngressProtectionIPCode { get; set; }

    public double? PowerFactor { get; set; }

    public bool? ConstantLightOutput { get; set; }

    public LightDistribution? LightDistribution { get; set; }

    public bool ShouldSerializeElectricalSafetyClass() => ElectricalSafetyClass != null;

    public bool ShouldSerializeIngressProtectionIPCode() => IngressProtectionIPCode != null;

    public bool ShouldSerializePowerFactor() => PowerFactor != null;

    public bool ShouldSerializeConstantLightOutput() => ConstantLightOutput != null;
        
    public bool ShouldSerializeLightDistribution() => LightDistribution != null;
}