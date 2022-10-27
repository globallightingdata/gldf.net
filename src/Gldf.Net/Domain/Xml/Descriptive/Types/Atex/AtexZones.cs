using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Descriptive.Types.Atex
{
    public class AtexZones
    {
        [XmlArrayItem("Zone")]
        public AtexZoneGas[] Gas { get; set; }

        [XmlArrayItem("Zone")]
        public AtexZoneDust[] Dust { get; set; }
    }
}