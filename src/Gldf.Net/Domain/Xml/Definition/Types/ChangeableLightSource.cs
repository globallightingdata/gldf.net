﻿using Gldf.Net.Domain.Xml.Global;
using System.Xml.Serialization;

// ReSharper disable InconsistentNaming

namespace Gldf.Net.Domain.Xml.Definition.Types;

public class ChangeableLightSource : LightSourceBase
{
    public SpectrumReference SpectrumReference { get; set; }

    public ActivePowerTable ActivePowerTable { get; set; }

    public ColorInformation ColorInformation { get; set; }

    public Image[] LightSourceImages { get; set; }

    [XmlElement(ElementName = "ZVEI")]
    public string Zvei { get; set; }

    public string Socket { get; set; }

    [XmlElement(ElementName = "ILCOS")]
    public string Ilcos { get; set; }

    public int RatedLuminousFlux { get; set; }

    public int? RatedLuminousFluxRGB { get; set; }

    public PhotometryReference PhotometryReference { get; set; }

    [XmlElement("LightSourceMaintenance")]
    public LightSourceMaintenance Maintenance { get; set; }

    public bool ShouldSerializeRatedLuminousFluxRGB() => RatedLuminousFluxRGB != null;
}