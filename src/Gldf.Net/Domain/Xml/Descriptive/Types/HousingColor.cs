using Gldf.Net.Domain.Xml.Global;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Descriptive.Types
{
    public class HousingColor
    {
        [XmlAttribute(AttributeName = "ral")]
        public string Ral { get; set; }

        [XmlElement(ElementName = "Locale")]
        public Locale[] ColorNames { get; set; }
    }
}