using Gldf.Net.Domain.Xml;

namespace Gldf.Net.Abstract
{
    public interface IGldfXmlSerializer
    {
        string SerializeToString(Root root);
        void SerializeToFile(Root root, string filePath);

        Root DeserializeFromString(string xml);
        Root DeserializeFromFile(string filePath);
    }
}