using Gldf.Net.Validation.Model;
using System.Collections.Generic;
using System.IO;

namespace Gldf.Net.Abstract;

internal interface IZipArchiveValidationRule
{
    IEnumerable<ValidationHint> Validate(string filePath);

    IEnumerable<ValidationHint> Validate(Stream stream, bool leaveOpen);
}