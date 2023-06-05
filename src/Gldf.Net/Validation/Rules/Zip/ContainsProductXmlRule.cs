using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Exceptions;
using Gldf.Net.Validation.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace Gldf.Net.Validation.Rules.Zip;

internal class ContainsProductXmlRule : IZipArchiveValidationRule
{
    public IEnumerable<ValidationHint> ValidateGldfFile(string gldfFilePath) =>
        ValidateSafe(() => ZipArchiveReader.ContainsRootXml(gldfFilePath)
            ? ValidationHint.Empty()
            : ValidationHint.Error($"The GLDF container '{gldfFilePath}' does not contain a " +
                                   "product.xml entry.", ErrorType.ProductXmlNotFound));

    public IEnumerable<ValidationHint> ValidateGldfStream(Stream zipStream, bool leaveOpen) =>
        ValidateSafe(() => ZipArchiveReader.ContainsRootXml(zipStream, leaveOpen)
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