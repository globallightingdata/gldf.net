using Gldf.Net.Container;
using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Xml;
using System.IO;

namespace Gldf.Net.Abstract;

public interface IGldfParser
{
    RootTyped ParseFromXml(string xml);

    RootTyped ParseFromXmlFile(string xmlFilePath);

    RootTyped ParseFromXmlStream(Stream xmlStream, bool leaveOpen);

    RootTyped ParseFromRoot(Root root);

    RootTyped ParseFromGldf(GldfContainer gldf);

    RootTyped ParseFromGldfFile(string gldfFilePath);

    RootTyped ParseFromGldfStream(Stream zipStream, bool leaveOpen);
}