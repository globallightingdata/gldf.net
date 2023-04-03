using Gldf.Net.Domain.Xml;

namespace Gldf.Net.Abstract;

public interface IMetaInfoSerializer
{
    string SerializeToString(MetaInformation metaInformation);
    void SerializeToFile(MetaInformation metaInformation, string filePath);

    MetaInformation DeserializeFromString(string xml);
    MetaInformation DeserializeFromFile(string filePath);
}