using System.Xml.Serialization;

namespace Gldf.Net.Domain.Descriptive.Types
{
    public class EmergencyFlux
    {

        [XmlAttribute(AttributeName = "hours")]
        public int Hours { get; set; }

        [XmlText]
        public int Flux { get; set; }
    }
}