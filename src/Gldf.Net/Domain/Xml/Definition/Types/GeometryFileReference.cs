using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition.Types
{
    public class GeometryFileReference
    {
        [XmlAttribute(DataType = "NCName", AttributeName = "fileId")]
        public string FileId { get; set; }

        [XmlAttribute(AttributeName = "LevelOfDetail")]
        public LevelOfDetail LevelOfDetail
        {
            get => _levelOfDetail;
            set
            {
                _levelOfDetail = value;
                LevelOfDetailSpecified = true;
            }
        }

        [XmlIgnore]
        public bool LevelOfDetailSpecified { get; set; }

        private LevelOfDetail _levelOfDetail;
    }
}