using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Global
{
    public class Image
    {
        [XmlAttribute(DataType = "NCName", AttributeName = "fileId")]
        public string FileId { get; set; }

        [XmlAttribute("imageType")]
        public ImageType ImageType { get; set; }
    }
}