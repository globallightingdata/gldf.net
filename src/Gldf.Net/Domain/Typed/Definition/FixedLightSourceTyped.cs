using Gldf.Net.Domain.Typed.Definition.Types;

namespace Gldf.Net.Domain.Typed.Definition
{
    public class FixedLightSourceTyped : LightSourceBaseTyped
    {
        public LightSourceMaintenanceTyped Maintenance { get; set; }

        public bool? ZhagaStandard { get; set; }
    }
}