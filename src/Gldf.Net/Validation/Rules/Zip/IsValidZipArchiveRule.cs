using Gldf.Net.Abstract;
using Gldf.Net.Container;
using System.Collections.Generic;
using System.IO;

namespace Gldf.Net.Validation.Rules.Zip;

internal class IsValidZipArchiveRule : IZipArchiveValidationRule
{
    public IEnumerable<ValidationHint> Validate(string filePath) =>
        ZipArchiveReader.IsZipArchive(filePath)
            ? ValidationHint.Empty()
            : ValidationHint.Error($"The GLDF container '{filePath}' seems not to be a " +
                                   "valid ZIP file or can't be accessed", ErrorType.InvalidZip);

    public IEnumerable<ValidationHint> Validate(Stream stream, bool leaveOpen) =>
        ZipArchiveReader.IsZipArchive(stream, leaveOpen)
            ? ValidationHint.Empty()
            : ValidationHint.Error("The GLDF container stream seems not to be a " +
                                   "valid ZIP file or can't be accessed", ErrorType.InvalidZip);
}