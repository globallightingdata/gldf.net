using Gldf.Net.Container;
using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Xml;
using System.IO;

namespace Gldf.Net.Abstract;

public interface IGldfParser
{
    RootTyped ParseFromXml(string xml, IGldfXmlSerializer serializer = null);

    RootTyped ParseFromXmlFile(string xmlFilePath, IGldfXmlSerializer serializer = null);

    RootTyped ParseFromXmlStream(Stream xmlStream, bool leaveOpen, IGldfXmlSerializer serializer = null);

    RootTyped ParseFromRoot(Root root);

    RootTyped ParseFromGldf(GldfContainer gldf);

    RootTyped ParseFromGldfFile(string gldfFilePath, IGldfContainerReader reader = null);

    RootTyped ParseFromGldfStream(Stream zipStream, bool leaveOpen, IGldfContainerReader reader = null);
}