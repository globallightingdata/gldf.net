using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Parser.Extensions;

public static class ControlGearExtensions
{
    public static ControlGearTyped GetTyped(this IEnumerable<ControlGearTyped> controlGears, ControlGearReference reference) =>
        controlGears.FirstOrDefault(controlGear => controlGear.Id.Equals(reference?.ControlGearId, StringComparison.Ordinal));
}