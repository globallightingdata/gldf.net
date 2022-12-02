using Gldf.Net.Domain.Typed.Global;

namespace Gldf.Net.Domain.Typed.Definition.Types
{
    public abstract class EmitterBaseTyped
    {
        public LocaleTyped[] Name { get; set; }

        public RotationTyped Rotation { get; set; }

        public PhotometryTyped Photometry { get; set; }
    }
}