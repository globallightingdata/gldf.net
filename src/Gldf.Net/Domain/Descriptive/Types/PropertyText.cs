using System.Xml.Serialization;

namespace Gldf.Net.Domain.Descriptive.Types
{
    public class PropertyText : PropertyContent
    {
        [XmlText]
        public string Value { get; set; }
    }
}