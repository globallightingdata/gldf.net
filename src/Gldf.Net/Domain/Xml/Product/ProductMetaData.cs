using Gldf.Net.Domain.Xml.Descriptive;
using Gldf.Net.Domain.Xml.Global;
using Gldf.Net.Domain.Xml.Product.Types;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Product;

public class ProductMetaData
{
    [XmlArrayItem("Locale")]
    public Locale[] ProductNumber { get; set; }

    [XmlArrayItem("Locale")]
    public Locale[] Name { get; set; }

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