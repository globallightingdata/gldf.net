using Gldf.Net.Domain.Typed.Definition.Types;

namespace Gldf.Net.Domain.Typed.Definition
{
    public class PhotometryTyped : TypedBase
    {
        public GldfFileTyped PhotometryFile { get; set; }

        public DescriptivePhotometryTyped DescriptivePhotometry { get; set; }
    }
}