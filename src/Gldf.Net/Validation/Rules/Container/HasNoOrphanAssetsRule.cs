using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Domain.Definition;
using Gldf.Net.Domain.Definition.Types;
using Gldf.Net.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Validation.Rules.Container
{
    internal class HasNoOrphanAssetsRule : IContainerValidationRule
    {
        public int Priority => 110;

        public IEnumerable<ValidationHint> Validate(GldfContainer container)
        {
            try
            {
                var filesWithAssets = container.Product.GeneralDefinitions.Files.Where(file =>
                    file.Type == FileType.LocalFileName).Select(file => GetAsset(file, container.Assets));
                var orpahnedAssets = container.Assets.All.Except(filesWithAssets).ToList();

                return orpahnedAssets.Any()
                    ? ValidationHint.Warning("The GLDF container contains assets that are not referenced in the " +
                                             "product.xml. They should be deleted: " +
                                             $"{FlattenFileNames(orpahnedAssets)}", ErrorType.OrphanedContainerAssets)
                    : ValidationHint.Empty();
            }
            catch (Exception e)
            {
                return ValidationHint.Warning("The GLDF container could not be validate to contain no orphan files. " +
                                              $"Error: {e.FlattenMessage()}", ErrorType.OrphanedContainerAssets);
            }
        }

        private static ContainerFile GetAsset(GldfFile file, GldfAssets assets)
        {
            static ContainerFile FindAsset(IEnumerable<ContainerFile> assets, GldfFile file) =>
                assets.FirstOrDefault(asset => asset.FileName == file.File);

            return file.ContentType switch
            {
                FileContentType.LdcEulumdat => FindAsset(assets.Photometries, file),
                FileContentType.LdcIes => FindAsset(assets.Photometries, file),
                FileContentType.LdcIesXml => FindAsset(assets.Photometries, file),
                FileContentType.ImagePng => FindAsset(assets.Images, file),
                FileContentType.ImageJpg => FindAsset(assets.Images, file),
                FileContentType.ImageSvg => FindAsset(assets.Images, file),
                FileContentType.GeoL3d => FindAsset(assets.Geometries, file),
                FileContentType.GeoR3d => FindAsset(assets.Geometries, file),
                FileContentType.GeoM3d => FindAsset(assets.Geometries, file),
                FileContentType.DocPdf => FindAsset(assets.Documents, file),
                FileContentType.SymbolSvg => FindAsset(assets.Symbols, file),
                FileContentType.SymbolDxf => FindAsset(assets.Symbols, file),
                FileContentType.SensorSensXml => FindAsset(assets.Sensors, file),
                FileContentType.SensorSensLdt => FindAsset(assets.Sensors, file),
                FileContentType.SpectrumText => FindAsset(assets.Spectrums, file),
                FileContentType.Other => FindAsset(assets.Other, file),
                _ => throw new ArgumentOutOfRangeException(nameof(file.ContentType))
            };
        }

        private static string FlattenFileNames(IEnumerable<ContainerFile> filesWithoutAssets)
        {
            return filesWithoutAssets.Aggregate(string.Empty, (result, file)
                => result == string.Empty ? $"{file.FileName}" : $"{result}, {file.FileName}");
        }
    }
}