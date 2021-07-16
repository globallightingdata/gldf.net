using System.Xml.Serialization;

namespace Gldf.Net.Domain.Product.Types.Mounting
{
    public class PoleIntegrated
    {
        private double _poleHeight;

        [XmlAttribute("poleHeight")]
        public double PoleHeight
        {
            get => _poleHeight;
            set
            {
                _poleHeight = value;
                PoleHeightSpecified = true;
            }
        }

        [XmlIgnore]
        public bool PoleHeightSpecified { get; set; }
    }
}