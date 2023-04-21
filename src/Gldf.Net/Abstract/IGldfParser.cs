using Gldf.Net.Container;
using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Xml;
using System.IO;

namespace Gldf.Net.Abstract;

public interface IGldfParser
{
    RootTyped ParseFromXml(string xml, IGldfXmlSerializer serializer = null);

    RootTyped ParseFromXmlFile(string xmlFilePath, IGldfXmlSerializer serializer = null);

    RootTyped ParseFromXmlStream(Stream stream, bool leaveOpen, IGldfXmlSerializer serializer = null);

    RootTyped ParseFromRoot(Root root);

    RootTyped ParseFromContainer(GldfContainer gldfContainer);

    RootTyped ParseFromContainerFile(string containerFilePath, IGldfContainerReader reader = null);

    RootTyped ParseFromContainerStream(Stream stream, bool leaveOpen, IGldfContainerReader reader = null);
}