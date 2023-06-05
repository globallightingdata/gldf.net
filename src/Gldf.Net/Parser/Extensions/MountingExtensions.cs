using Gldf.Net.Domain.Typed.Product.Types.Mounting;
using Gldf.Net.Domain.Xml.Product.Types.Mounting;

namespace Gldf.Net.Parser.Extensions;

public static class MountingExtensions
{
    public static MountingsTyped ToTyped(this Mountings mountings) =>
        new()
        {
            Ceiling = mountings.Ceiling != null ? MapCeiling(mountings.Ceiling) : null,
            Wall = mountings.Wall != null ? MapWall(mountings.Wall) : null,
            WorkingPlane = mountings.WorkingPlane != null ? MapWorkingPlane(mountings.WorkingPlane) : null,
            Ground = mountings.Ground != null ? MapGround(mountings.Ground) : null
        };

    private static CeilingTyped MapCeiling(Ceiling ceiling) =>
        new()
        {
            Recessed = ceiling.Recessed != null
                ? new RecessedTyped
                {
                    RecessedDepth = ceiling.Recessed.RecessedDepth,
                    CircularCutout = ceiling.Recessed.Cutout is CircularCutout circularCutout
                        ? new CircularCutoutTyped
                        {
                            Diameter = circularCutout.Diameter,
                            Depth = circularCutout.Depth
                        }
                        : null,
                    RectangularCutout = ceiling.Recessed.Cutout is RectangularCutout rectangularCutout
                        ? new RectangularCutoutTyped
                        {
                            Width = rectangularCutout.Width,
                            Length = rectangularCutout.Length,
                            Depth = rectangularCutout.Depth
                        }
                        : null
                }
                : null,
            SurfaceMounted = ceiling.SurfaceMounted != null
                ? new SurfaceMountedTyped()
                : null,
            Pendant = ceiling.Pendant != null
                ? new PendantTyped { PendantLength = ceiling.Pendant.PendantLength }
                : null
        };

    private static WallTyped MapWall(Wall wall) =>
        new()
        {
            MountingHeight = wall.MountingHeight,
            Recessed = wall.Recessed != null
                ? new WallRecessedTyped
                {
                    RecessedDepth = wall.Recessed.RecessedDepth,
                    CircularCutout = wall.Recessed.Cutout is CircularCutout circularCutout
                        ? new CircularCutoutTyped
                        {
                            Diameter = circularCutout.Diameter,
                            Depth = circularCutout.Depth
                        }
                        : null,
                    RectangularCutout = wall.Recessed.Cutout is RectangularCutout rectangularCutout
                        ? new RectangularCutoutTyped
                        {
                            Width = rectangularCutout.Width,
                            Length = rectangularCutout.Length,
                            Depth = rectangularCutout.Depth
                        }
                        : null
                }
                : null,
            SurfaceMounted = wall.SurfaceMounted != null
                ? new WallSurfaceMountedTyped()
                : null
        };

    private static WorkingPlaneTyped MapWorkingPlane(WorkingPlane workingPlane) =>
        new()
        {
            FreeStanding = workingPlane.FreeStanding != null
                ? new FreeStandingTyped()
                : null
        };

    private static GroundTyped MapGround(Ground ground) =>
        new()
        {
            Recessed = ground.Recessed != null
                ? new RecessedTyped
                {
                    RecessedDepth = ground.Recessed.RecessedDepth,
                    CircularCutout = ground.Recessed.Cutout is CircularCutout circularCutout
                        ? new CircularCutoutTyped
                        {
                            Diameter = circularCutout.Diameter,
                            Depth = circularCutout.Depth
                        }
                        : null,
                    RectangularCutout = ground.Recessed.Cutout is RectangularCutout rectangularCutout
                        ? new RectangularCutoutTyped
                        {
                            Width = rectangularCutout.Width,
                            Length = rectangularCutout.Length,
                            Depth = rectangularCutout.Depth
                        }
                        : null
                }
                : null,
            SurfaceMounted = ground.SurfaceMounted != null
                ? new SurfaceMountedTyped()
                : null,
            FreeStanding = ground.FreeStanding != null ? new FreeStandingTyped() : null,
            PoleIntegrated = ground.PoleIntegrated != null
                ? new PoleIntegratedTyped
                {
                    PoleHeight = ground.PoleIntegrated.PoleHeightSpecified ? ground.PoleIntegrated.PoleHeight : null
                }
                : null,
            PoleTop = ground.PoleTop != null
                ? new PoleTopTyped
                {
                    PoleHeight = ground.PoleTop.PoleHeightSpecified ? ground.PoleTop.PoleHeight : null
                }
                : null
        };
}