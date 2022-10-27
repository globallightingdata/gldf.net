using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Descriptive.Types.Atex
{
    public class AtexZoneGroups
    {
        [XmlArrayItem("Group")]
        public AtexZoneGroupGas[] Gas { get; set; }

        [XmlArrayItem("Group")]
        public AtexZoneGroupDust[] Dust { get; set; }
    }
}