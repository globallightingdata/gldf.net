using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Validation.Model;
using System.Collections.Generic;
using System.IO;

namespace Gldf.Net.Validation.Rules.Zip;

internal class IsValidZipArchiveRule : IZipArchiveValidationRule
{
    public IEnumerable<ValidationHint> ValidateGldfFile(string gldfFilePath) =>
        ZipArchiveReader.IsZipArchive(gldfFilePath)
            ? ValidationHint.Empty()
            : ValidationHint.Error($"The GLDF container '{gldfFilePath}' seems not to be a " +
                                   "valid ZIP file or can't be accessed", ErrorType.InvalidZip);

    public IEnumerable<ValidationHint> ValidateGldfStream(Stream zipStream, bool leaveOpen) =>
        ZipArchiveReader.IsZipArchive(zipStream, leaveOpen)
            ? ValidationHint.Empty()
            : ValidationHint.Error("The GLDF container stream seems not to be a " +
                                   "valid ZIP file or can't be accessed", ErrorType.InvalidZip);
}