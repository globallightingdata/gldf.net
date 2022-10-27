using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Xml.Definition.Types;
using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Parser.Extensions
{
    public static class SpectrumExtensions
    {
        public static SpectrumIntensityTyped[] ToTypedArray(this IEnumerable<SpectrumIntensity> intensities) =>
            intensities.Select(intensity => new SpectrumIntensityTyped
            {
                Wavelength = intensity.Wavelength,
                Intensity = intensity.Intensity
            }).ToArray();
    }
}