using Gldf.Net.Domain.Definition.Types;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition
{
    public class Spectrum
    {
        [XmlAttribute(DataType = "ID", AttributeName = "id")]
        public string Id { get; set; }

        [XmlElement("SpectrumFileReference")]
        public SpectrumFileReference FileReference { get; set; }

        [XmlElement("Intensity")]
        public SpectrumIntensity[] Intensities { get; set; }
    }
}