using Gldf.Net.Domain.Xml;
using System.IO;
using System.Text;

namespace Gldf.Net.Abstract;

public interface IGldfXmlSerializer
{
    public Encoding Encoding { get; }

    public string SerializeToXml(Root value);

    public void SerializeToXmlFile(Root value, string xmlFilePath);

    public void SerializeToXmlStream(Root value, Stream xmlStream, bool leaveOpen);

    public Root DeserializeFromXml(string xml);

    public Root DeserializeFromXmlFile(string xmlFilePath);

    public Root DeserializeFromXmlStream(Stream xmlStream, bool leaveOpen);
}