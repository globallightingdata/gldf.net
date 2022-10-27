using Gldf.Net.Domain.Xml.Global;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Descriptive.Types
{
    public class CustomProperty
    {
        [XmlAttribute(DataType = "ID", AttributeName = "id")]
        public string Id { get; set; }

        public Locale[] Name { get; set; }

        public string PropertySource { get; set; }

        [XmlElement("FileReference", typeof(PropertyFileReference))]
        [XmlElement("Value", typeof(PropertyText))]
        public PropertyContentBase Content { get; set; }

        public PropertyFileReference GetAsFileReference() => Content as PropertyFileReference;

        public PropertyText GetAsText() => Content as PropertyText;
    }
}