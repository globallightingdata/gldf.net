using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Extensions;
using Gldf.Net.Validation;
using Gldf.Net.Validation.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gldf.Net;

public class GldfValidator : IGldfValidator
{
    private readonly GldfXmlValidator _schemaValidator;
    private readonly GldfZipValidator _zipValidator;
    private readonly GldfContainerValidator _containerValidator;

    public GldfValidator()
    {
        _schemaValidator = new GldfXmlValidator();
        _zipValidator = new GldfZipValidator();
        _containerValidator = new GldfContainerValidator();
    }

    public IEnumerable<ValidationHint> Validate(GldfContainer container)
    {
        return _containerValidator.Validate(container);
    }

    public IEnumerable<ValidationHint> Validate(string filePath, ValidationFlags flags) =>
        ValidateSafe(() =>
        {
            // Schema
            var result = new List<ValidationHint>();
            if (flags.HasFlag(ValidationFlags.Schema))
                result.AddRange(_schemaValidator.ValidateGldfFile(filePath));

            // Zip
            if (flags.HasFlag(ValidationFlags.Zip))
                result.AddRange(_zipValidator.Validate(filePath));

            // Container only, if no errors yet
            var hasErrors = result.Any(hint => hint.Severity == SeverityType.Error);
            var validateContainer = flags.HasFlag(ValidationFlags.Container);
            return !hasErrors && validateContainer
                ? result.Union(_containerValidator.Validate(filePath))
                : result;
        });

    public IEnumerable<ValidationHint> Validate(Stream stream, bool leaveOpen, ValidationFlags flags) =>
        ValidateSafe(() =>
        {
            try
            {
                // Schema
                var result = new List<ValidationHint>();
                if (flags.HasFlag(ValidationFlags.Schema))
                    result.AddRange(_schemaValidator.ValidateXmlStream(stream, true));

                // Zip
                if (flags.HasFlag(ValidationFlags.Zip))
                    result.AddRange(_zipValidator.Validate(stream));

                // Container only, if no errors yet
                var hasErrors = result.Any(hint => hint.Severity == SeverityType.Error);
                var validateContainer = flags.HasFlag(ValidationFlags.Container);
                return !hasErrors && validateContainer
                    ? result.Union(_containerValidator.Validate(stream, true))
                    : result;
            }
            finally
            {
                if (!leaveOpen) stream.DisposeSafe();
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