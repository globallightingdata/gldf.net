using Gldf.Net.Validation;
using System.Collections.Generic;

namespace Gldf.Net.Abstract
{
    public interface IGldfXmlValidator
    {
        IEnumerable<ValidationHint> ValidateXml(string xml);

        IEnumerable<ValidationHint> ValidateXmlFile(string filePath);
    }
}