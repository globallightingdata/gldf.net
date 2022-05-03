using Gldf.Net.Domain.Descriptive.Types;
using Gldf.Net.Domain.Global;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Descriptive
{
    public class Marketing
    {
        [XmlArrayItem("ListPrice")]
        public ListPrice[] ListPrices { get; set; }

        public HousingColor[] HousingColors { get; set; }

        [XmlArrayItem("Region")]
        public Region[] Markets { get; set; }

        [XmlArrayItem("Hyperlink")]
        public Hyperlink[] Hyperlinks { get; set; }

        public string Designer { get; set; }

        [XmlArrayItem("ApprovalMark")]
        public string[] ApprovalMarks { get; set; }

        [XmlArrayItem("DesignAward")]
        public string[] DesignAwards { get; set; }

        [XmlArrayItem("Label")]
        public Label[] Labels { get; set; }

        [XmlArrayItem("Application")]
        public ApplicationArea[] Applications { get; set; }
    }

}