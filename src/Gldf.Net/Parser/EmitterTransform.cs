using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Parser.DataFlow;
using Gldf.Net.Parser.Extensions;
using System;
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
            var emitters = parserDto.Container.Product.GeneralDefinitions.Emitters?.ToList();
            if (emitters?.Any() != true) return parserDto;
            foreach (var emitter in emitters)
                MapEmitter(emitter, parserDto);
            return parserDto;
        }, parserDtos[0]);
    }

    private static void MapEmitter(Emitter emitter, ParserDto parserDto)
    {
        var changeableLightEmitter = emitter.GetChangeableLightEmitters()?.ToList();
        var fixedLightEmitter = emitter.GetFixedLightEmitters()?.ToList();
        var sensorEmitter = emitter.GetSensorEmitters()?.ToList();

        if (changeableLightEmitter?.Any() == true)
        {
            var changeableEmitterTyped = MapChangeable(emitter.Id, changeableLightEmitter, parserDto.GeneralDefinitions);
            parserDto.GeneralDefinitions.ChangeableLightEmitters.AddRange(changeableEmitterTyped);
        }
        if (fixedLightEmitter?.Any() == true)
        {
            var fixedEmitterTyped = MapFixed(emitter.Id, fixedLightEmitter, parserDto.GeneralDefinitions);
            parserDto.GeneralDefinitions.FixedLightEmitters.AddRange(fixedEmitterTyped);
        }
        if (sensorEmitter?.Any() == true)
        {
            var sensorEmitterTyped = MapSensor(emitter.Id, sensorEmitter, parserDto.GeneralDefinitions);
            parserDto.GeneralDefinitions.SensorEmitters.AddRange(sensorEmitterTyped);
        }
    }

    private static IEnumerable<ChangeableLightEmitterTyped> MapChangeable(string emitterId, IEnumerable<ChangeableLightEmitter> emitters,
        GeneralDefinitionsTyped definitions)
    {
        return emitters.Select(emitter => new ChangeableLightEmitterTyped
        {
            Id = emitterId,
            Name = emitter.Name?.ToTypedArray(),
            Rotation = emitter.Rotation?.ToTyped(),
            Photometry = definitions.Photometries.GetTyped(emitter.PhotometryReference.PhotometryId),
            EmergencyBehaviour = emitter.EmergencyBehaviourSpecified ? emitter.EmergencyBehaviour : null,
            Equipment = definitions.Equipments.GetTyped(emitter.EquipmentReference.EquipmentId)
        });
    }

    private static IEnumerable<FixedLightEmitterTyped> MapFixed(string emitterId, IEnumerable<FixedLightEmitter> emitters,
        GeneralDefinitionsTyped definitions)
    {
        return emitters.Select(emitter => new FixedLightEmitterTyped
        {
            Id = emitterId,
            Name = emitter.Name?.ToTypedArray(),
            Rotation = emitter.Rotation?.ToTyped(),
            Photometry = definitions.Photometries.GetTyped(emitter.PhotometryReference.PhotometryId),
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
        });
    }

    private static IEnumerable<SensorEmitterTyped> MapSensor(string emitterId, IEnumerable<SensorEmitter> emitters,
        GeneralDefinitionsTyped definitions)
    {
        return emitters.Select(emitter => new SensorEmitterTyped
        {
            Id = emitterId,
            Name = emitter.Name?.ToTypedArray(),
            Rotation = emitter.Rotation?.ToTyped(),
            Photometry = definitions.Photometries.GetTyped(emitter.PhotometryReference.PhotometryId),
            Sensor = definitions.Sensors.FirstOrDefault(sensor => sensor.Id.Equals(emitter.SensorId, StringComparison.Ordinal))
        });
    }
}