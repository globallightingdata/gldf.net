using Gldf.Net.Domain.Xml;
using System.IO;

namespace Gldf.Net.Abstract;

public interface IMetaInfoSerializer
{
    string SerializeToXml(MetaInformation metaInfo);
    void SerializeToXmlFile(MetaInformation metaInfo, string xmlFilePath);
    void SerializeToXmlStream(MetaInformation metaInfo, Stream xmlStream);

    MetaInformation DeserializeFromXml(string xml);
    MetaInformation DeserializeFromXmlFile(string xmlFilePath);
    MetaInformation DeserializeFromXmlStream(Stream xmlStream);
}