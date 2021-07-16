using Gldf.Net.Domain.Descriptive.Types.Atex;
using Gldf.Net.Domain.Global;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Descriptive
{
    public class MountingAndAccessory
    {
        [XmlElement(ElementName = "ATEX")]
        public Atex Atex { get; set; }

        public TemperatureRange AmbientTemperature { get; set; }
    }
}