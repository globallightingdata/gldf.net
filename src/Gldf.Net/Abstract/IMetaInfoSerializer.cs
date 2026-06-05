using Gldf.Net.Domain.Xml;
using System.IO;
using System.Text;

namespace Gldf.Net.Abstract;

public interface IMetaInfoSerializer
{
    public Encoding Encoding { get; }

    public string SerializeToXml(MetaInformation value);

    public void SerializeToXmlFile(MetaInformation value, string xmlFilePath);

    public void SerializeToXmlStream(MetaInformation value, Stream xmlStream, bool leaveOpen);

    public MetaInformation DeserializeFromXml(string xml);

    public MetaInformation DeserializeFromXmlFile(string xmlFilePath);

    public MetaInformation DeserializeFromXmlStream(Stream xmlStream, bool leaveOpen);
}