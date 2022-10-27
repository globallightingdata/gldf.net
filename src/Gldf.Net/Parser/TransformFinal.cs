namespace Gldf.Net.Parser
{
    internal class TransformFinal
    {
        public static TransformFinal Instance { get; } = new();

        // public RootTyped Map(SensorDto sensors, PhotometryDto photometry)
        // {
        //     return new RootTyped
        //     {
        //         Header = null,
        //         GeneralDefinitions = new GeneralDefinitionsTyped
        //         {
        //             Photometries = photometry.Photometries.ToArray(),
        //             Sensors = sensors.Sensors.ToArray()
        //         },
        //         ProductDefinitions = null
        //     };
        // }
    }
}