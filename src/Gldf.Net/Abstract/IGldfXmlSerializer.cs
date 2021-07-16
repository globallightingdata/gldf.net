using Gldf.Net.Domain;

namespace Gldf.Net.Abstract
{
    internal interface IGldfXmlSerializer
    {
        string SerializeToXml(Root root);
        void SerializeToFile(Root root, string filePath);

        Root DeserializeFromXml(string xml);
        Root DeserializeFromFile(string filePath);
    }
}