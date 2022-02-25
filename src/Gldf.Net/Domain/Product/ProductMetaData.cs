using Gldf.Net.Domain.Descriptive;
using Gldf.Net.Domain.Global;
using Gldf.Net.Domain.Product.Types;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Product
{
    public class ProductMetaData
    {
        [XmlArrayItem("Locale")]
        public Locale[] ProductNumber { get; set; }

        [XmlArrayItem("Locale")]
        public Locale[] Product { get; set; }

        [XmlArrayItem("Locale")]
        public Locale[] Description { get; set; }

        [XmlArrayItem("Locale")]
        public Locale[] TenderText { get; set; }

        [XmlArrayItem("ProductSerie")]
        public ProductSerie[] ProductSeries { get; set; }

        [XmlArrayItem("Image")]
        public Image[] Pictures { get; set; }

        [XmlElement("LuminaireMaintenance")]
        public LuminaireMaintenance Maintenance { get; set; }

        public DescriptiveAttributes DescriptiveAttributes { get; set; }
    }
}