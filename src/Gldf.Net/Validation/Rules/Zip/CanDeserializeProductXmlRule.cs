using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Exceptions;
using Gldf.Net.Validation.Model;
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

    public IEnumerable<ValidationHint> ValidateGldfFile(string gldfFilePath) =>
        ValidateSafe(() =>
            _gldfContainerReader.ReadFromGldfFile(gldfFilePath, _loadRootOnlySettings).Product != null
                ? ValidationHint.Empty()
                : ValidationHint.Error($"The product.xml in GLDF container '{gldfFilePath}' could not be " +
                                       "deserialized.", ErrorType.NonDeserialisableRoot));

    public IEnumerable<ValidationHint> ValidateGldfStream(Stream zipStream, bool leaveOpen) =>
        ValidateSafe(() =>
            _gldfContainerReader.ReadFromGldfStream(zipStream, leaveOpen, _loadRootOnlySettings).Product != null
                ? ValidationHint.Empty()
                : ValidationHint.Error("The product.xml in GLDF container could not be " +
                                       "deserialized.", ErrorType.NonDeserialisableRoot));

    private static IEnumerable<ValidationHint> ValidateSafe(Func<IEnumerable<ValidationHint>> func)
    {
        try
        {
            return func();
        }
        catch (Exception e)
        {
            return ValidationHint.Error($"The product.xml in GLDF container could not be deserialized. Error: " +
                                        $"{e.FlattenMessage()}", ErrorType.NonDeserialisableRoot);
        }
    }
}