using Gldf.Net.Domain.Xml;
using System.IO;
using System.Text;

namespace Gldf.Net.Abstract;

public interface IGldfXmlSerializer
{
    Encoding Encoding { get; }
    
    string SerializeToXml(Root root);
    void SerializeToXmlFile(Root root, string filePath);
    void SerializeToXmlStream(Root root, Stream xmlStream);

    Root DeserializeFromXml(string xml);
    Root DeserializeFromXmlFile(string xmlFilePath);
    Root DeserializeFromXmlStream(Stream xmlStream);
}