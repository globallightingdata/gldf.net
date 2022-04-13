using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Validation;
using System;
using System.Collections.Generic;

namespace Gldf.Net
{
    /// <summary>
    ///     Provides functionality to validate GLDF container files and instances of type <see cref="GldfContainer" />.
    ///     This type is threadsafe.
    /// </summary>
    public class GldfContainerValidator : IGldfContainerValidator
    {
        private readonly ZipArchiveValidator _zipArchiveValidator;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GldfContainerValidator" /> class that validates GLDF
        ///     container files on disk. As well as instances of type <see cref="GldfContainer" />
        /// </summary>
        public GldfContainerValidator() => _zipArchiveValidator = new ZipArchiveValidator();

        /// <summary>
        ///     Validates a GLDF container file on disk.
        /// </summary>
        /// <param name="filePath">The path of the GLDF container file to validate</param>
        /// <returns>An IEnumerable of <see cref="ValidationHint" /> with possible warnings and errors</returns>
        public IEnumerable<ValidationHint> Validate(string filePath)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));
            return _zipArchiveValidator.Validate(filePath);
        }

        /// <summary>
        ///     Validates a <see cref="GldfContainer" />.
        /// </summary>
        /// <param name="container">A <see cref="GldfContainer" /> instance to validate</param>
        /// <returns>An IEnumerable of <see cref="ValidationHint" /> with possible warnings and errors</returns>
        public IEnumerable<ValidationHint> Validate(GldfContainer container)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));
            return _zipArchiveValidator.Validate(container);
        }
    }
}