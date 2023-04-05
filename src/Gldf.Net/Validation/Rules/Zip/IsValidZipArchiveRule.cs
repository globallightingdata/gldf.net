using Gldf.Net.Abstract;
using Gldf.Net.Container;
using System.Collections.Generic;

namespace Gldf.Net.Validation.Rules.Zip;

internal class IsValidZipArchiveRule : IZipArchiveValidationRule
{
    public int Priority => 10;

    public IEnumerable<ValidationHint> Validate(string filePath)
    {
        return ZipArchiveReader.IsZipArchive(filePath)
            ? ValidationHint.Empty()
            : ValidationHint.Error($"The GLDF container '{filePath}' seems not to be a " +
                                   "valid ZIP file or can't be accessed", ErrorType.InvalidZipFile);
    }
}