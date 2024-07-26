using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Exceptions;
using Gldf.Net.Validation.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Validation.Rules.Container;

internal class HasNoMissingAssetsRule : IContainerValidationRule
{
    public IEnumerable<ValidationHint> ValidateGldf(GldfContainer gldf)
    {
        return ValidateSafe(() =>
        {
            if (gldf.Product?.GeneralDefinitions?.Files == null) return ValidationHint.Empty();
            var filesWithoutAssets = gldf.Product.GeneralDefinitions.Files.Where(file =>
                file.Type == FileType.LocalFileName && HasNoAsset(file, gldf.Assets)).ToArray();

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
            FileContentType.LdcEulumdat => HasNoAsset(assets.Photometries, file),
            FileContentType.LdcIes => HasNoAsset(assets.Photometries, file),
            FileContentType.LdcIesXml => HasNoAsset(assets.Photometries, file),
            FileContentType.ImagePng => HasNoAsset(assets.Images, file),
            FileContentType.ImageJpg => HasNoAsset(assets.Images, file),
            FileContentType.ImageSvg => HasNoAsset(assets.Images, file),
            FileContentType.GeoL3d => HasNoAsset(assets.Geometries, file),
            FileContentType.GeoR3d => HasNoAsset(assets.Geometries, file),
            FileContentType.GeoM3d => HasNoAsset(assets.Geometries, file),
            FileContentType.DocPdf => HasNoAsset(assets.Documents, file),
            FileContentType.SymbolSvg => HasNoAsset(assets.Symbols, file),
            FileContentType.SymbolDxf => HasNoAsset(assets.Symbols, file),
            FileContentType.SensorSensXml => HasNoAsset(assets.Sensors, file),
            FileContentType.SensorSensLdt => HasNoAsset(assets.Sensors, file),
            FileContentType.SpectrumText => HasNoAsset(assets.Spectrums, file),
            FileContentType.Other => HasNoAsset(assets.Other, file),
            _ => throw new ArgumentOutOfRangeException(nameof(file.ContentType))
        };

    private static bool HasNoAsset(IEnumerable<ContainerFile> assets, GldfFile file) =>
        assets.All(asset => !asset.FileName.Equals(file.File, StringComparison.OrdinalIgnoreCase));

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