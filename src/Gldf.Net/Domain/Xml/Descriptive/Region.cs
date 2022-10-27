using Gldf.Net.Domain.Xml.Global;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Descriptive
{
    public class Region
    {
        [XmlElement(ElementName = "Locale")]
        public Locale[] RegionName { get; set; }
    }
}