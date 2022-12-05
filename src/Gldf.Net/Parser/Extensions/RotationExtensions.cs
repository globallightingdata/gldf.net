using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Xml.Definition.Types;

namespace Gldf.Net.Parser.Extensions;

public static class RotationExtensions
{
    public static RotationTyped ToTyped(this Rotation rotation) =>
        new()
        {
            X = rotation.X,
            Y = rotation.Y,
            Z = rotation.Z,
            G0 = rotation.G0
        };
}