using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public class SpectrumReference
    {
        [XmlAttribute(DataType = "NCName", AttributeName = "spectrumId")]
        public string SpectrumId { get; set; }
    }
}