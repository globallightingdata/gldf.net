using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Parser.DataFlow;
using System.Linq;

namespace Gldf.Net.Parser;

internal class SimpleGeometryTransform : TransformBase
{
    public static ParserDto Map(ParserDto parserDto)
    {
        return ExecuteSafe(() =>
        {
            var geometries = parserDto.Container.Product.GeneralDefinitions.Geometries;
            if (geometries?.OfType<SimpleGeometry>().Any() != true) return parserDto;
            parserDto.GeneralDefinitions.SimpleGeometries = geometries.OfType<SimpleGeometry>().Select(Map).ToList();
            return parserDto;
        }, parserDto);
    }

    private static SimpleGeometryTyped Map(SimpleGeometry simpleGeometry)
    {
        return new SimpleGeometryTyped
        {
            Id = simpleGeometry.Id,
            CuboidGeometry = simpleGeometry.GeometryType is SimpleCuboidGeometry cuboidGeometry
                ? new SimpleCuboidGeometryTyped
                {
                    Width = cuboidGeometry.Width,
                    Length = cuboidGeometry.Length,
                    Height = cuboidGeometry.Height
                }
                : null,
            CylinderGeometry = simpleGeometry.GeometryType is SimpleCylinderGeometry cylinderGeometry
                ? new SimpleCylinderGeometryTyped
                {
                    Diameter = cylinderGeometry.Diameter,
                    Height = cylinderGeometry.Height,
                    Plane = cylinderGeometry.Plane
                }
                : null,
            RectangularEmitter = simpleGeometry.EmitterType is SimpleRectangularEmitter rectangularEmitter
                ? new SimpleRectangularEmitterTyped
                {
                    Width = rectangularEmitter.Width,
                    Length = rectangularEmitter.Length
                }
                : null,
            CircularEmitter = simpleGeometry.EmitterType is SimpleCircularEmitter circularEmitter
                ? new SimpleCircularEmitterTyped
                {
                    Diameter = circularEmitter.Diameter
                }
                : null,
            CHeights = simpleGeometry.CHeights != null
                ? new CHeightsTyped
                {
                    C0 = simpleGeometry.CHeights.C0,
                    C90 = simpleGeometry.CHeights.C90,
                    C180 = simpleGeometry.CHeights.C180,
                    C270 = simpleGeometry.CHeights.C270
                }
                : null
        };
    }
}