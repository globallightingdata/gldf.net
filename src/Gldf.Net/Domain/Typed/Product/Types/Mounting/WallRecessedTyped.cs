namespace Gldf.Net.Domain.Typed.Product.Types.Mounting;

public class WallRecessedTyped
{
    public int RecessedDepth { get; set; }

    public CircularCutoutTyped CircularCutout { get; set; }

    public RectangularCutoutTyped RectangularCutout { get; set; }
}