using System.Xml.Serialization;

namespace Gldf.Net.Domain.Typed.Head.Types;

public class ManufacturerLogoTyped
{
    [XmlAttribute(AttributeName = "fileId")]
    public string FileId { get; set; }
}