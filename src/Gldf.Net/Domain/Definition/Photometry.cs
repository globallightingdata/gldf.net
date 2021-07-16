using Gldf.Net.Domain.Definition.Types;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition
{
    public class Photometry
    {
        [XmlAttribute(DataType = "ID", AttributeName = "id")]
        public string Id { get; set; }

        [XmlElement("PhotometryFileReference", typeof(PhotometryFileReference))]
        public PhotometryContent Content { get; set; }

        [XmlElement("Rotation-G0")]
        public int? RotationG0 { get; set; }

        public DescriptivePhotometry DescriptivePhotometry { get; set; }

        public bool ShouldSerializeRotationG0() => RotationG0 != null;

        public PhotometryFileReference GetAsFileReference() => Content as PhotometryFileReference;
    }

}