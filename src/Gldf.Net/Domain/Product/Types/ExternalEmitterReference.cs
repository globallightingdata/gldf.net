using System.Xml.Serialization;

namespace Gldf.Net.Domain.Product.Types
{
    public class ExternalEmitterReference
    {
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