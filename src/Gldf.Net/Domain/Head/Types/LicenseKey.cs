using System.Xml.Serialization;

namespace Gldf.Net.Domain.Head.Types
{
    public class LicenseKey
    {
        [XmlAttribute(AttributeName = "application")]
        public Application Application { get; set; }

        [XmlText]
        public string Key { get; set; }
    }
}