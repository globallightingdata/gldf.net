using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Exceptions;
using Gldf.Net.Validation;
using Gldf.Net.Validation.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Gldf.Net;

/// <summary>
///     Provides functionality to validate GLDF XML, provided as string, file, stream or inside a GLDF.
///     This type is threadsafe.
/// </summary>
public class GldfXmlValidator : IGldfXmlValidator
{

    /// <summary>
    ///     Encoding beeing used reading GLDF XML. The default is UTF-8
    /// </summary>
    public Encoding Encoding { get; }

    private readonly GldfXmlSchemaValidator _gldfXmlValidator;
    private readonly ZipArchiveReader _zipArchiveReader;

    /// <summary>
    ///     Initializes a new instance of the <see cref="GldfXmlValidator" /> class that can validate GLDF XML as
    ///     string, file, stream or GLDF. With UTF-8 default encoding.
    /// </summary>
    public GldfXmlValidator() : this(Encoding.UTF8)
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="GldfXmlValidator" /> class that can validate GLDF XML as
    ///     string, file, stream or GLDF. Overload with Encoding parameter that is used when reading files.
    /// </summary>
    /// <param name="encoding">Encoding for reading GLDF XML files</param>
    public GldfXmlValidator(Encoding encoding)
    {
        Encoding = encoding ?? throw new ArgumentNullException(nameof(encoding));
        _gldfXmlValidator = new GldfXmlSchemaValidator();
        _zipArchiveReader = new ZipArchiveReader();
    }

    /// <summary>
    ///     Validates the GLDF XML with the XmlSchema definition matching the specified FormatVersion in the Header
    ///     of the XML.
    /// </summary>
    /// <param name="xml">The GLDF XML string to validate</param>
    /// <returns>An IEnumerable of <see cref="ValidationHint" /> with possible warnings and errors</returns>
    public IEnumerable<ValidationHint> ValidateXml(string xml) =>
        ValidateSafe(() => _gldfXmlValidator.ValidateString(xml));

    /// <summary>
    ///     Validates the GLDF XML file on disk with the XmlSchema definition matching the specified FormatVersion
    ///     in the Header of the XML.
    /// </summary>
    /// <param name="xmlFilePath">The path to the GLDF XML file</param>
    /// <returns>An IEnumerable of <see cref="ValidationHint" /> with possible warnings and errors</returns>
    public IEnumerable<ValidationHint> ValidateXmlFile(string xmlFilePath) =>
        ValidateSafe(() =>
        {
            using var streamReader = new StreamReader(xmlFilePath, Encoding, true);
            var xml = streamReader.ReadToEnd();
            return _gldfXmlValidator.ValidateString(xml);
        });

    /// <summary>
    ///     Validates the GLDF XML file on disk with the XmlSchema definition matching the specified FormatVersion
    ///     in the Header of the XML.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="leaveOpen"></param>
    /// <returns>An IEnumerable of <see cref="ValidationHint" /> with possible warnings and errors</returns>
    public IEnumerable<ValidationHint> ValidateXmlStream(Stream stream, bool leaveOpen) =>
        ValidateSafe(() =>
        {
            var xml = _zipArchiveReader.ReadRootXml(stream, leaveOpen);
            return _gldfXmlValidator.ValidateString(xml);
        });

    /// <summary>
    ///     Validates the GLDF XML file on disk with the XmlSchema definition matching the specified FormatVersion
    ///     in the Header of the XML.
    /// </summary>
    /// <param name="filePath">The path to the GLDF XML file</param>
    /// <returns>An IEnumerable of <see cref="ValidationHint" /> with possible warnings and errors</returns>
    public IEnumerable<ValidationHint> ValidateGldfFile(string filePath) =>
        ValidateSafe(() =>
        {
            var xml = _zipArchiveReader.ReadRootXml(filePath);
            return _gldfXmlValidator.ValidateString(xml);
        });

    /// <summary>
    ///     Validates the GLDF XML file on disk with the XmlSchema definition matching the specified FormatVersion
    ///     in the Header of the XML.
    /// </summary>
    /// <param name="stream">The stream to the GLDF XML file</param>
    /// <param name="leaveOpen">true to leave te stream open, otherwise false</param>
    /// <returns>An IEnumerable of <see cref="ValidationHint" /> with possible warnings and errors</returns>
    public IEnumerable<ValidationHint> ValidateGldfStream(Stream stream, bool leaveOpen) =>
        ValidateSafe(() =>
        {
            var xml = _zipArchiveReader.ReadRootXml(stream, leaveOpen);
            return _gldfXmlValidator.ValidateString(xml);
        });

    private static IEnumerable<ValidationHint> ValidateSafe(Func<IEnumerable<ValidationHint>> func)
    {
        try
        {
            return func();
        }
        catch (Exception e)
        {
            return ValidationHint.Error($"Failed to validate XML Schema: {e.FlattenMessage()}", ErrorType.XmlSchema);
        }
    }
}