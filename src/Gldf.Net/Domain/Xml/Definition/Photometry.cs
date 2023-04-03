using Gldf.Net.Domain.Xml.Definition.Types;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition;

public class Photometry
{
    [XmlAttribute(DataType = "ID", AttributeName = "id")]
    public string Id { get; set; }

    [XmlElement("PhotometryFileReference", typeof(PhotometryFileReference))]
    public PhotometryContentBase Content { get; set; }

    public DescriptivePhotometry DescriptivePhotometry { get; set; }

    public PhotometryFileReference GetAsFileReference() => Content as PhotometryFileReference;
}