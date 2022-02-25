using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public class HalfPeakDivergence
    {
        [XmlElement("C0-C180")]
        public double C0C180 { get; set; }

        [XmlElement("C90-C270")]
        public double C90C270 { get; set; }
    }
}