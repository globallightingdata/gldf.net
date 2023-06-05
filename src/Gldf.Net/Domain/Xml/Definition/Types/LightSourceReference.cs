using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition.Types;

public class LightSourceReference
{
    private int _lightSourceCount;
    private bool _lightSourceCountSpecified;

    [XmlAttribute(DataType = "NCName", AttributeName = "changeableLightSourceId")]
    public string ChangeableLightSourceId { get; set; }

    [XmlAttribute(AttributeName = "lightSourceCount")]
    public int LightSourceCount
    {
        get => _lightSourceCount;
        set
        {
            _lightSourceCount = value;
            LightSourceCountSpecified = value > 0;
        }
    }

    [XmlIgnore]
    public bool LightSourceCountSpecified
    {
        get => _lightSourceCountSpecified;
        set
        {
            _lightSourceCountSpecified = value;
            if (value && _lightSourceCount == 0)
                _lightSourceCount = 1;
        }
    }
}