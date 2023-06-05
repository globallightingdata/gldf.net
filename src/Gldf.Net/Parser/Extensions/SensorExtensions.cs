using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Parser.Extensions;

public static class SensorExtensions
{
    public static SensorTyped GetTyped(
        this IEnumerable<SensorTyped> sensors, SensorReference reference) =>
        sensors.FirstOrDefault(sensor => sensor.Id.Equals(reference?.SensorId, StringComparison.Ordinal));
}