using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Validation.Model;
using Gldf.Net.Validation.Rules.Container;
using Gldf.Net.Validation.Rules.Zip;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Validation;

internal class ZipArchiveValidator
{
    private readonly ZipArchiveReader _zipArchiveReader;

    private static readonly List<IContainerValidationRule> ContainerValidationRules = new()
    {
        new HasNoMissingAssetsRule(),
        new HasNoOrphanAssetsRule()
    };

    private static readonly List<IZipArchiveValidationRule> ZipValidationRules = new()
    {
        new IsValidZipArchiveRule(),
        new ContainsProductXmlRule(),
        new IsValidProductXmlRule(),
        new CanDeserializeProductXmlRule(),
        new HasNoLargeFilesRule()
    };

    public ZipArchiveValidator()
    {
        _zipArchiveReader = new ZipArchiveReader();
    }

    public IEnumerable<ValidationHint> Validate(GldfContainer container)
    {
        try
        {
            return ContainerValidationRules.SelectMany(rule => rule.Validate(container));
        }
        catch (Exception e)
        {
            return new[] { new ValidationHint(SeverityType.Error, e.Message, ErrorType.GenericError) };
        }
    }

    public IEnumerable<ValidationHint> Validate(string filePath)
    {
        try
        {
            var zipValidationHints = ZipValidationRules.SelectMany(rule => rule.Validate(filePath)).ToArray();
            return zipValidationHints.Any(hint => hint.Severity == SeverityType.Error)
                ? zipValidationHints
                : zipValidationHints.Union(ValidateArchieve(filePath));
        }
        catch (Exception e)
        {
            return new[] { new ValidationHint(SeverityType.Error, e.Message, ErrorType.GenericError) };
        }
    }

    private IEnumerable<ValidationHint> ValidateArchieve(string filePath)
    {
        var containerLoadSettings = new ContainerLoadSettings { AssetLoadBehaviour = AssetLoadBehaviour.FileNamesOnly };
        var gldfContainer = _zipArchiveReader.ReadContainer(filePath, containerLoadSettings);
        return ContainerValidationRules.SelectMany(rule => rule.Validate(gldfContainer));
    }
}