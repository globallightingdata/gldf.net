using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition.Types
{
    public enum FileContentType
    {
        [XmlEnum("ldc/eulumdat")]
        LdcEulumdat,

        [XmlEnum("ldc/ies")]
        LdcIes,

        [XmlEnum("ldc/iesxml")]
        LdcIesXml,

        [XmlEnum("image/png")]
        ImagePng,

        [XmlEnum("image/svg")]
        ImageSvg,

        [XmlEnum("image/jpg")]
        ImageJpg,

        [XmlEnum("geo/l3d")]
        GeoL3d,

        [XmlEnum("geo/r3d")]
        GeoR3d,

        [XmlEnum("geo/m3d")]
        GeoM3d,

        [XmlEnum("document/pdf")]
        DocPdf,

        [XmlEnum("symbol/dxf")]
        SymbolDxf,

        [XmlEnum("symbol/svg")]
        SymbolSvg,

        [XmlEnum("sensor/sensxml")]
        SensorSensXml,

        [XmlEnum("sensor/sensldt")]
        SensorSensLdt,

        [XmlEnum("spectrum/text")]
        SpectrumText,

        [XmlEnum("other")]
        Other
    }
}