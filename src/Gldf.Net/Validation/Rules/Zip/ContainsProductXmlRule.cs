using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;

namespace Gldf.Net.Validation.Rules.Zip;

internal class ContainsProductXmlRule : IZipArchiveValidationRule
{
    public IEnumerable<ValidationHint> Validate(string filePath) =>
        ValidateSafe(() => ZipArchiveReader.ContainsRootXml(filePath)
            ? ValidationHint.Empty()
            : ValidationHint.Error($"The GLDF container '{filePath}' does not contain a " +
                                   "product.xml entry.", ErrorType.ProductXmlNotFound));

    public IEnumerable<ValidationHint> Validate(Stream stream, bool leaveOpen) =>
        ValidateSafe(() => ZipArchiveReader.ContainsRootXml(stream, leaveOpen)
            ? ValidationHint.Empty()
            : ValidationHint.Error("The GLDF container does not contain a " +
                                   "product.xml entry.", ErrorType.ProductXmlNotFound));

    private static IEnumerable<ValidationHint> ValidateSafe(Func<IEnumerable<ValidationHint>> func)
    {
        try
        {
            return func();
        }
        catch (Exception e)
        {
            return ValidationHint.Error($"The GLDF container could not be validated to contain a product.xml entry. " +
                                        $"Error: {e.FlattenMessage()}", ErrorType.ProductXmlNotFound);
        }
    }
}