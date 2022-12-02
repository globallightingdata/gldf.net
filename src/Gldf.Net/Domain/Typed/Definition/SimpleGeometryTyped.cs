using Gldf.Net.Domain.Typed.Definition.Types;

namespace Gldf.Net.Domain.Typed.Definition
{
    public class SimpleGeometryTyped : TypedBase
    {
        public SimpleCuboidGeometryTyped CuboidGeometry { get; set; }

        public SimpleCylinderGeometryTyped CylinderGeometry { get; set; }

        public SimpleRectangularEmitterTyped RectangularEmitter { get; set; }

        public SimpleCircularEmitterTyped CircularEmitter { get; set; }

        public CHeightsTyped CHeights { get; set; }
    }
}