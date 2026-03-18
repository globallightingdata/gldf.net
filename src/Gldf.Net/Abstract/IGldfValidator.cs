using Gldf.Net.Container;
using Gldf.Net.Validation.Model;
using System.Collections.Generic;
using System.IO;

namespace Gldf.Net.Abstract;

public interface IGldfValidator
{
    public IEnumerable<ValidationHint> ValidateGldf(GldfContainer gldf);

    public IEnumerable<ValidationHint> ValidateGldfFile(string gldfFilePath, ValidationFlags flags);

    public IEnumerable<ValidationHint> ValidateGldfStream(Stream zipStream, bool leaveOpen, ValidationFlags flags);
}