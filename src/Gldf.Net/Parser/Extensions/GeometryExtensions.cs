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
                SimpleGeometry = MapSingleSimpleGeo(new GeometryReference { Reference = references.SimpleGeometryReference }, definitions),
                ModelGeometry = MapSingleModelGeo(new GeometryReference { Reference = references.ModelGeometryReference }, definitions)
            };
        return new GeometryTyped
        {
            EmitterOnlyGeometry = MapEmitterOnly(geo, definitions),
            SimpleGeometry = MapSingleSimpleGeo(geo, definitions),
            ModelGeometry = MapSingleModelGeo(geo, definitions)
        };
    }

    private static EmitterOnlyGeometryTyped MapEmitterOnly(GeometryReference geo, GeneralDefinitionsTyped definitions)
    {
        var emitterReference = geo.GetReferenceAsEmitterReference();
        if (emitterReference == null) return null;
        var emitter = definitions.GetEmitterById(emitterReference.EmitterId);
        return new EmitterOnlyGeometryTyped
        {
            ChangeableLightEmitter = emitter as ChangeableLightEmitterTyped,
            FixedLightEmitter = emitter as FixedLightEmitterTyped
        };
    }

    private static SingleSimpleGeometryTyped MapSingleSimpleGeo(GeometryReference geo, GeneralDefinitionsTyped definitions)
    {
        var reference = geo.GetReferenceAsSimpleGeometryReference();
        if (reference == null) return null;
        var emitter = definitions.GetEmitterById(reference.EmitterId);
        var geometry = definitions.SimpleGeometries.FirstOrDefault(simpleGeo => simpleGeo.Id.Equals(reference.GeometryId));
        return new SingleSimpleGeometryTyped
        {
            ChangeableLightEmitter = emitter as ChangeableLightEmitterTyped,
            FixedLightEmitter = emitter as FixedLightEmitterTyped,
            SimpleGeometry = geometry
        };
    }

    private static SingleModelGeometryTyped MapSingleModelGeo(GeometryReference geo, GeneralDefinitionsTyped definitions)
    {
        var reference = geo.GetReferenceAsModelGeometryReference();
        if (reference == null) return null;
        var geometry = definitions.ModelGeometries.FirstOrDefault(simpleGeo => simpleGeo.Id.Equals(reference.GeometryId));
        var emitterList = MapModelEmitter(reference.EmitterReferences, definitions).ToList();
        return new SingleModelGeometryTyped
        {
            ModelGeometry = geometry,
            Emitter = emitterList
        };
    }

    private static IEnumerable<EmitterTyped> MapModelEmitter(IEnumerable<GeometryEmitterReference> emitters, GeneralDefinitionsTyped definitions)
    {
        return
            from emitterReference in emitters
            let emitter = definitions.GetEmitterById(emitterReference.EmitterId)
            select new EmitterTyped
            {
                ChangeableLightEmitter = emitter as ChangeableLightEmitterTyped,
                FixedLightEmitter = emitter as FixedLightEmitterTyped,
                TargetModelType = emitterReference.TargetModelTypeSpecified ? emitterReference.TargetModelType : null,
                EmitterObjectExtrernalName = emitterReference.EmitterObjectExternalName,
            };
    }
}