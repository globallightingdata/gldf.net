using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Parser.Extensions;
using Gldf.Net.Parser.State;
using System.Linq;

namespace Gldf.Net.Parser
{
    internal class ModelGeometryTransform
    {
        public static ModelGeometryTransform Instance { get; } = new();

        public ParserDto<ModelGeometryTyped> Map(ParserDto<GldfFileTyped> filesDto)
        {
            var parserDto = new ParserDto<ModelGeometryTyped>(filesDto);
            if (filesDto.Container.Product.GeneralDefinitions.Geometries?.OfType<ModelGeometry>().Any() != true) return parserDto;
            foreach (var modelGeometry in filesDto.Container.Product.GeneralDefinitions.Geometries.OfType<ModelGeometry>())
                parserDto.Items.Add(Map(modelGeometry, filesDto));
            return parserDto;
        }

        private static ModelGeometryTyped Map(ModelGeometry modelGeometry, ParserDto<GldfFileTyped> files) =>
            new()
            {
                Id = modelGeometry.Id,
                GeometryFiles = modelGeometry.GeometryFileReferences.Select(reference => MapFileReference(reference, files)).ToArray()
            };

        private static ModelFileTyped MapFileReference(GeometryFileReference fileReference, ParserDto<GldfFileTyped> files)
        {
            var gldfFileTyped = files.GetFileTyped(fileReference.FileId);
            return new ModelFileTyped
            {
                Id = fileReference.FileId,
                FileName = gldfFileTyped.FileName,
                Uri = gldfFileTyped.Uri,
                ContentType = gldfFileTyped.ContentType,
                Type = gldfFileTyped.Type,
                Language = gldfFileTyped.Language,
                BinaryContent = gldfFileTyped.BinaryContent,
                LevelOfDetail = fileReference.LevelOfDetail
            };
        }
    }
}