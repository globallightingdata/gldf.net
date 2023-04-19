using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Validation.Rules.Container;

internal class HasNoMissingAssetsRule : IContainerValidationRule
{
    public IEnumerable<ValidationHint> Validate(GldfContainer container)
    {
        return ValidateSafe(() =>
        {
            if (container.Product?.GeneralDefinitions?.Files == null) return ValidationHint.Empty();
            var filesWithoutAssets = container.Product.GeneralDefinitions.Files.Where(file =>
                file.Type == FileType.LocalFileName && HasNoAsset(file, container.Assets)).ToArray();

            return filesWithoutAssets.Any()
                ? ValidationHint.Error("The product.xml contains File definitions that are " +
                                       "missing in the GLDF container: " +
                                       $"{FlattenFileNames(filesWithoutAssets)}", ErrorType.MissingContainerAssets)
                : ValidationHint.Empty();
        });
    }

    private static bool HasNoAsset(GldfFile file, GldfAssets assets) =>
        file.ContentType switch
        {
            FileContentType.LdcEulumdat => AssetNotExists(assets.Photometries, file),
            FileContentType.LdcIes => AssetNotExists(assets.Photometries, file),
            FileContentType.LdcIesXml => AssetNotExists(assets.Photometries, file),
            FileContentType.ImagePng => AssetNotExists(assets.Images, file),
            FileContentType.ImageJpg => AssetNotExists(assets.Images, file),
            FileContentType.ImageSvg => AssetNotExists(assets.Images, file),
            FileContentType.GeoL3d => AssetNotExists(assets.Geometries, file),
            FileContentType.GeoR3d => AssetNotExists(assets.Geometries, file),
            FileContentType.GeoM3d => AssetNotExists(assets.Geometries, file),
            FileContentType.DocPdf => AssetNotExists(assets.Documents, file),
            FileContentType.SymbolSvg => AssetNotExists(assets.Symbols, file),
            FileContentType.SymbolDxf => AssetNotExists(assets.Symbols, file),
            FileContentType.SensorSensXml => AssetNotExists(assets.Sensors, file),
            FileContentType.SensorSensLdt => AssetNotExists(assets.Sensors, file),
            FileContentType.SpectrumText => AssetNotExists(assets.Spectrums, file),
            FileContentType.Other => AssetNotExists(assets.Other, file),
            _ => throw new ArgumentOutOfRangeException(nameof(file.ContentType))
        };

    private static bool AssetNotExists(IEnumerable<ContainerFile> assets, GldfFile file) =>
        assets.All(asset => asset.FileName != file.File);

    private static string FlattenFileNames(IEnumerable<GldfFile> filesWithoutAssets) =>
        filesWithoutAssets.Aggregate(string.Empty, (result, file)
            => result == string.Empty
                ? $"{file.File} ({file.ContentType})"
                : $"{result}, {file.File} ({file.ContentType})");

    private static IEnumerable<ValidationHint> ValidateSafe(Func<IEnumerable<ValidationHint>> func)
    {
        try
        {
            return func();
        }
        catch (Exception e)
        {
            return ValidationHint.Warning("The GLDF container could not be validate to have no missing files. " +
                                          $"Error: {e.FlattenMessage()}", ErrorType.MissingContainerAssets);
        }
    }
}