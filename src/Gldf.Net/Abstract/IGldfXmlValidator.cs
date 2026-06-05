using Gldf.Net.Validation.Model;
using System.Collections.Generic;
using System.IO;

namespace Gldf.Net.Abstract;

public interface IGldfXmlValidator
{
    public IEnumerable<ValidationHint> ValidateXml(string xml);

    public IEnumerable<ValidationHint> ValidateXmlFile(string xmlFilePath);

    public IEnumerable<ValidationHint> ValidateXmlStream(Stream xmlStream, bool leaveOpen);

    public IEnumerable<ValidationHint> ValidateGldfFile(string gldfFilePath);

    public IEnumerable<ValidationHint> ValidateGldfStream(Stream zipStream, bool leaveOpen);
}