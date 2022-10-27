using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Head.Types
{
    public class EMail
    {
        [XmlAttribute(AttributeName = "mailto")]
        public string Mailto { get; set; }

        [XmlText]
        public string PlainText { get; set; }
    }
}