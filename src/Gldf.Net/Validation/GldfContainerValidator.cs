using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Validation.Model;
using Gldf.Net.Validation.Rules.Container;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gldf.Net.Validation;

internal class GldfContainerValidator
{
    private readonly ZipArchiveReader _zipArchiveReader;

    private static readonly List<IContainerValidationRule> ContainerValidationRules = new()
    {
        new HasNoMissingAssetsRule(),
        new HasNoOrphanAssetsRule()
    };

    public GldfContainerValidator()
    {
        _zipArchiveReader = new ZipArchiveReader();
    }

    public IEnumerable<ValidationHint> Validate(GldfContainer container) => ValidateSafe(() => container == null 
        ? ValidationHint.Error("The GLDF is null", ErrorType.GenericError) 
        : ContainerValidationRules.SelectMany(rule => rule.Validate(container)));

    public IEnumerable<ValidationHint> Validate(string filePath) =>
        ValidateSafe(() =>
        {
            if (!ZipArchiveReader.IsZipArchive(filePath))
                return ValidationHint.Error($"The GLDF container '{filePath}' seems not to be a " +
                                            "valid ZIP file or can't be accessed", ErrorType.InvalidZip);

            var containerLoadSettings = new ContainerLoadSettings { AssetLoadBehaviour = AssetLoadBehaviour.FileNamesOnly };
            var gldfContainer = _zipArchiveReader.ReadContainer(filePath, containerLoadSettings);
            return ContainerValidationRules.SelectMany(rule => rule.Validate(gldfContainer));
        });

    public IEnumerable<ValidationHint> Validate(Stream stream, bool leaveOpen) =>
        ValidateSafe(() =>
        {
            if (!ZipArchiveReader.IsZipArchive(stream, true))
                return ValidationHint.Error("The GLDF container seems not to be a " +
                                            "valid ZIP file or can't be accessed", ErrorType.InvalidZip);

            var containerLoadSettings = new ContainerLoadSettings { AssetLoadBehaviour = AssetLoadBehaviour.FileNamesOnly };
            var gldfContainer = _zipArchiveReader.ReadContainer(stream, leaveOpen, containerLoadSettings);
            return ContainerValidationRules.SelectMany(rule => rule.Validate(gldfContainer));
        });

    private static IEnumerable<ValidationHint> ValidateSafe(Func<IEnumerable<ValidationHint>> func)
    {
        try
        {
            return func();
        }
        catch (Exception e)
        {
            return new[] { new ValidationHint(SeverityType.Error, e.Message, ErrorType.GenericError) };
        }
    }
}