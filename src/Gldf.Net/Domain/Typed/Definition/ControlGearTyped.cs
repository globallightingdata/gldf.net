using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Typed.Global;
using Gldf.Net.Domain.Xml.Definition.Types;

namespace Gldf.Net.Domain.Typed.Definition;

public class ControlGearTyped : TypedBase
{
    public LocaleTyped[] Name { get; set; }

    public LocaleTyped[] Description { get; set; }

    public VoltageTyped NominalVoltage { get; set; }

    public double? StandbyPower { get; set; }

    public double? ConstantLightOutputStartPower { get; set; }

    public double? ConstantLightOutputEndPower { get; set; }

    public double? PowerConsumptionControls { get; set; }

    public bool? IsDimmable { get; set; }

    public bool? IsColorControllable { get; set; }

    public Interface[] Interfaces { get; set; }

    public EnergyLabelTyped[] EnergyLabels { get; set; }
}