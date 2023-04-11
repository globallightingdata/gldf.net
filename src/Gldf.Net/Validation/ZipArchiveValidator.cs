using Gldf.Net.Abstract;
using Gldf.Net.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Gldf.Net.Validation;

internal class ZipArchiveValidator
{
    private readonly ZipArchiveReader _zipArchiveReader;
    private readonly List<IZipArchiveValidationRule> _zipValidationRules;
    private readonly List<IContainerValidationRule> _containerValidationRules;

    public ZipArchiveValidator()
    {
        _zipValidationRules = GetValidationRules<IZipArchiveValidationRule>()
            .OrderBy(rule => rule.Priority).ToList();
        _containerValidationRules = GetValidationRules<IContainerValidationRule>()
            .OrderBy(rule => rule.Priority).ToList();
        _zipArchiveReader = new ZipArchiveReader();
    }

    public IEnumerable<ValidationHint> Validate(GldfContainer container)
    {
        try
        {
            return _containerValidationRules.SelectMany(rule => rule.Validate(container));
        }
        catch (Exception e)
        {
            return new[] {new ValidationHint(SeverityType.Error, e.Message, ErrorType.GenericError)};
        }
    }

    public IEnumerable<ValidationHint> Validate(string filePath)
    {
        try
        {
            var zipValidationHints = _zipValidationRules.SelectMany(rule => rule.Validate(filePath)).ToArray();
            return zipValidationHints.Any(hint => hint.Severity == SeverityType.Error) 
                ? zipValidationHints 
                : zipValidationHints.Union(ValidateArchieve(filePath));
        }
        catch (Exception e)
        {
            return new[] {new ValidationHint(SeverityType.Error, e.Message, ErrorType.GenericError)};
        }
    }

    internal static IEnumerable<T> GetValidationRules<T>()
    {
        static bool IsOfTypeClass(Type type)
            => typeof(T).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract;
        return Assembly.GetAssembly(typeof(ZipArchiveValidator))!
            .GetTypes().Where(IsOfTypeClass)
            .Select(type => (T) Activator.CreateInstance(type));
    }

    private IEnumerable<ValidationHint> ValidateArchieve(string filePath)
    {
        var containerLoadSettings = new ContainerLoadSettings {AssetLoadBehaviour = AssetLoadBehaviour.FileNamesOnly};
        var gldfContainer = _zipArchiveReader.ReadContainer(filePath, containerLoadSettings);
        return _containerValidationRules.SelectMany(rule => rule.Validate(gldfContainer));
    }
}