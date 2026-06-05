using Gldf.Net.Container;
using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Xml;
using System.IO;

namespace Gldf.Net.Abstract;

public interface IGldfParser
{
    public RootTyped ParseFromXml(string xml);

    public RootTyped ParseFromXmlFile(string xmlFilePath);

    public RootTyped ParseFromXmlStream(Stream xmlStream, bool leaveOpen);

    public RootTyped ParseFromRoot(Root root);

    public RootTyped ParseFromGldf(GldfContainer gldf);

    public RootTyped ParseFromGldfFile(string gldfFilePath);

    public RootTyped ParseFromGldfStream(Stream zipStream, bool leaveOpen);
}