using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Descriptive.Types
{
    public class AbsorptionRate
    {
        [XmlAttribute(AttributeName = "hertz")]
        public int Hertz { get; set; }

        [XmlText]
        public double Rate { get; set; }
    }
}