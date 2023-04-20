using Gldf.Net.Container;
using Gldf.Net.Validation.Model;
using System.Collections.Generic;
using System.IO;

namespace Gldf.Net.Abstract;

public interface IGldfContainerValidator
{
    IEnumerable<ValidationHint> Validate(string filePath);

    IEnumerable<ValidationHint> Validate(Stream stream, bool leaveOpen);

    IEnumerable<ValidationHint> Validate(GldfContainer container);
}