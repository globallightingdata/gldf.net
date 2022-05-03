using Gldf.Net.Domain.Global;

namespace Gldf.Net.Domain.Definition.Types
{
    public abstract class EmitterBase
    {
        public Locale[] Name { get; set; }

        public Rotation Rotation { get; set; }
        
        public PhotometryReference PhotometryReference { get; set; }
    }
}