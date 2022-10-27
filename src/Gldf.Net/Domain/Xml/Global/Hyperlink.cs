using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Global
{
    public class Hyperlink
    {
        [XmlAttribute(AttributeName = "href")]
        public string Href { get; set; }

        [XmlAttribute(DataType = "language", AttributeName = "language")]
        public string Language { get; set; }

        [XmlAttribute(AttributeName = "region")]
        public string Region { get; set; }

        [XmlAttribute(AttributeName = "countryCode")]
        public string CountryCode { get; set; }

        [XmlText]
        public string PlainText { get; set; }
    }
}