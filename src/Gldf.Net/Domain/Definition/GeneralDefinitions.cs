﻿using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition
{
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

        [XmlArrayItem("LightSource")]
        public LightSource[] LightSources { get; set; }

        [XmlArrayItem("ControlGear")]
        public ControlGear[] ControlGears { get; set; }

        [XmlArrayItem("Equipment")]
        public Equipment[] Equipments { get; set; }

        public Geometries Geometries { get; set; }
    }
}