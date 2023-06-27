using Gldf.Net.Domain.Xml.Definition.Types;
using System;
using System.Linq;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition;

public class GeneralDefinitions
{
    [XmlArrayItem("File")]
    public GldfFile[] Files { get; set; }

    [XmlArrayItem("Sensor")]
    public Sensor[] Sensors { get; set; }

    [XmlArrayItem("Photometry")]
    public Photometry[] Photometries { get; set; }

    [XmlArrayItem("Spectrum")]
    public Spectrum[] Spectrums { get; set; }

    [XmlArray("LightSources")]
    [XmlArrayItem("ChangeableLightSource", typeof(ChangeableLightSource))]
    [XmlArrayItem("FixedLightSource", typeof(FixedLightSource))]
    [XmlArrayItem("MultiChannelLightSource", typeof(MultiChannelLightSource))]
    public LightSourceBase[] LightSources { get; set; }

    [XmlArrayItem("ControlGear")]
    public ControlGear[] ControlGears { get; set; }

    [XmlArrayItem("Equipment")]
    public Equipment[] Equipments { get; set; }

    [XmlArrayItem("Emitter")]
    public Emitter[] Emitters { get; set; }

    [XmlArray("Geometries")]
    [XmlArrayItem("SimpleGeometry", typeof(SimpleGeometry))]
    [XmlArrayItem("ModelGeometry", typeof(ModelGeometry))]
    public GeometryBase[] Geometries { get; set; }

    public ChangeableLightSource[] GetAsChangeableLightSources()
        => LightSources?.OfType<ChangeableLightSource>().ToArray() ?? Array.Empty<ChangeableLightSource>();
        
    public FixedLightSource[] GetAsFixedLightSources()
        => LightSources?.OfType<FixedLightSource>().ToArray() ?? Array.Empty<FixedLightSource>();
        
    public SimpleGeometry[] GetAsSimpleGeometries()
        => Geometries?.OfType<SimpleGeometry>().ToArray() ?? Array.Empty<SimpleGeometry>();

    public ModelGeometry[] GetAsModelGeometries()
        => Geometries?.OfType<ModelGeometry>().ToArray() ?? Array.Empty<ModelGeometry>();
}