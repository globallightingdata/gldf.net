using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Descriptive.Types.Atex
{
    public class AtexDivisionGroups
    {
        [XmlArrayItem("Group")]
        public AtexDivisionGroupGas[] Gas { get; set; }

        [XmlArrayItem("Group")]
        public AtexDivisionGroupDust[] Dust { get; set; }
    }
}