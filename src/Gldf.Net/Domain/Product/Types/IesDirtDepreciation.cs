using System.Xml.Serialization;

namespace Gldf.Net.Domain.Product.Types
{
    public class IesDirtDepreciation
    {
        [XmlAttribute("years")]
        public int Years { get; set; }

        [XmlAttribute("roomCondition")]
        public DdRoomCondition RoomCondition { get; set; }

        [XmlText]
        public double Factor { get; set; }
    }
}