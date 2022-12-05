using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Parser.DataFlow;
using Gldf.Net.Parser.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Parser;

internal class SensorTransform : TransformBase
{
    public static ParserDto Map(ParserDto parserDto)
    {
        return ExecuteSafe(() =>
        {
            var sensors = parserDto.Container.Product.GeneralDefinitions.Sensors;
            if (sensors?.Any() != true) return parserDto;
            foreach (var sensor in sensors)
                parserDto.GeneralDefinitions.Sensors.Add(Map(sensor, parserDto.GeneralDefinitions.Files));
            return parserDto;
        }, parserDto);
    }

    private static SensorTyped Map(Sensor sensor, IEnumerable<GldfFileTyped> files)
    {
        return new SensorTyped
        {
            Id = sensor.Id,
            SensorFile = files.ToFileTyped(sensor.SensorFileReference?.FileId),
            DetectorCharacteristics = sensor.DetectorCharacteristics,
            DetectionMethods = sensor.DetectionMethods,
            DetectorTypes = sensor.DetectorTypes
        };
    }
}