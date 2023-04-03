using Gldf.Net.Container;
using Gldf.Net.Validation;
using System.Collections.Generic;

namespace Gldf.Net.Abstract;

public interface IGldfContainerValidator
{
    IEnumerable<ValidationHint> Validate(string filePath);

    IEnumerable<ValidationHint> Validate(GldfContainer container);
}