using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Exceptions;
using System;
using System.Collections.Generic;

namespace Gldf.Net.Validation.Rules.Zip;

internal class CanDeserializeProductXmlRule : IZipArchiveValidationRule
{
    public int Priority => 40;

    private readonly GldfContainerReader _gldfContainerReader;

    public CanDeserializeProductXmlRule()
    {
        _gldfContainerReader = new GldfContainerReader();
    }

    public IEnumerable<ValidationHint> Validate(string filePath)
    {
        try
        {
            var loadRootOnlySettings = new ContainerLoadSettings
            {
                ProductLoadBehaviour = ProductLoadBehaviour.Load,
                AssetLoadBehaviour = AssetLoadBehaviour.Skip,
                MetaInfoLoadBehaviour = MetaInfoLoadBehaviour.Skip
            };
            var container = _gldfContainerReader.ReadFromFile(filePath, loadRootOnlySettings);
            return container.Product != null
                ? ValidationHint.Empty()
                : ValidationHint.Error($"The product.xml in GLDF container '{filePath}' could not be " +
                                       "deserialised.", ErrorType.NonDeserialisableRoot);
        }
        catch (Exception e)
        {
            return ValidationHint.Error($"The product.xml in GLDF container '{filePath}' could " +
                                        "not be deserialised. Error: " +
                                        $"{e.FlattenMessage()}", ErrorType.NonDeserialisableRoot);
        }
    }
}