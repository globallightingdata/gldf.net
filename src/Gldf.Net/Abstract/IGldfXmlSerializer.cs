using Gldf.Net.Domain.Xml;
using System.IO;
using System.Text;

namespace Gldf.Net.Abstract;

public interface IGldfXmlSerializer
{
    Encoding Encoding { get; }
    
    string SerializeToXml(Root value);
    void SerializeToXmlFile(Root value, string xmlFilePath);
    void SerializeToXmlStream(Root value, Stream xmlStream, bool leaveOpen);

    Root DeserializeFromXml(string xml);
    Root DeserializeFromXmlFile(string xmlFilePath);
    Root DeserializeFromXmlStream(Stream xmlStream, bool leaveOpen);
}