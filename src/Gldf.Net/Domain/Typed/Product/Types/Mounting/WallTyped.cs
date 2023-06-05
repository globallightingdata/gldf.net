namespace Gldf.Net.Domain.Typed.Product.Types.Mounting;

public class WallTyped
{
    public int MountingHeight { get; set; }

    public WallRecessedTyped Recessed { get; set; }

    public WallSurfaceMountedTyped SurfaceMounted { get; set; }
}