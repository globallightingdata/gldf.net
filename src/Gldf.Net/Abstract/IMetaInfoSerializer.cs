using Gldf.Net.Domain.Xml;
using System.IO;
using System.Text;

namespace Gldf.Net.Abstract;

public interface IMetaInfoSerializer
{
    Encoding Encoding { get; }

    string SerializeToXml(MetaInformation value);
    void SerializeToXmlFile(MetaInformation value, string xmlFilePath);
    void SerializeToXmlStream(MetaInformation value, Stream xmlStream, bool leaveOpen);

    MetaInformation DeserializeFromXml(string xml);
    MetaInformation DeserializeFromXmlFile(string xmlFilePath);
    MetaInformation DeserializeFromXmlStream(Stream xmlStream, bool leaveOpen);
}