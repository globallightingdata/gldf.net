using Gldf.Net.Abstract;
using Gldf.Net.Validation.Model;
using Gldf.Net.Validation.Rules.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Gldf.Net.Validation;

internal class GldfZipValidator
{
    private readonly List<IZipArchiveValidationRule> _zipValidationRules;

    public GldfZipValidator() : this(Encoding.UTF8)
    {
    }

    public GldfZipValidator(Encoding encoding)
    {
        _zipValidationRules = new List<IZipArchiveValidationRule>
        {
            new IsValidZipArchiveRule(),
            new ContainsProductXmlRule(),
            new CanDeserializeProductXmlRule(encoding),
            new HasNoLargeFilesRule()
        };
    }

    public IEnumerable<ValidationHint> ValidateGldfFile(string gldfFilePath) => ValidateSafe(() =>
        _zipValidationRules.SelectMany(rule => rule.ValidateGldfFile(gldfFilePath)));

    public IEnumerable<ValidationHint> ValidateGldfStream(Stream zipStream) =>
        ValidateSafe(() => _zipValidationRules.SelectMany(rule => rule.ValidateGldfStream(zipStream, true)));

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