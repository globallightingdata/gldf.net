using Gldf.Net.Domain.Xml;
using Gldf.Net.Domain.Xml.MetaInfo;

namespace Gldf.Net.Tests.TestData.MetaInfo;

public class MetaInfo
{
    public static MetaInformation MetaInformation => new()
    {
        Properties = new Property[]
        {
            new()
            {
                Name = "Acme-Signature",
                Content = "41dad678-14fe-4ea9-a7fe-2a5a22e79aae"
            },
            new()
            {
                Name = "ExampleLLC-Signature",
                Content = "5437af9d-18c4-485e-b396-1d3d6531fb29"
            }
        }
    };
}