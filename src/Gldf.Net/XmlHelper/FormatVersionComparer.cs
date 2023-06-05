using Gldf.Net.Domain.Xml.Head.Types;
using System.Collections.Generic;

namespace Gldf.Net.XmlHelper;

public class FormatVersionComparer : IComparer<FormatVersion>
{
    public static readonly IComparer<FormatVersion> Instance = new FormatVersionComparer();

    public int Compare(FormatVersion x, FormatVersion y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (x is null) return -1;
        if (y is null) return 1;
        var majorComparison = x.Major.CompareTo(y.Major);
        if (majorComparison != 0) return majorComparison;
        var minorComparison = x.Minor.CompareTo(y.Minor);
        if (minorComparison != 0) return minorComparison;
        return (x.PreReleaseSpecified, y.PreReleaseSpecified) switch
        {
            (false, false) => 0,
            (true, false) => -1,
            (false, true) => 1,
            _ => x.PreRelease.CompareTo(y.PreRelease)
        };
    }
}