using Gldf.Net.Domain.Xml;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Domain.Xml.Global;
using Gldf.Net.Domain.Xml.Head;
using Gldf.Net.Domain.Xml.Head.Types;
using Gldf.Net.Domain.Xml.Product;
using Gldf.Net.Domain.Xml.Product.Types;
using System;

namespace Gldf.Net.Tests.TestData.Head;

public class HeaderCompleteModel
{
    public static Root Root => new()
    {
        Header = new Header
        {
            Manufacturer = "DIAL",
            FormatVersion = new FormatVersion { Major = 1, Minor = 0, PreRelease = 2, PreReleaseSpecified = true },
            CreatedWithApplication = "Visual Studio Code",
            GldfCreationTimeCode = new DateTime(2021, 3, 29, 14, 30, 0, DateTimeKind.Utc),
            UniqueGldfId = "3BE556FF-9061-4592-AEB1-1BC9D507280E",
            ProductDataTimeCode = new DateTime(2019, 10, 29, 6, 20, 30, DateTimeKind.Utc),
            DefaultLanguage = "de",
            ManufacturerLogo = new ManufacturerLogo
            {
                FileId = "manufLogo"
            },
            LicenseKeys = new[]
            {
                new LicenseKey
                {
                    Application = "DIALux",
                    Key = "Key 1"
                },
                new LicenseKey
                {
                    Application = "RELUX",
                    Key = "Key 2"
                }
            },
            ReluxMemberId = "ReluxMemberId",
            DIALuxMemberId = "DIALuxMemberId",
            Author = "Author",
            Contact = new[]
            {
                new Address
                {
                    FirstName = "FirstName",
                    Name = "Name 1",
                    Street = "Street",
                    Number = "Number",
                    ZipCode = "ZipCode",
                    City = "City",
                    Country = "Country",
                    Phone = "Phone",
                    EMailAddresses = new[]
                    {
                        new EMail
                        {
                            Mailto = "mailto",
                            PlainText = "PlainText"
                        }
                    },
                    Websites = new[]
                    {
                        new Hyperlink
                        {
                            Href = "href 1",
                            CountryCode = "de",
                            PlainText = "PlainText 1"
                        },
                        new Hyperlink
                        {
                            Href = "href 2",
                            Language = "en",
                            PlainText = "PlainText 2"
                        }
                    },
                    AdditionalInfo = "AdditionalInfo"
                },
                new Address
                {
                    Name = "Name 2",
                    EMailAddresses = new[]
                    {
                        new EMail
                        {
                            Mailto = "Mailto 1",
                            PlainText = "PlainText 1"
                        },
                        new EMail
                        {
                            Mailto = "Mailto 2",
                            PlainText = "PlainText 2"
                        }
                    }
                }
            }
        },
        GeneralDefinitions = new GeneralDefinitions
        {
            Files = new[]
            {
                new GldfFile
                {
                    Id = "manufLogo",
                    ContentType = FileContentType.ImagePng,
                    Type = FileType.Url,
                    File = "https://example.org/logo.png"
                },
                new GldfFile
                {
                    Id = "eulumdat",
                    ContentType = FileContentType.LdcEulumdat,
                    Type = FileType.Url,
                    File = "https://example.org/eulumdat.ldt"
                }
            },
            Photometries = new[]
            {
                new Photometry
                {
                    Id = "photometry",
                    Content = new PhotometryFileReference
                    {
                        FileId = "eulumdat"
                    }
                }
            },
            Emitters = new[]
            {
                new Emitter
                {
                    Id = "emitter",
                    PossibleFittings = new EmitterBase[]
                    {
                        new ChangeableLightEmitter
                        {
                            PhotometryReference = new PhotometryReference
                            {
                                PhotometryId = "photometry"
                            }
                        }
                    }
                }
            }
        },
        ProductDefinitions = new ProductDefinitions
        {
            ProductMetaData = new ProductMetaData
            {
                UniqueProductId = "Product 1",
                ProductNumber = new[]
                {
                    new Locale
                    {
                        Language = "en",
                        Text = "Product number"
                    }
                },
                Name = new[]
                {
                    new Locale
                    {
                        Language = "en",
                        Text = "Product name"
                    }
                }
            },
            Variants = new[]
            {
                new Variant
                {
                    Id = "variant-1",
                    Name = new[]
                    {
                        new Locale { Language = "en", Text = "Variant 1" }
                    },
                    Geometry = new GeometryReference
                    {
                        Reference = new EmitterReference
                        {
                            EmitterId = "emitter"
                        }
                    }
                }
            }
        }
    };
}