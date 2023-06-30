using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Xml.Definition.Types;
using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Parser.Extensions;

public static class ChannelExtensions
{
    public static ChannelTyped[] ToTypedArray(this IEnumerable<Channel> channels, GeneralDefinitionsTyped definitions) =>
        channels.Select(channel => MapChannel(channel, definitions)).ToArray();

    private static ChannelTyped MapChannel(Channel channel, GeneralDefinitionsTyped definitions) =>
        new()
        {
            Type = channel.Type,
            DisplayName = channel.DisplayName?.ToTypedArray(),
            Spectrum = definitions.Spectrums.GetTyped(channel.SpectrumReference.SpectrumId),
            Photometry = definitions.Photometries.GetTyped(channel.PhotometryReference.PhotometryId),
            RatedLuminousFlux = channel.RatedLuminousFlux,
            ColorInformation = channel.ColorInformation?.ToTyped()
        };
}