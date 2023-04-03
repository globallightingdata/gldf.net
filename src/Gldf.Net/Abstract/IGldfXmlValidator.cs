using Gldf.Net.Validation;
using System.Collections.Generic;

namespace Gldf.Net.Abstract;

public interface IGldfXmlValidator
{
    IEnumerable<ValidationHint> ValidateString(string xml);

    IEnumerable<ValidationHint> ValidateFile(string filePath);
}