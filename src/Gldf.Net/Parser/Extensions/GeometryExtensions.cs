using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Domain.Xml.Product.Types;
using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Parser.Extensions;

public static class GeometryExtensions
{
    public static GeometryTyped ToTyped(this GeometryReference geo, GeneralDefinitionsTyped definitions)
    {
        if (geo.Reference is GeometryReferences references)
            return new GeometryTyped
            {
                Simple = MapSingleSimpleGeo(new GeometryReference { Reference = references.SimpleGeometryReference }, definitions),
                Model = MapSingleModelGeo(new GeometryReference { Reference = references.ModelGeometryReference }, definitions)
            };
        return new GeometryTyped
        {
            EmitterOnly = MapEmitterOnly(geo, definitions),
            Simple = MapSingleSimpleGeo(geo, definitions),
            Model = MapSingleModelGeo(geo, definitions)
        };
    }

    private static EmitterTyped MapEmitterOnly(GeometryReference geo, GeneralDefinitionsTyped definitions)
    {
        var emitterReference = geo.GetReferenceAsEmitterReference();
        if (emitterReference == null) return null;
        var emitter = definitions.GetEmitterById(emitterReference.EmitterId);
        return new EmitterTyped
        {
            Id = emitterReference.EmitterId,
            ChangeableEmitterOptions = GetChangeableEmitter(emitter),
            FixedEmitterOptions = GetFixedEmitter(emitter),
            SensorEmitterOptions = GetSensorEmitter(emitter)
        };
    }

    private static SimpleGeometryEmitterTyped MapSingleSimpleGeo(GeometryReference geo, GeneralDefinitionsTyped definitions)
    {
        var reference = geo.GetReferenceAsSimpleGeometryReference();
        if (reference == null) return null;
        var emitter = definitions.GetEmitterById(reference.EmitterId);
        var geometry = definitions.SimpleGeometries.FirstOrDefault(simpleGeo => simpleGeo.Id.Equals(reference.GeometryId));
        return new SimpleGeometryEmitterTyped
        {
            Emitter = new EmitterTyped
            {
                Id = reference.EmitterId,
                ChangeableEmitterOptions = GetChangeableEmitter(emitter),
                FixedEmitterOptions = GetFixedEmitter(emitter),
                SensorEmitterOptions = GetSensorEmitter(emitter)
            },
            Geometry = geometry
        };
    }

    private static ModelGeometryEmitterTyped MapSingleModelGeo(GeometryReference geo, GeneralDefinitionsTyped definitions)
    {
        var reference = geo.GetReferenceAsModelGeometryReference();
        if (reference == null) return null;
        var geometry = definitions.ModelGeometries.FirstOrDefault(simpleGeo => simpleGeo.Id.Equals(reference.GeometryId));
        var emitterList = MapModelEmitter(reference.EmitterReferences, definitions).ToArray();
        return new ModelGeometryEmitterTyped
        {
            Geometry = geometry,
            Emitter = emitterList
        };
    }

    private static IEnumerable<ModelEmitterTyped> MapModelEmitter(IEnumerable<GeometryEmitterReference> emitters, GeneralDefinitionsTyped definitions)
    {
        return
            from emitterReference in emitters
            let emitter = definitions.GetEmitterById(emitterReference.EmitterId)
            select new ModelEmitterTyped
            {
                Emitter = new EmitterTyped
                {
                    Id = emitterReference.EmitterId,
                    ChangeableEmitterOptions = GetChangeableEmitter(emitter),
                    FixedEmitterOptions = GetFixedEmitter(emitter),
                    SensorEmitterOptions = GetSensorEmitter(emitter)
                },
                TargetModelType = emitterReference.TargetModelTypeSpecified ? emitterReference.TargetModelType : null,
                EmitterObjectExternalName = emitterReference.EmitterObjectExternalName
            };
    }

    private static ChangeableLightEmitterTyped[] GetChangeableEmitter(IEnumerable<EmitterTyped> emitter)
    {
        var emitterTyped = emitter
            .Where(e => e.ChangeableEmitterOptions != null)
            .SelectMany(e => e.ChangeableEmitterOptions).ToArray();
        return emitterTyped.Any() ? emitterTyped : null;
    }

    private static FixedLightEmitterTyped[] GetFixedEmitter(IEnumerable<EmitterTyped> emitter)
    {
        var emitterTyped = emitter
            .Where(e => e.FixedEmitterOptions != null)
            .SelectMany(e => e.FixedEmitterOptions).ToArray();
        return emitterTyped.Any() ? emitterTyped : null;
    }

    private static SensorEmitterTyped[] GetSensorEmitter(IEnumerable<EmitterTyped> emitter)
    {
        var emitterTyped = emitter
            .Where(e => e.SensorEmitterOptions != null)
            .SelectMany(e => e.SensorEmitterOptions).ToArray();
        return emitterTyped.Any() ? emitterTyped : null;
    }
}