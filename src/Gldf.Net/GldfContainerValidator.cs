using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Validation;
using System.Collections.Generic;

namespace Gldf.Net
{
    /// <summary>
    ///     Provides functionality to validate GLDF container files and <see cref="GldfArchive" />.
    ///     This type is threadsafe.
    /// </summary>
    public class GldfContainerValidator : IGldfContainerValidator
    {
        private readonly ZipArchiveValidator _zipArchiveValidator;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GldfContainerValidator" /> class that validates GLDF
        ///     container files on disk. As well as instances of type <see cref="Gldf.Net.Container.GldfArchive" />
        /// </summary>
        public GldfContainerValidator()
            => _zipArchiveValidator = new ZipArchiveValidator();

        /// <summary>
        ///     Validates a GLDF container file on disk.
        /// </summary>
        /// <param name="filePath">The path of the GLDF container file to validate</param>
        /// <returns>An IEnumerable of <see cref="ValidationHint" /> with possible warnings and errors</returns>
        public IEnumerable<ValidationHint> Validate(string filePath)
            => _zipArchiveValidator.Validate(filePath);

        /// <summary>
        ///     Validates a <see cref="GldfArchive" />.
        /// </summary>
        /// <param name="archive">A <see cref="GldfArchive" /> instance to validate</param>
        /// <returns>An IEnumerable of <see cref="ValidationHint" /> with possible warnings and errors</returns>
        public IEnumerable<ValidationHint> Validate(GldfArchive archive)
            => _zipArchiveValidator.Validate(archive);
    }
}