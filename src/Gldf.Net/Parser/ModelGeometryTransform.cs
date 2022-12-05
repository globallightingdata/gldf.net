using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Parser.DataFlow;
using Gldf.Net.Parser.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Parser;

internal class ModelGeometryTransform : TransformBase
{
    public static ParserDto Map(ParserDto parserDto)
    {
        return ExecuteSafe(() =>
        {
            var geometries = parserDto.Container.Product.GeneralDefinitions.Geometries?.OfType<ModelGeometry>().ToList();
            if (geometries?.Any() != true) return parserDto;
            foreach (var modelGeometry in geometries)
                parserDto.GeneralDefinitions.ModelGeometries.Add(Map(modelGeometry, parserDto.GeneralDefinitions.Files));
            return parserDto;
        }, parserDto);
    }

    private static ModelGeometryTyped Map(ModelGeometry modelGeometry, IEnumerable<GldfFileTyped> files) =>
        new()
        {
            Id = modelGeometry.Id,
            GeometryFiles = MapFileReferences(modelGeometry.GeometryFileReferences, files).ToArray()
        };

    private static IEnumerable<ModelFileTyped> MapFileReferences(IEnumerable<GeometryFileReference> refs, IEnumerable<GldfFileTyped> files)
    {
        if (refs == null) return null;
        return from reference in refs
            let gldfFileTyped = files.ToFileTyped(reference.FileId)
            where gldfFileTyped != null
            select new ModelFileTyped(gldfFileTyped, reference.LevelOfDetailSpecified ? reference.LevelOfDetail : null);
    }
}