using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public enum Cie97LampTypeEnum
    {
        [XmlEnum("Incandescent")]
        Incandescent,

        [XmlEnum("Halogen")]
        Halogen,

        [XmlEnum("Flourescent Triphosphor")]
        FlourescentTriphosphor,

        [XmlEnum("Flourescent Halophosphate")]
        FlourescentHalophosphate,

        [XmlEnum("Compact Fluorescent")]
        CompactFluorescent,

        [XmlEnum("Mercury")]
        Mercury,

        [XmlEnum("Metal Halide (250/400W)")]
        MetalHalide250400W,

        [XmlEnum("Ceramic Metal Halide (50/150W)")]
        CeramicMetalHalide50150W,

        [XmlEnum("High Pressure Sodium (250/400W)")]
        HighPressureSodium250400W
    }
}