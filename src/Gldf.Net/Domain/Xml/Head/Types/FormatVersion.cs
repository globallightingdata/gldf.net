using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Head.Types;

public class FormatVersion
{
    [XmlAttribute(AttributeName = "major")]
    public int Major { get; set; }

    [XmlAttribute(AttributeName = "minor")]
    public int Minor { get; set; }

    [XmlAttribute(AttributeName = "pre-release")]
    public int? PreRelease { get; set; }
    
    // todo Tests FormatVersion.ShouldSerializePreRelease
    public bool ShouldSerializePreRelease() => PreRelease != null;

    public override string ToString() => $"v{Major}.{Minor}-rc{PreRelease}";
}