using Gldf.Net.Container;
using Gldf.Net.Validation.Model;
using System.Collections.Generic;
using System.IO;

namespace Gldf.Net.Abstract;

public interface IGldfValidator
{
    IEnumerable<ValidationHint> Validate(GldfContainer container);
    
    IEnumerable<ValidationHint> Validate(string filePath, ValidationFlags flags);
    
    IEnumerable<ValidationHint> Validate(Stream stream, bool leaveOpen, ValidationFlags flags);
}