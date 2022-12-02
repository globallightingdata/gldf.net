using Gldf.Net.Domain.Typed.Definition.Types;
using System;

namespace Gldf.Net.Domain.Typed.Definition
{
    public class GeneralDefinitionsTyped
    {
        public GldfFileTyped[] Files { get; set; } = Array.Empty<GldfFileTyped>();

        public SensorTyped[] Sensors { get; set; } = Array.Empty<SensorTyped>();

        public PhotometryTyped[] Photometries { get; set; } = Array.Empty<PhotometryTyped>();

        public SpectrumTyped[] Spectrums { get; set; } = Array.Empty<SpectrumTyped>();

        public ChangeableLightSourceTyped[] ChangeableLightSources { get; set; } = Array.Empty<ChangeableLightSourceTyped>();

        public FixedLightSourceTyped[] FixedLightSources { get; set; } = Array.Empty<FixedLightSourceTyped>();

        public ControlGearTyped[] ControlGears { get; set; } = Array.Empty<ControlGearTyped>();

        public EquipmentTyped[] Equipments { get; set; } = Array.Empty<EquipmentTyped>();

        public EmitterTyped[] Emitters { get; set; } = Array.Empty<EmitterTyped>();

        public SimpleGeometryTyped[] SimpleGeometries { get; set; } = Array.Empty<SimpleGeometryTyped>();

        public ModelGeometryTyped[] ModelGeometries { get; set; } = Array.Empty<ModelGeometryTyped>();
    }
}