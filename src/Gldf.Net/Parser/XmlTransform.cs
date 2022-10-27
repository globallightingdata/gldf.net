using Gldf.Net.Container;
using Gldf.Net.Parser.State;

namespace Gldf.Net.Parser
{
    internal class XmlTransform
    {
        public static XmlTransform Instance { get; } = new();

        public ContainerDto Map(string xml, bool loadOnlineFileContent)
        {
            var root = new GldfXmlSerializer().DeserializeFromString(xml);
            var gldfContainer = new GldfContainer(root);
            return new ContainerDto { Container = gldfContainer, LoadFileContent = loadOnlineFileContent };
        }
    }
}