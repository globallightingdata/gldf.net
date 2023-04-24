using Gldf.Net.Abstract;
using Gldf.Net.Validation.Model;
using Gldf.Net.Validation.Rules.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gldf.Net.Validation;

internal class GldfZipValidator
{
    private static readonly List<IZipArchiveValidationRule> ZipValidationRules = new()
    {
        new IsValidZipArchiveRule(),
        new ContainsProductXmlRule(),
        new CanDeserializeProductXmlRule(),
        new HasNoLargeFilesRule()
    };

    public IEnumerable<ValidationHint> ValidateGldfFile(string gldfFilePath) => ValidateSafe(() =>
        ZipValidationRules.SelectMany(rule => rule.ValidateGldfFile(gldfFilePath)));

    public IEnumerable<ValidationHint> ValidateGldfStream(Stream zipStream) =>
        ValidateSafe(() => ZipValidationRules.SelectMany(rule => rule.ValidateGldfStream(zipStream, true)));

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