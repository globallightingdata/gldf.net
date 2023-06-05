using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Domain.Xml.Descriptive;
using Gldf.Net.Domain.Xml.Global;
using Gldf.Net.Domain.Xml.Product.Types;
using Gldf.Net.Domain.Xml.Product.Types.Mounting;
using System.Xml.Serialization;

// ReSharper disable InconsistentNaming

namespace Gldf.Net.Domain.Xml.Product;

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
    public GeometryReference Geometry { get; set; }

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