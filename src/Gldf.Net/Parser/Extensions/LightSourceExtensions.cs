using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Parser.Extensions;

public static class LightSourceExtensions
{
    public static ChangeableLightSourceTyped GetChangeableTyped(
        this IEnumerable<ChangeableLightSourceTyped> lightSources, LightSourceReference reference) =>
        lightSources.FirstOrDefault(lightSource => lightSource.Id.Equals(reference?.ChangeableLightSourceId, StringComparison.Ordinal));

    public static FixedLightSourceTyped GetFixedTyped(
        this IEnumerable<FixedLightSourceTyped> lightSources, FixedLightSourceReference reference) =>
        lightSources.FirstOrDefault(lightSource => lightSource.Id.Equals(reference?.FixedLightSourceId, StringComparison.Ordinal));

    public static MultiChannelLightSourceTyped GetMultiChannelTyped(
        this IEnumerable<MultiChannelLightSourceTyped> lightSources, MultiChannelLightSourceReference reference) =>
        lightSources.FirstOrDefault(lightSource => lightSource.Id.Equals(reference?.MultiChannelLightSourceId, StringComparison.Ordinal));
}