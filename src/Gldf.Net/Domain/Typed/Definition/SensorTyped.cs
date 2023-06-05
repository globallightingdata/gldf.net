using Gldf.Net.Domain.Xml.Definition.Types;

namespace Gldf.Net.Domain.Typed.Definition;

public class SensorTyped : TypedBase
{
    public GldfFileTyped SensorFile { get; set; }

    public DetectorCharacteristic[] DetectorCharacteristics { get; set; }

    public DetectionMethod[] DetectionMethods { get; set; }

    public DetectorType[] DetectorTypes { get; set; }
}