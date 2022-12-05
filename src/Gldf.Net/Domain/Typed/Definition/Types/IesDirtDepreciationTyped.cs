using Gldf.Net.Domain.Xml.Product.Types;

namespace Gldf.Net.Domain.Typed.Definition.Types
{
    public class IesDirtDepreciationTyped
    {
        public int Years { get; set; }

        public DdRoomCondition RoomCondition { get; set; }

        public double Factor { get; set; }
    }
}