using Gldf.Net.Validation.Model;
using System.Collections.Generic;
using System.IO;

namespace Gldf.Net.Abstract;

internal interface IZipArchiveValidationRule
{
    IEnumerable<ValidationHint> ValidateGldfFile(string gldfFilePath);

    IEnumerable<ValidationHint> ValidateGldfStream(Stream zipStream, bool leaveOpen);
}