using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Xml;

namespace Gldf.Net.Abstract
{
    public interface IGldfParser
    {
        RootTyped ParseFromXml(string xml, bool loadOnlineFileContent = false);
        RootTyped ParseFromXmlFile(string xmlFilePath, bool loadOnlineFileContent = false);
        RootTyped ParseFromRoot(Root root, bool loadOnlineFileContent = false);
        RootTyped ParseFromContainerFile(string containerfilePath, bool loadFileContent = false);
    }
}