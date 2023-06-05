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
            var modelGeometries = parserDto.Container.Product.GeneralDefinitions.GetAsModelGeometries();
            if (!modelGeometries.Any()) return parserDto;
            parserDto.GeneralDefinitions.ModelGeometries = modelGeometries.Select(x => Map(x, parserDto.GeneralDefinitions.Files)).ToList();
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
        if (refs == null) return Enumerable.Empty<ModelFileTyped>();
        return from reference in refs
            let gldfFileTyped = files.ToFileTyped(reference.FileId)
            where gldfFileTyped != null
            select new ModelFileTyped(gldfFileTyped, reference.LevelOfDetailSpecified ? reference.LevelOfDetail : null);
    }
}