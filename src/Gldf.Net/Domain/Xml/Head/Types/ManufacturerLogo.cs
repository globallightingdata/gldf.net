using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Head.Types;

public class ManufacturerLogo
{
    [XmlAttribute(AttributeName = "fileId")]
    public string FileId { get; set; }
}