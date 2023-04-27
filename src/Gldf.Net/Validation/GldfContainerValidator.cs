using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Validation.Model;
using Gldf.Net.Validation.Rules.Container;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Gldf.Net.Validation;

internal class GldfContainerValidator
{
    private readonly ZipArchiveReader _zipArchiveReader;

    private static readonly List<IContainerValidationRule> ContainerValidationRules = new()
    {
        new HasNoMissingAssetsRule(),
        new HasNoOrphanAssetsRule()
    };

    public GldfContainerValidator() : this(Encoding.UTF8)
    {
    }

    public GldfContainerValidator(Encoding encoding)
    {
        _zipArchiveReader = new ZipArchiveReader(encoding);
    }

    public IEnumerable<ValidationHint> ValidateGldf(GldfContainer gldf) => ValidateSafe(() => gldf == null 
        ? ValidationHint.Error("The GLDF is null", ErrorType.GenericError) 
        : ContainerValidationRules.SelectMany(rule => rule.ValidateGldf(gldf)));

    public IEnumerable<ValidationHint> ValidateGldfFile(string gldfFilePath) =>
        ValidateSafe(() =>
        {
            if (!ZipArchiveReader.IsZipArchive(gldfFilePath))
                return ValidationHint.Error($"The GLDF container '{gldfFilePath}' seems not to be a " +
                                            "valid ZIP file or can't be accessed", ErrorType.InvalidZip);

            var containerLoadSettings = new ContainerLoadSettings { AssetLoadBehaviour = AssetLoadBehaviour.FileNamesOnly };
            var gldfContainer = _zipArchiveReader.ReadContainer(gldfFilePath, containerLoadSettings);
            return ContainerValidationRules.SelectMany(rule => rule.ValidateGldf(gldfContainer));
        });

    public IEnumerable<ValidationHint> ValidateGldfStream(Stream zipStream, bool leaveOpen) =>
        ValidateSafe(() =>
        {
            if (!ZipArchiveReader.IsZipArchive(zipStream, true))
                return ValidationHint.Error("The GLDF container seems not to be a " +
                                            "valid ZIP archive or can't be accessed", ErrorType.InvalidZip);

            var containerLoadSettings = new ContainerLoadSettings { AssetLoadBehaviour = AssetLoadBehaviour.FileNamesOnly };
            var gldfContainer = _zipArchiveReader.ReadContainer(zipStream, leaveOpen, containerLoadSettings);
            return ContainerValidationRules.SelectMany(rule => rule.ValidateGldf(gldfContainer));
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