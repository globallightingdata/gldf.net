using Gldf.Net.Domain.Typed.Definition.Types;

namespace Gldf.Net.Domain.Typed.Definition;

public class SpectrumTyped : TypedBase
{
    public GldfFileTyped SpectrumFile { get; set; }

    public SpectrumIntensityTyped[] Intensities { get; set; }
}