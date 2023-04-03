using System.Xml.Serialization;

namespace Gldf.Net.Domain.Typed.Head.Types;

public class EMailTyped
{
    public string Mailto { get; set; }

    [XmlText]
    public string PlainText { get; set; }
}