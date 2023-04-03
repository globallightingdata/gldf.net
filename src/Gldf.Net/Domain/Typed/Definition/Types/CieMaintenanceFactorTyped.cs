using Gldf.Net.Domain.Xml.Product.Types;

namespace Gldf.Net.Domain.Typed.Definition.Types;

public class CieMaintenanceFactorTyped
{
    public int Years { get; set; }

    public MfRoomCondition RoomCondition { get; set; }

    public double Factor { get; set; }
}