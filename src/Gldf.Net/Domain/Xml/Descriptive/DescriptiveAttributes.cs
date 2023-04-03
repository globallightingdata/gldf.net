using Gldf.Net.Domain.Xml.Descriptive.Types;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Descriptive;

public class DescriptiveAttributes
{
    public Mechanical Mechanical { get; set; }

    public Electrical Electrical { get; set; }

    public Emergency Emergency { get; set; }

    public Marketing Marketing { get; set; }

    public OperationsAndMaintenance OperationsAndMaintenance { get; set; }

    [XmlArrayItem("Property")]
    public CustomProperty[] CustomProperties { get; set; }
}