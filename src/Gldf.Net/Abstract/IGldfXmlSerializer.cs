using Gldf.Net.Domain.Xml;
using System.IO;

namespace Gldf.Net.Abstract;

public interface IGldfXmlSerializer
{
    string SerializeToString(Root root);
    void SerializeToFile(Root root, string filePath);
    void SerializeToStream(Root root, Stream stream);

    Root DeserializeFromString(string xml);
    Root DeserializeFromFile(string filePath);
    Root DeserializeFromStream(Stream stream);
}