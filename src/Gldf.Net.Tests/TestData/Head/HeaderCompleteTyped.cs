using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Typed.Global;
using Gldf.Net.Domain.Typed.Head;
using Gldf.Net.Domain.Typed.Head.Types;
using Gldf.Net.Domain.Typed.Product;
using Gldf.Net.Domain.Xml.Definition.Types;
using System;
using System.Collections.Generic;

namespace Gldf.Net.Tests.TestData.Head;

public class HeaderCompleteTyped
{
    public static RootTyped RootTyped => new()
    {
        Header = new HeaderTyped
        {
            Manufacturer = "DIAL",
            FormatVersion = new FormatVersionTyped
            {
                Major = 1,
                Minor = 0,
                PreRelease = 2
            },
            CreatedWithApplication = "Visual Studio Code",
            GldfCreationTimeCode = new DateTime(2021, 3, 29, 14, 30, 0, DateTimeKind.Utc),
            UniqueGldfId = "3BE556FF-9061-4592-AEB1-1BC9D507280E",
            ProductDataTimeCode = new DateTime(2019, 10, 29, 6, 20, 30, DateTimeKind.Utc),
            DefaultLanguage = "de",
            ManufacturerLogo = new ManufacturerLogoTyped
            {
                FileId = "manufLogo"
            },
            LicenseKeys = new[]
            {
                new LicenseKeyTyped
                {
                    Application = "DIALux",
                    Key = "Key 1"
                },
                new LicenseKeyTyped
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
                new AddressTyped
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
                        new EMailTyped
                        {
                            Mailto = "mailto",
                            PlainText = "PlainText"
                        }
                    },
                    Websites = new[]
                    {
                        new HyperlinkTyped
                        {
                            Href = "href 1",
                            CountryCode = "de",
                            PlainText = "PlainText 1"
                        },
                        new HyperlinkTyped
                        {
                            Href = "href 2",
                            Language = "en",
                            PlainText = "PlainText 2"
                        }
                    },
                    AdditionalInfo = "AdditionalInfo"
                },
                new AddressTyped
                {
                    Name = "Name 2",
                    EMailAddresses = new[]
                    {
                        new EMailTyped
                        {
                            Mailto = "Mailto 1",
                            PlainText = "PlainText 1"
                        },
                        new EMailTyped
                        {
                            Mailto = "Mailto 2",
                            PlainText = "PlainText 2"
                        }
                    }
                }
            }
        },
        GeneralDefinitions = new GeneralDefinitionsTyped
        {
            Files = new List<GldfFileTyped>
            {
                new()
                {
                    Id = "manufLogo",
                    ContentType = FileContentType.ImagePng,
                    Type = FileType.Url,
                    FileName = "logo.png",
                    Uri = "https://example.org/logo.png"
                },
                new()
                {
                    Id = "eulumdat",
                    ContentType = FileContentType.LdcEulumdat,
                    Type = FileType.Url,
                    FileName = "eulumdat.ldt",
                    Uri = "https://example.org/eulumdat.ldt"
                }
            },
            Photometries = new List<PhotometryTyped>
            {
                new()
                {
                    Id = "photometry",
                    PhotometryFile = new GldfFileTyped
                    {
                        Id = "eulumdat",
                        ContentType = FileContentType.LdcEulumdat,
                        Type = FileType.Url,
                        FileName = "eulumdat.ldt",
                        Uri = "https://example.org/eulumdat.ldt"
                    }
                }
            },
            Emitter = new List<EmitterTyped>
            {
                new()
                {
                    Id = "emitter",
                    ChangeableEmitterOptions = new[]
                    {
                        new ChangeableLightEmitterTyped
                        {
                            Photometry = new PhotometryTyped
                            {
                                Id = "photometry",
                                PhotometryFile = new GldfFileTyped
                                {
                                    Id = "eulumdat",
                                    ContentType = FileContentType.LdcEulumdat,
                                    Type = FileType.Url,
                                    FileName = "eulumdat.ldt",
                                    Uri = "https://example.org/eulumdat.ldt"
                                }
                            }
                        }
                    }
                }
            }
        },
        ProductDefinitions = new ProductDefinitionsTyped
        {
            ProductMetaData = new ProductMetaDataTyped
            {
                UniqueProductId = "Product 1",
                ProductNumber = new[]
                {
                    new LocaleTyped
                    {
                        Language = "en",
                        Text = "Product number"
                    }
                },
                Name = new[]
                {
                    new LocaleTyped
                    {
                        Language = "en",
                        Text = "Product name"
                    }
                }
            },
            Variants = new List<VariantTyped>
            {
                new()
                {
                    Id = "variant-1",
                    ProductNumber = new[]
                    {
                        new LocaleTyped
                        {
                            Language = "en",
                            Text = "Product number"
                        }
                    },
                    Name = new[]
                    {
                        new LocaleTyped
                        {
                            Language = "en",
                            Text = "Variant 1"
                        }
                    },
                    Geometry = new GeometryTyped
                    {
                        EmitterOnly = new EmitterTyped
                        {
                            Id = "emitter",
                            ChangeableEmitterOptions = new[]
                            {
                                new ChangeableLightEmitterTyped
                                {
                                    Photometry = new PhotometryTyped
                                    {
                                        Id = "photometry",
                                        PhotometryFile = new GldfFileTyped
                                        {
                                            Id = "eulumdat",
                                            ContentType = FileContentType.LdcEulumdat,
                                            Type = FileType.Url,
                                            FileName = "eulumdat.ldt",
                                            Uri = "https://example.org/eulumdat.ldt"
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    };
}