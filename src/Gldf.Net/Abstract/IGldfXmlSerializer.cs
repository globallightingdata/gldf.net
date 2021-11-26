using Gldf.Net.Domain;

namespace Gldf.Net.Abstract
{
    internal interface IGldfXmlSerializer
    {
        string SerializeToString(Root root);
        void SerializeToFile(Root root, string filePath);

        Root DeserializeFromString(string xml);
        Root DeserializeFromFile(string filePath);
    }
}