using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Extensions;
using Gldf.Net.Validation;
using Gldf.Net.Validation.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Gldf.Net;

public class GldfValidator : IGldfValidator
{
    private readonly GldfXmlValidator _schemaValidator;
    private readonly GldfZipValidator _zipValidator;
    private readonly GldfContainerValidator _containerValidator;

    public GldfValidator() : this(Encoding.UTF8)
    {
    }

    public GldfValidator(Encoding encoding)
    {
        _schemaValidator = new GldfXmlValidator(encoding);
        _zipValidator = new GldfZipValidator(encoding);
        _containerValidator = new GldfContainerValidator(encoding);
    }

    public IEnumerable<ValidationHint> ValidateGldf(GldfContainer gldf) =>
        _containerValidator.ValidateGldf(gldf);

    public IEnumerable<ValidationHint> ValidateGldfFile(string gldfFilePath, ValidationFlags flags) =>
        ValidateSafe(() =>
        {
            // Schema
            var result = new List<ValidationHint>();
            if (flags.HasFlag(ValidationFlags.Schema))
                result.AddRange(_schemaValidator.ValidateGldfFile(gldfFilePath));

            // Zip
            if (flags.HasFlag(ValidationFlags.Zip))
                result.AddRange(_zipValidator.ValidateGldfFile(gldfFilePath));

            // Container only, if no errors yet
            var hasErrors = result.Any(hint => hint.Severity == SeverityType.Error);
            var validateContainer = flags.HasFlag(ValidationFlags.Container);
            return !hasErrors && validateContainer
                ? result.Union(_containerValidator.ValidateGldfFile(gldfFilePath))
                : result;
        });

    public IEnumerable<ValidationHint> ValidateGldfStream(Stream zipStream, bool leaveOpen, ValidationFlags flags) =>
        ValidateSafe(() =>
        {
            try
            {
                // Schema
                var result = new List<ValidationHint>();
                if (flags.HasFlag(ValidationFlags.Schema))
                    result.AddRange(_schemaValidator.ValidateGldfStream(zipStream, true));

                // Zip
                if (flags.HasFlag(ValidationFlags.Zip))
                    result.AddRange(_zipValidator.ValidateGldfStream(zipStream));

                // Container only, if no errors yet
                var hasErrors = result.Any(hint => hint.Severity == SeverityType.Error);
                var validateContainer = flags.HasFlag(ValidationFlags.Container);
                return !hasErrors && validateContainer
                    ? result.Union(_containerValidator.ValidateGldfStream(zipStream, true))
                    : result;
            }
            finally
            {
                if (!leaveOpen) zipStream.DisposeSafe();
            }
        });

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