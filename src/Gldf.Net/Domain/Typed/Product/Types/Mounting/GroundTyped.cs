namespace Gldf.Net.Domain.Typed.Product.Types.Mounting;

public class GroundTyped
{
    public PoleTopTyped PoleTop { get; set; }

    public PoleIntegratedTyped PoleIntegrated { get; set; }

    public FreeStandingTyped FreeStanding { get; set; }

    public SurfaceMountedTyped SurfaceMounted { get; set; }

    public RecessedTyped Recessed { get; set; }
}