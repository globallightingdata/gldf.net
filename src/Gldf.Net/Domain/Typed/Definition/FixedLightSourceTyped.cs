using Gldf.Net.Domain.Typed.Definition.Types;

namespace Gldf.Net.Domain.Typed.Definition;

public class FixedLightSourceTyped : LightSourceBaseTyped
{
    public SpectrumTyped Spectrum { get; set; }

    public ActivePowerTableTyped ActivePowerTable { get; set; }

    public ColorInformationTyped ColorInformation { get; set; }

    public ImageFileTyped[] LightSourceImages { get; set; }
    
    public LightSourceMaintenanceTyped Maintenance { get; set; }

    public bool? ZhagaStandard { get; set; }
}