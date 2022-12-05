using Gldf.Net.Domain.Typed.Definition;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Parser.Extensions;

public static class PhotometryExtensions
{
    public static PhotometryTyped GetTyped(this IEnumerable<PhotometryTyped> photometries, string id) =>
        photometries.FirstOrDefault(photometry => photometry.Id.Equals(id, StringComparison.Ordinal));
}