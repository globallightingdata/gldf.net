using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public class SpectrumIntensity
    {
        [XmlAttribute("wavelength")]
        public int Wavelength { get; set; }

        [XmlText]
        public double Intensity { get; set; }
    }
}