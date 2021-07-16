using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public class ControlGearReference
    {
        private int _controlGearCount;
        private bool _controlGearCountSpecified;

        [XmlAttribute(DataType = "NCName", AttributeName = "controlGearId")]
        public string ControlGearId { get; set; }

        [XmlAttribute(AttributeName = "controlGearCount")]
        public int ControlGearCount
        {
            get => _controlGearCount;
            set
            {
                _controlGearCount = value;
                ControlGearCountSpecified = value > 0;
            }
        }

        [XmlIgnore]
        public bool ControlGearCountSpecified
        {
            get => _controlGearCountSpecified;
            set
            {
                _controlGearCountSpecified = value;
                if (value && _controlGearCount < 1)
                    _controlGearCount = 1;
            }
        }
    }
}