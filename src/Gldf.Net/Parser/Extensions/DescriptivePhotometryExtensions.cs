using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Xml.Definition.Types;

namespace Gldf.Net.Parser.Extensions;

public static class DescriptivePhotometryExtensions
{
    public static TenthPeakDivergenceTyped ToTyped(this TenthPeakDivergence tenthPeakDivergence) =>
        new()
        {
            C0C180 = tenthPeakDivergence.C0C180,
            C90C270 = tenthPeakDivergence.C90C270
        };

    public static HalfPeakDivergenceTyped ToTyped(this HalfPeakDivergence halfPeakDivergence) =>
        new()
        {
            C0C180 = halfPeakDivergence.C0C180,
            C90C270 = halfPeakDivergence.C90C270
        };

    public static Ugr4H8HTyped ToTyped(this Ugr4H8H ugr4H8H) =>
        new()
        {
            X = ugr4H8H.X,
            Y = ugr4H8H.Y
        };
}