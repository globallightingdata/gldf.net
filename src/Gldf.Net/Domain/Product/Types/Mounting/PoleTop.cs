using System.Xml.Serialization;

namespace Gldf.Net.Domain.Product.Types.Mounting
{
    public class PoleTop
    {
        private int _poleHeight;

        [XmlAttribute("poleHeight")]
        public int PoleHeight
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