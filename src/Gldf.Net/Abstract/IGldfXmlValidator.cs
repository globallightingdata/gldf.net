using Gldf.Net.Validation.Model;
using System.Collections.Generic;
using System.IO;

namespace Gldf.Net.Abstract;

public interface IGldfXmlValidator
{
    IEnumerable<ValidationHint> ValidateXml(string xml);

    IEnumerable<ValidationHint> ValidateXmlFile(string xmlFilePath);

    IEnumerable<ValidationHint> ValidateXmlStream(Stream stream, bool leaveOpen);

    IEnumerable<ValidationHint> ValidateGldfFile(string filePath);

    IEnumerable<ValidationHint> ValidateGldfStream(Stream stream, bool leaveOpen);
}