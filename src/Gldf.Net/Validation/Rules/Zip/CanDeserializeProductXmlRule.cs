using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;

namespace Gldf.Net.Validation.Rules.Zip;

internal class CanDeserializeProductXmlRule : IZipArchiveValidationRule
{
    private readonly GldfContainerReader _gldfContainerReader;
    private readonly ContainerLoadSettings _loadRootOnlySettings;

    public CanDeserializeProductXmlRule()
    {
        _gldfContainerReader = new GldfContainerReader();
        _loadRootOnlySettings = new ContainerLoadSettings
        {
            ProductLoadBehaviour = ProductLoadBehaviour.Load,
            AssetLoadBehaviour = AssetLoadBehaviour.Skip,
            MetaInfoLoadBehaviour = MetaInfoLoadBehaviour.Skip
        };
    }

    public IEnumerable<ValidationHint> Validate(string filePath)
    {
        try
        {
            var container = _gldfContainerReader.ReadFromFile(filePath, _loadRootOnlySettings);
            return container.Product != null
                ? ValidationHint.Empty()
                : ValidationHint.Error($"The product.xml in GLDF container '{filePath}' could not be " +
                                       "deserialized.", ErrorType.NonDeserialisableRoot);
        }
        catch (Exception e)
        {
            return ValidationHint.Error($"The product.xml in GLDF container '{filePath}' could " +
                                        "not be deserialized. Error: " +
                                        $"{e.FlattenMessage()}", ErrorType.NonDeserialisableRoot);
        }
    }

    public IEnumerable<ValidationHint> Validate(Stream stream, bool leaveOpen)
    {
        try
        {
            var container = _gldfContainerReader.ReadFromStream(stream, leaveOpen, _loadRootOnlySettings);
            return container.Product != null
                ? ValidationHint.Empty()
                : ValidationHint.Error("The product.xml in GLDF container could not be " +
                                       "deserialized.", ErrorType.NonDeserialisableRoot);
        }
        catch (Exception e)
        {
            return ValidationHint.Error("The product.xml in GLDF container could " +
                                        "not be deserialized. Error: " +
                                        $"{e.FlattenMessage()}", ErrorType.NonDeserialisableRoot);
        }
    }
}