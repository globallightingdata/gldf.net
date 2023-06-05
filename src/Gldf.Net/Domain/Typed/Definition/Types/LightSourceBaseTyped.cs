using Gldf.Net.Domain.Typed.Global;

namespace Gldf.Net.Domain.Typed.Definition.Types;

public abstract class LightSourceBaseTyped : TypedBase
{
    public LocaleTyped[] Name { get; set; }

    public LocaleTyped[] Description { get; set; }

    public string Manufacturer { get; set; }

    public string Gtin { get; set; }

    public double RatedInputPower { get; set; }

    public VoltageTyped RatedInputVoltage { get; set; }

    public LightSourcePowerRangeTyped PowerRange { get; set; }

    public string LightSourcePositionOfUsage { get; set; }

    public EnergyLabelTyped[] EnergyLabels { get; set; }

    public SpectrumTyped Spectrum { get; set; }

    public ActivePowerTableTyped ActivePowerTable { get; set; }

    public ColorInformationTyped ColorInformation { get; set; }

    public ImageFileTyped[] LightSourceImages { get; set; }
}