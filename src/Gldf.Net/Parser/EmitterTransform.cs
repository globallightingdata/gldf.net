using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Parser.DataFlow;
using Gldf.Net.Parser.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Parser;

internal class EmitterTransform : TransformBase
{
    public static ParserDto Map(ParserDto[] parserDtos)
    {
        return ExecuteSafe(() =>
        {
            var parserDto = parserDtos[0];
            var emitters = parserDto.Container.Product.GeneralDefinitions.Emitters?.ToArray();
            if (emitters == null || !emitters.Any()) return parserDto;
            foreach (var emitter in emitters)
                MapEmitter(emitter, parserDto);
            return parserDto;
        }, parserDtos[0]);
    }

    private static void MapEmitter(Emitter emitter, ParserDto parserDto)
    {
        var changeableLightEmitter = emitter.GetChangeableLightEmitters()?.ToArray();
        var fixedLightEmitter = emitter.GetFixedLightEmitters()?.ToArray();
        var sensorEmitter = emitter.GetSensorEmitters()?.ToArray();

        if (changeableLightEmitter?.Any() == true)
        {
            var changeableEmitterTyped = MapChangeable(emitter.Id, changeableLightEmitter, parserDto.GeneralDefinitions);
            parserDto.GeneralDefinitions.Emitter.Add(changeableEmitterTyped);
        }
        if (fixedLightEmitter?.Any() == true)
        {
            var fixedEmitterTyped = MapFixed(emitter.Id, fixedLightEmitter, parserDto.GeneralDefinitions);
            parserDto.GeneralDefinitions.Emitter.Add(fixedEmitterTyped);
        }
        if (sensorEmitter?.Any() == true)
        {
            var sensorEmitterTyped = MapSensor(emitter.Id, sensorEmitter, parserDto.GeneralDefinitions);
            parserDto.GeneralDefinitions.Emitter.Add(sensorEmitterTyped);
        }
    }

    private static EmitterTyped MapChangeable(string emitterId, IEnumerable<ChangeableLightEmitter> emitters,
        GeneralDefinitionsTyped definitions) => new()
    {
        Id = emitterId,
        ChangeableEmitterOptions = emitters.Select(emitter => new ChangeableLightEmitterTyped
        {
            Name = emitter.Name?.ToTypedArray(),
            Rotation = emitter.Rotation?.ToTyped(),
            Photometry = definitions.Photometries.GetTyped(emitter.PhotometryReference?.PhotometryId),
            EmergencyBehaviour = emitter.EmergencyBehaviourSpecified ? emitter.EmergencyBehaviour : null,
            Equipment = definitions.Equipments.GetTyped(emitter.EquipmentReference?.EquipmentId)
        }).ToArray()
    };

    private static EmitterTyped MapFixed(string emitterId, IEnumerable<FixedLightEmitter> emitters,
        GeneralDefinitionsTyped definitions) => new()
    {
        Id = emitterId,
        FixedEmitterOptions = emitters.Select(emitter => new FixedLightEmitterTyped
        {
            Name = emitter.Name?.ToTypedArray(),
            Rotation = emitter.Rotation?.ToTyped(),
            Photometry = definitions.Photometries.GetTyped(emitter.PhotometryReference?.PhotometryId),
            EmergencyBehaviour = emitter.EmergencyBehaviourSpecified ? emitter.EmergencyBehaviour : null,
            RatedLuminousFluxRGB = emitter.RatedLuminousFluxRGB,
            RatedLuminousFlux = emitter.RatedLuminousFlux,
            EmergencyBallastLumenFactor = emitter.GetEmergencyModeOutputAsLumenFactor()?.Factor,
            EmergencyRatedLuminousFlux = emitter.GetEmergencyModeOutputAsLuminousFlux()?.Flux,
            ControlGearCount = emitter.ControlGearReference?.ControlGearCountSpecified == true
                ? emitter.ControlGearReference?.ControlGearCount
                : null,
            ControlGear = definitions.ControlGears.GetTyped(emitter.ControlGearReference),
            FixedLightSource = definitions.FixedLightSources.GetFixedTyped(emitter.LightSourceReference)
        }).ToArray()
    };

    private static EmitterTyped MapSensor(string emitterId, IEnumerable<SensorEmitter> emitters,
        GeneralDefinitionsTyped definitions) => new()
    {
        Id = emitterId,
        SensorEmitterOptions = emitters.Select(emitter => new SensorEmitterTyped
        {
            Name = emitter.Name?.ToTypedArray(),
            Rotation = emitter.Rotation?.ToTyped(),
            Sensor = definitions.Sensors.GetTyped(emitter.SensorReference)
        }).ToArray()
    };
}