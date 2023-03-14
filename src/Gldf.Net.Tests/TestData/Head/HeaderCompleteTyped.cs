using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Typed.Global;
using Gldf.Net.Domain.Typed.Head;
using Gldf.Net.Domain.Typed.Head.Types;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Domain.Xml.Head.Types;
using System;
using System.Collections.Generic;

namespace Gldf.Net.Tests.TestData.Head;

public class HeaderCompleteTyped
{
    public static RootTyped RootTyped => new()
    {
        Header = new HeaderTyped
        {
            Author = "Author",
            Manufacturer = "DIAL",
            CreationTimeCode = new DateTime(2021, 3, 29, 14, 30, 0, DateTimeKind.Utc),
            CreatedWithApplication = "Visual Studio Code",
            FormatVersion = FormatVersionTyped.V100,
            DefaultLanguage = "de",
            LicenseKeys = new[]
            {
                new LicenseKeyTyped
                {
                    Application = Application.DIALux,
                    Key = "Key 1"
                },
                new LicenseKeyTyped
                {
                    Application = Application.RELUX,
                    Key = "Key 2"
                }
            },
            ReluxMemberId = "ReluxMemberId",
            DIALuxMemberId = "DIALuxMemberId",
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