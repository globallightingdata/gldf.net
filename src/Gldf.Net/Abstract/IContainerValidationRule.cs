using Gldf.Net.Container;
using Gldf.Net.Validation;
using System.Collections.Generic;

namespace Gldf.Net.Abstract;

public interface IContainerValidationRule
{
    IEnumerable<ValidationHint> Validate(GldfContainer container);
}