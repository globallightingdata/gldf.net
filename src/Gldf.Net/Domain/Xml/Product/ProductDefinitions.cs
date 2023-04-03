using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Product;

public class ProductDefinitions
{
    public ProductMetaData ProductMetaData { get; set; }

    [XmlArrayItem("Variant")]
    public Variant[] Variants { get; set; }
}