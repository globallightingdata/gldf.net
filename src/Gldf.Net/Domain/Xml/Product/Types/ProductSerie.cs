using Gldf.Net.Domain.Xml.Global;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Product.Types;

public class ProductSerie
{
    [XmlArrayItem("Locale")]
    public Locale[] Name { get; set; }

    [XmlArrayItem("Locale")]
    public Locale[] Description { get; set; }

    [XmlArrayItem("Image")]
    public Image[] Pictures { get; set; }

    [XmlArrayItem("Hyperlink")]
    public Hyperlink[] Hyperlinks { get; set; }
}