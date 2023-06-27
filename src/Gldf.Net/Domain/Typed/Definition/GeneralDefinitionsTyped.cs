using Gldf.Net.Domain.Typed.Definition.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Domain.Typed.Definition;

public class GeneralDefinitionsTyped
{
    public List<GldfFileTyped> Files { get; set; } = new();

    public List<SensorTyped> Sensors { get; set; } = new();

    public List<PhotometryTyped> Photometries { get; set; } = new();

    public List<SpectrumTyped> Spectrums { get; set; } = new();

    public List<ChangeableLightSourceTyped> ChangeableLightSources { get; set; } = new();

    public List<FixedLightSourceTyped> FixedLightSources { get; set; } = new();
    
    public List<MultiChannelLightSourceTyped> MultiChannelLightSources { get; set; } = new();

    public List<ControlGearTyped> ControlGears { get; set; } = new();

    public List<EquipmentTyped> Equipments { get; set; } = new();

    public List<EmitterTyped> Emitter { get; set; } = new();

    public List<SimpleGeometryTyped> SimpleGeometries { get; set; } = new();

    public List<ModelGeometryTyped> ModelGeometries { get; set; } = new();

    public List<EmitterTyped> GetEmitterById(string id)
        => Emitter.Where(emitter => emitter.Id.Equals(id, StringComparison.Ordinal)).ToList();
}