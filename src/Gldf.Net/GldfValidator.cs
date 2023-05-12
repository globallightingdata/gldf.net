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
using System.Xml.Schema;

namespace Gldf.Net;

/// <summary>
///     Provides functionality to validate GLDF container files, provided as POCO, file, or stream.
///     This type is threadsafe.
/// </summary>
public class GldfValidator : IGldfValidator
{
    private readonly GldfXmlValidator _schemaValidator;
    private readonly GldfZipValidator _zipValidator;
    private readonly GldfContainerValidator _containerValidator;

    /// <summary>
    ///     Initializes a new instance of the <see cref="GldfValidator" /> class that can validate GLDF container as
    ///     string, file or stream. With UTF-8 default encoding.
    /// </summary>
    public GldfValidator() : this(Encoding.UTF8)
    {
    }
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="GldfValidator" /> class that can validate GLDF XML as
    ///     string, file or stream. Overload with Encoding parameter that is used when reading files.
    /// </summary>
    /// <exception cref="ArgumentNullException">If the Encoding is null.</exception>
    /// <param name="encoding">Encoding for reading XML</param>
    public GldfValidator(Encoding encoding)
    {
        if (encoding is null) throw new ArgumentNullException(nameof(encoding));
        _schemaValidator = new GldfXmlValidator(encoding);
        _zipValidator = new GldfZipValidator(encoding);
        _containerValidator = new GldfContainerValidator(encoding);
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="GldfValidator" /> class that can validate GLDF XML as
    ///     string, file or stream. Overload with Encoding parameter that is used when reading files.
    /// </summary>
    /// <exception cref="ArgumentNullException">If the Encoding is null.</exception>
    /// <param name="xmlSchema">The Xml schema which should be used for XSD validation</param>
    public GldfValidator(XmlSchemaSet xmlSchema)
    {
        if (xmlSchema is null) throw new ArgumentNullException(nameof(xmlSchema));
        _schemaValidator = new GldfXmlValidator(Encoding.UTF8, xmlSchema);
        _zipValidator = new GldfZipValidator(Encoding.UTF8);
        _containerValidator = new GldfContainerValidator(Encoding.UTF8);
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="GldfValidator" /> class that can validate GLDF XML as
    ///     string, file or stream. Overload with Encoding parameter that is used when reading files.
    /// </summary>
    /// <exception cref="ArgumentNullException">If the Encoding is null.</exception>
    /// <param name="encoding">Encoding for reading XML</param>
    /// <param name="xmlSchema">The Xml schema which should be used for XSD validation</param>
    public GldfValidator(Encoding encoding, XmlSchemaSet xmlSchema)
    {
        if (encoding is null) throw new ArgumentNullException(nameof(encoding));
        if (xmlSchema is null) throw new ArgumentNullException(nameof(xmlSchema));
        _schemaValidator = new GldfXmlValidator(encoding, xmlSchema);
        _zipValidator = new GldfZipValidator(encoding);
        _containerValidator = new GldfContainerValidator(encoding);
    }

    /// <summary>
    ///     Validates only the GLDF container content (missing/orphaned assets for example). No Zip or XML Schema validation
    ///     possible
    /// </summary>
    /// <param name="gldf">THE GLDF to validate</param>
    /// <returns>An IEnumerable of <see cref="ValidationHint" /> with possible warnings and errors</returns>
    public IEnumerable<ValidationHint> ValidateGldf(GldfContainer gldf) =>
        _containerValidator.ValidateGldf(gldf);

    /// <summary>
    ///     Validates the GLDF container file on disk. 
    /// </summary>
    /// <param name="gldfFilePath">The filepath of the GLDF conatiner file</param>
    /// <param name="flags">Defines which parts of the GLDF should be validated</param>
    /// <returns>An IEnumerable of <see cref="ValidationHint" /> with possible warnings and errors</returns>
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

    /// <summary>
    ///     Validates the GLDF container stream. 
    /// </summary>
    /// <param name="zipStream">The stream with the GLDF conatiner</param>
    /// <param name="leaveOpen">Whether to close the stream after serialization.</param>
    /// <param name="flags">Defines which parts of the GLDF should be validated</param>
    /// <returns>An IEnumerable of <see cref="ValidationHint" /> with possible warnings and errors</returns>
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