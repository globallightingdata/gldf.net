using Gldf.Net.Container;
using Gldf.Net.Validation.Model;
using System.Collections.Generic;

namespace Gldf.Net.Abstract;

public interface IContainerValidationRule
{
    IEnumerable<ValidationHint> ValidateGldf(GldfContainer gldf);
}