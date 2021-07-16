using Gldf.Net.Domain.Global;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Descriptive
{
    public class Region
    {
        [XmlElement(ElementName = "Locale")]
        public Locale[] RegionName { get; set; }
    }
}