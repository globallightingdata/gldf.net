using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public enum Interface
    {
        [XmlEnum("DALI Broadcast")]
        DaliBroadcast,

        [XmlEnum("DALI Addressable")]
        DaliAddressable,

        [XmlEnum("KNX")]
        Knx,

        [XmlEnum("0-10V")]
        Volt0To10,

        [XmlEnum("1-10V")]
        Volt1To10,

        [XmlEnum("230V")]
        Volt230,

        [XmlEnum("RF")]
        Rf,

        [XmlEnum("WiFi")]
        WiFi,

        [XmlEnum("Bluetooth")]
        Bluetooth,

        [XmlEnum("Inter-Connection")]
        InterConnection,

        [XmlEnum("DMX")]
        Dmx,

        [XmlEnum("DMX/RDM")]
        DmxRdm
    }
}