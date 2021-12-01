using System.Xml.Serialization;

namespace Gldf.Net.Domain.Product.Types
{
    public class GeometryEmitterReference
    {
        [XmlAttribute(DataType = "ID", AttributeName = "emitterId")]
        public string EmitterId { get; set; }

        private TargetModelType _targetModelType;

        [XmlAttribute("targetModelType")]
        public TargetModelType TargetModelType
        {
            get => _targetModelType;
            set
            {
                _targetModelType = value;
                TargetModelTypeSpecified = true;
            }
        }

        public string EmitterObjectExternalName { get; set; }

        [XmlIgnore]
        public bool TargetModelTypeSpecified { get; set; }
    }
}