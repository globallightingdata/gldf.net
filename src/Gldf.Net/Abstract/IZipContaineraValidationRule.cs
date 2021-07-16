using Gldf.Net.Validation;
using System.Collections.Generic;

namespace Gldf.Net.Abstract
{
    internal interface IZipContaineraValidationRule
    {
        public int Priority { get; }

        IEnumerable<ValidationHint> Validate(string filePath);
    }
}