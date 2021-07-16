using Gldf.Net.Domain;
using Gldf.Net.Domain.Head;
using Gldf.Net.Domain.Head.Types;
using System;

namespace Gldf.Net.Tests.TestData.Simple
{
    public class RootWithHeaderModel
    {
        public static Root Root => new()
        {
            Header = new Header
            {
                Manufacturer = "Manufacturer",
                CreationTimeCode = new DateTime(2021, 3, 29, 16, 30, 0).ToUniversalTime(),
                CreatedWithApplication = "Visual Studio Code",
                FormatVersion = FormatVersion.V09
            }
        };
    }
}