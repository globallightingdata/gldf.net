using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public enum FileType
    {
        [XmlEnum("localFileName")]
        LocalFileName,

        [XmlEnum("url")]
        Url
    }
}