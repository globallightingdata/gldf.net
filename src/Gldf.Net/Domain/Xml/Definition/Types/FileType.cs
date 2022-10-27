using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition.Types
{
    public enum FileType
    {
        [XmlEnum("localFileName")]
        LocalFileName,

        [XmlEnum("url")]
        Url
    }
}