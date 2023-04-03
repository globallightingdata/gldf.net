using Gldf.Net.Container;
using Gldf.Net.Validation;
using System.Collections.Generic;

namespace Gldf.Net.Abstract;

public interface IContainerValidationRule
{
    public int Priority { get; }

    IEnumerable<ValidationHint> Validate(GldfContainer container);
}