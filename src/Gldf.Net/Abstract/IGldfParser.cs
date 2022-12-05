using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Xml;

namespace Gldf.Net.Abstract;

public interface IGldfParser
{
    RootTyped ParseFromXml(string xml, IGldfXmlSerializer serializer = null);

    RootTyped ParseFromXmlFile(string xmlFilePath, IGldfXmlSerializer serializer = null);

    RootTyped ParseFromRoot(Root root);

    RootTyped ParseFromContainerFile(string containerFilePath, IGldfContainerReader reader = null);
}