using System.Xml.Serialization;

namespace Gldf.Net.Domain.Product.Types
{
    public class EmitterReference : EmitterReferenceBase
    {
        [XmlAttribute(DataType = "ID", AttributeName = "emitterId")]
        public string EmitterId { get; set; }
    }
}