using System.Xml.Serialization;

// ReSharper disable InconsistentNaming

namespace Gldf.Net.Domain.Xml.Descriptive.Types
{
    public enum SafetyClass
    {
        [XmlEnum("0")]
        Class0,

        [XmlEnum("I")]
        ClassI,

        [XmlEnum("0I")]
        Item0I,

        [XmlEnum("II")]
        ClassII,

        [XmlEnum("III")]
        ClassIII
    }
}