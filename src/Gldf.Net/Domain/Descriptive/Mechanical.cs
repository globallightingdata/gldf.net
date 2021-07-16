using Gldf.Net.Domain.Global;

namespace Gldf.Net.Domain.Descriptive
{
    public class Mechanical
    {
        public TemperatureRange OperatingTemperature { get; set; }

        public Locale[] SealingMaterial { get; set; }

        public double? Weight { get; set; }

        public bool ShouldSerializeWeight() => Weight != null;
    }
}