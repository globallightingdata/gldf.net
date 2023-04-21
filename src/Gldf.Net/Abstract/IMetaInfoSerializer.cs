using Gldf.Net.Domain.Xml;
using System.IO;

namespace Gldf.Net.Abstract;

public interface IMetaInfoSerializer
{
    string SerializeToString(MetaInformation metaInformation);
    void SerializeToFile(MetaInformation metaInformation, string filePath);
    void SerializeToStream(MetaInformation metaInformation, Stream stream);

    MetaInformation DeserializeFromString(string xml);
    MetaInformation DeserializeFromFile(string filePath);
    MetaInformation DeserializeFromStream(Stream stream);
}