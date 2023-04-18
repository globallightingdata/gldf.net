using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Exceptions;
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

    public IEnumerable<ValidationHint> Validate(string filePath)
    {
        try
        {
            var rootXml = _zipArchiveReader.ReadRootXml(filePath);
            return _xmlValidator.ValidateString(rootXml);
        }
        catch (Exception e)
        {
            return ValidationHint.Error($"The product.xml inside the GLDF container '{filePath}' could " +
                                        "not be validated with the XMLSchema. " +
                                        $"Error: {e.FlattenMessage()}", ErrorType.XmlSchema);
        }
    }
    
    public IEnumerable<ValidationHint> Validate(Stream stream, bool leaveOpen)
    {
        try
        {
            var rootXml = _zipArchiveReader.ReadRootXml(stream, leaveOpen);
            return _xmlValidator.ValidateString(rootXml);
        }
        catch (Exception e)
        {
            return ValidationHint.Error("The product.xml inside the GLDF container stream could " +
                                        "not be validated with the XMLSchema. " +
                                        $"Error: {e.FlattenMessage()}", ErrorType.XmlSchema);
        }
    }
}