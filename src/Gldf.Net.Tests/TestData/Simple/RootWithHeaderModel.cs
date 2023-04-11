using Gldf.Net.Domain.Xml;
using Gldf.Net.Domain.Xml.Head;
using Gldf.Net.Domain.Xml.Head.Types;
using System;

namespace Gldf.Net.Tests.TestData.Simple;

public class RootWithHeaderModel
{
    public static Root Root => new()
    {
        Header = new Header
        {
            Manufacturer = "DIAL",
            GldfCreationTimeCode = new DateTime(2021, 3, 29, 14, 30, 0, DateTimeKind.Utc),
            CreatedWithApplication = "Visual Studio Code",
            FormatVersion  = new FormatVersion
            {
                Major = 1, 
                Minor = 0, 
                PreRelease = 2
            }
        }
    };
}