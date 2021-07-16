using Gldf.Net.Abstract;
using Gldf.Net.Exceptions;
using Gldf.Net.Validation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Gldf.Net
{
    /// <summary>
    ///     Provides functionality to validate GLDF XML, provided as string or file. This type is threadsafe.
    /// </summary>
    public class GldfXmlValidator : IGldfXmlValidator
    {
        /// <summary>
        ///     Encoding to use when reading GLDF from XML files. The default is UTF-8
        /// </summary>
        public Encoding Encoding { get; }

        private readonly XmlDocValidator _xmlValidator;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GldfXmlValidator" /> class that can validate GLDF XML as
        ///     string or file. With UTF-8 default encoding.
        /// </summary>
        public GldfXmlValidator() : this(Encoding.UTF8)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GldfXmlValidator" /> class that can validate GLDF XML as
        ///     string or file. Overload with Encoding parameter that is used when reading files.
        /// </summary>
        /// <param name="encoding">Encoding for reading GLDF XML files</param>
        public GldfXmlValidator(Encoding encoding)
        {
            Encoding = encoding;
            _xmlValidator = new XmlDocValidator();
        }

        /// <summary>
        ///     Validates the GLDF XML with the XmlSchema definition matching the specified FormatVersion in the Header
        ///     of the XML.
        /// </summary>
        /// <param name="xml">The GLDF XML string to validate</param>
        /// <returns>An IEnumerable of <see cref="ValidationHint" /> with possible warnings and errors</returns>
        public IEnumerable<ValidationHint> ValidateXml(string xml)
        {
            try
            {
                return _xmlValidator.ValidateXml(xml);
            }
            catch (Exception e)
            {
                throw new GldfValidationException("Failed to validate XML. See inner exception", e);
            }
        }

        /// <summary>
        ///     Validates the GLDF XML file on disk with the XmlSchema definition matching the specified FormatVersion
        ///     in the Header of the XML.
        /// </summary>
        /// <param name="filePath">The path to the GLDF XML file</param>
        /// <returns>An IEnumerable of <see cref="ValidationHint" /> with possible warnings and errors</returns>
        public IEnumerable<ValidationHint> ValidateXmlFile(string filePath)
        {
            try
            {
                using var streamReader = new StreamReader(filePath, Encoding, true);
                var xml = streamReader.ReadToEnd();
                return _xmlValidator.ValidateXml(xml);
            }
            catch (Exception e)
            {
                throw new GldfValidationException($"Failed to validate File with path '{filePath}'. " +
                                                  "See inner exception", e);
            }
        }
    }
}