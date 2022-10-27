using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using System;

namespace Gldf.Net.Domain.Typed.Definition
{
    public class GeneralDefinitionsTyped
    {
        public GldfFileTyped[] Files { get; set; } = Array.Empty<GldfFileTyped>();

        public SensorTyped[] Sensors { get; set; } = Array.Empty<SensorTyped>();

        public PhotometryTyped[] Photometries { get; set; } = Array.Empty<PhotometryTyped>();

        public SpectrumTyped[] Spectrums { get; set; } = Array.Empty<SpectrumTyped>();

        public ChangeableLightSource[] ChangeableLightSources { get; set; } = Array.Empty<ChangeableLightSource>();

        public FixedLightSource[] FixedLightSources { get; set; } = Array.Empty<FixedLightSource>();

        public ControlGear[] ControlGears { get; set; } = Array.Empty<ControlGear>();

        public Equipment[] Equipments { get; set; } = Array.Empty<Equipment>();

        public Emitter[] Emitters { get; set; } = Array.Empty<Emitter>();

        public SimpleGeometry[] SimpleGeometries { get; set; } = Array.Empty<SimpleGeometry>();

        public ModelGeometry[] ModelGeometries { get; set; } = Array.Empty<ModelGeometry>();
    }
}