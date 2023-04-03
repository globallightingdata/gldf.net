using Gldf.Net.Domain.Typed.Definition.Types;

namespace Gldf.Net.Domain.Typed.Definition;

public class ChangeableLightSourceTyped : LightSourceBaseTyped
{
    public string Zvei { get; set; }

    public string Socket { get; set; }

    public string Ilcos { get; set; }

    public int RatedLuminousFlux { get; set; }

    // ReSharper disable InconsistentNaming
    public int? RatedLuminousFluxRGB { get; set; }

    public PhotometryTyped Photometry { get; set; }

    public LightSourceMaintenanceTyped Maintenance { get; set; }
}