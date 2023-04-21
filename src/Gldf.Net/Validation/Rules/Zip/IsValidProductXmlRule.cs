using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Exceptions;
using Gldf.Net.Validation.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace Gldf.Net.Validation.Rules.Zip;

internal class IsValidProductXmlRule : IZipArchiveValidationRule
{
    private readonly ZipArchiveReader _zipArchiveReader;
    private readonly GldfXmlValidator _xmlValidator;

    public IsValidProductXmlRule()
    {
        _zipArchiveReader = new ZipArchiveReader();
        _xmlValidator = new GldfXmlValidator();
    }

    public IEnumerable<ValidationHint> Validate(string filePath) =>
        ValidateSafe(() =>
        {
            var rootXml = _zipArchiveReader.ReadRootXml(filePath);
            return ValidateXml(rootXml);
        });

    public IEnumerable<ValidationHint> Validate(Stream stream, bool leaveOpen) =>
        ValidateSafe(() =>
        {
            var rootXml = _zipArchiveReader.ReadRootXml(stream, leaveOpen);
            return ValidateXml(rootXml);
        });

    private IEnumerable<ValidationHint> ValidateXml(string rootXml) =>
        rootXml == null
            ? ValidationHint.Error("The product.xml inside the GLDF container is missing", ErrorType.XmlSchema)
            : _xmlValidator.ValidateXml(rootXml);

    private static IEnumerable<ValidationHint> ValidateSafe(Func<IEnumerable<ValidationHint>> func)
    {
        try
        {
            return func();
        }
        catch (Exception e)
        {
            return ValidationHint.Error("The product.xml inside the GLDF container could " +
                                        "not be validated with the XMLSchema. " +
                                        $"Error: {e.FlattenMessage()}", ErrorType.XmlSchema);
        }
    }
}