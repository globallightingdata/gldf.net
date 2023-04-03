using Gldf.Net.Domain.Xml.Product.Types;

namespace Gldf.Net.Domain.Typed.Definition.Types;

public class JiegMaintenanceFactorTyped
{
    public int Years { get; set; }

    public JiegRoomCondition RoomCondition { get; set; }

    public double Factor { get; set; }
}