// ReSharper disable InconsistentNaming

using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition.Types
{
    /// <summary>
    ///     See https://en.wikipedia.org/wiki/MacAdam_ellipse
    /// </summary>
    public enum MacAdamEllipse
    {
        [XmlEnum("1 SDCM")]
        SDCM1,

        [XmlEnum("2 SDCM")]
        SDCM2,

        [XmlEnum("3 SDCM")]
        SDCM3,

        [XmlEnum("4 SDCM")]
        SDCM4,

        [XmlEnum("5 SDCM")]
        SDCM5,

        [XmlEnum("6 SDCM")]
        SDCM6,

        [XmlEnum("7 SDCM")]
        SDCM7
    }
}