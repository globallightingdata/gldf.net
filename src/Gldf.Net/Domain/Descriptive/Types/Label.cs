// ReSharper disable InconsistentNaming

using System.Xml.Serialization;

namespace Gldf.Net.Domain.Descriptive.Types
{
    public enum Label
    {
        [XmlEnum("CE")]
        CE,
        
        [XmlEnum("GS")]
        GS,
        
        [XmlEnum("ENEC")]
        ENEC,
        
        [XmlEnum("CCC")]
        CCC,
        
        [XmlEnum("VDE")]
        VDE,
        
        [XmlEnum("EAC")]
        EAC,
        
        [XmlEnum("D")]
        D,
        
        [XmlEnum("M")]
        M,
        
        [XmlEnum("MM")]
        MM,
        
        [XmlEnum("F")]
        F,
        
        [XmlEnum("FF")]
        FF,
        
        [XmlEnum("UL")]
        UL,
        
        [XmlEnum("Handwarm")]
        Handwarm,
        
        [XmlEnum("IFS Food")]
        IFSFood
    }
}