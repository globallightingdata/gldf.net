using Gldf.Net.Validation.Model;
using System.Collections.Generic;
using System.IO;

namespace Gldf.Net.Abstract;

public interface IGldfXmlValidator
{
    IEnumerable<ValidationHint> ValidateXml(string xml);

    IEnumerable<ValidationHint> ValidateXmlFile(string xmlFilePath);

    IEnumerable<ValidationHint> ValidateXmlStream(Stream xmlStream, bool leaveOpen);

    IEnumerable<ValidationHint> ValidateGldfFile(string gldfFilePath);

    IEnumerable<ValidationHint> ValidateGldfStream(Stream zipStream, bool leaveOpen);
}