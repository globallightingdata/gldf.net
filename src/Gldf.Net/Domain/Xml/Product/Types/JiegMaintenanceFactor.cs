using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Product.Types;

public class JiegMaintenanceFactor
{
    [XmlAttribute("years")]
    public int Years { get; set; }

    [XmlAttribute("roomCondition")]
    public JiegRoomCondition RoomCondition { get; set; }

    [XmlText]
    public double Factor { get; set; }
}