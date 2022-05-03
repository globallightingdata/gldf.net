using Gldf.Net.Domain.Definition;
using Gldf.Net.Domain.Descriptive;
using Gldf.Net.Domain.Global;
using Gldf.Net.Domain.Product.Types;
using Gldf.Net.Domain.Product.Types.Mounting;
using System.Xml;
using System.Xml.Serialization;

// ReSharper disable InconsistentNaming

namespace Gldf.Net.Domain.Product
{
    public class Variant
    {
        [XmlAttribute(DataType = "ID", AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "sortOrder")]
        public int SortOrder
        {
            get => _sortOrder;
            set
            {
                _sortOrder = value;
                SortOrderSpecified = true;
            }
        }

        public Locale[] ProductNumber { get; set; }

        [XmlArrayItem("Locale")]
        public Locale[] Name { get; set; }

        [XmlArrayItem("Locale")]
        public Locale[] Description { get; set; }

        [XmlArrayItem("Locale")]
        public Locale[] TenderText { get; set; }

        public string GTIN { get; set; }

        public Mountings Mountings { get; set; }

        [XmlElement("Geometry")]
        public Geometry Geometry { get; set; }

        [XmlArrayItem("ProductSerie")]
        public ProductSerie[] ProductSeries { get; set; }

        [XmlArrayItem("Image")]
        public Image[] Pictures { get; set; }

        public Symbol Symbol { get; set; }

        public DescriptiveAttributes DescriptiveAttributes { get; set; }

        [XmlIgnore]
        public bool SortOrderSpecified { get; set; }
        
        private int _sortOrder;
    }
}