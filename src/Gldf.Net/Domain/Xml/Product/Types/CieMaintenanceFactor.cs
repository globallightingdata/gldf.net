using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Product.Types
{
    public class CieMaintenanceFactor
    {
        [XmlAttribute("years")]
        public int Years { get; set; }

        [XmlAttribute("roomCondition")]
        public MfRoomCondition RoomCondition { get; set; }

        [XmlText]
        public double Factor { get; set; }
    }
}