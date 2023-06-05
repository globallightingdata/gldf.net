using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Descriptive.Types;

public class ListPrice
{
    [XmlAttribute(AttributeName = "currency")]
    public string Currency { get; set; }

    [XmlText]
    public double Price { get; set; }
}