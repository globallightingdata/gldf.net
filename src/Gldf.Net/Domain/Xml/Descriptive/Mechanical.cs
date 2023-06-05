using Gldf.Net.Domain.Xml.Descriptive.Types;
using Gldf.Net.Domain.Xml.Global;
using System.Xml.Serialization;

// ReSharper disable InconsistentNaming

namespace Gldf.Net.Domain.Xml.Descriptive;

public class Mechanical
{
    public ProductSize ProductSize { get; set; }
        
    public ProductForm? ProductForm { get; set; }

    public Locale[] SealingMaterial { get; set; }

    public Adjustability[] Adjustabilities { get; set; }
    public IKRating? IKRating { get; set; }
        
    [XmlArrayItem("Area")]
    public ProtectiveArea[] ProtectiveAreas { get; set; }
        
    public double? Weight { get; set; }

    public bool ShouldSerializeProductForm() => ProductForm != null;
        
    public bool ShouldSerializeIKRating() => IKRating != null;
        
    public bool ShouldSerializeWeight() => Weight != null;
}