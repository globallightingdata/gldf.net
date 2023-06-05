using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Head.Types;

public class FormatVersion
{
    private int _preRelease;

    [XmlAttribute(AttributeName = "major")]
    public int Major { get; set; }

    [XmlAttribute(AttributeName = "minor")]
    public int Minor { get; set; }

    [XmlAttribute(AttributeName = "pre-release")]
    public int PreRelease
    {
        get => _preRelease;
        set
        {
            _preRelease = value;
            PreReleaseSpecified = true;
        }
    }

    [XmlIgnore]
    public bool PreReleaseSpecified { get; set; }

    public FormatVersion()
    {
    }

    public FormatVersion(int major, int minor)
    {
        Major = major;
        Minor = minor;
    }

    public FormatVersion(int major, int minor, int preRelease)
    {
        Major = major;
        Minor = minor;
        PreRelease = preRelease;
    }

    public override string ToString() => PreReleaseSpecified
        ? $"v{Major}.{Minor}-rc{PreRelease}"
        : $"v{Major}.{Minor}";
}