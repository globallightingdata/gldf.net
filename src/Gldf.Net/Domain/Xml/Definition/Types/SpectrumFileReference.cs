using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition.Types;

public class SpectrumFileReference
{
    [XmlAttribute(DataType = "NCName", AttributeName = "fileId")]
    public string FileId { get; set; }
}