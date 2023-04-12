using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Typed.Global;
using Gldf.Net.Domain.Typed.Head;
using Gldf.Net.Domain.Typed.Head.Types;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Domain.Xml.Global;
using Gldf.Net.Domain.Xml.Product.Types;
using System;
using System.Collections.Generic;

namespace Gldf.Net.Tests.TestData.MetaData;

public static class ProductMetaDataCompleteTyped
{
    public static RootTyped RootTyped => new()
    {
        Header = new HeaderTyped
        {
            Manufacturer = "DIAL",
            GldfCreationTimeCode = new DateTime(2021, 3, 29, 14, 30, 0, DateTimeKind.Utc),
            CreatedWithApplication = "Visual Studio Code",
            FormatVersion = new FormatVersionTyped { Major = 1, Minor = 0, PreRelease = 2 },
            UniqueGldfId = "3BE556FF-9061-4592-AEB1-1BC9D507280E"
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
                    Uri = "https://example.org/eulumdat.ldt",
                    FileName = "eulumdat.ldt"
                },
                new()
                {
                    Id = "image",
                    ContentType = FileContentType.ImagePng,
                    Type = FileType.Url,
                    Uri = "https://example.org/image.png",
                    FileName = "image.png"
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
                        Uri = "https://example.org/eulumdat.ldt",
                        FileName = "eulumdat.ldt"
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
                                    Uri = "https://example.org/eulumdat.ldt",
                                    FileName = "eulumdat.ldt"
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
                    },
                    new LocaleTyped
                    {
                        Language = "de",
                        Text = "Produktnummer"
                    }
                },
                Name = new[]
                {
                    new LocaleTyped
                    {
                        Language = "en",
                        Text = "Product name"
                    },
                    new LocaleTyped
                    {
                        Language = "de",
                        Text = "Produktname"
                    }
                },
                Description = new[]
                {
                    new LocaleTyped
                    {
                        Language = "en",
                        Text = "Product description"
                    },
                    new LocaleTyped
                    {
                        Language = "de",
                        Text = "Produktbeschreibung"
                    }
                },
                TenderText = new[]
                {
                    new LocaleTyped
                    {
                        Language = "en",
                        Text = "Product tendertext"
                    },
                    new LocaleTyped
                    {
                        Language = "de",
                        Text = "Produkt Auschreibungstext"
                    }
                },
                ProductSeries = new[]
                {
                    new ProductSerieTyped
                    {
                        Id = "serie-1",
                        Name = new[]
                        {
                            new LocaleTyped
                            {
                                Language = "en",
                                Text = "Product series name"
                            },
                            new LocaleTyped
                            {
                                Language = "de",
                                Text = "Produktserienname"
                            }
                        },
                        Description = new[]
                        {
                            new LocaleTyped
                            {
                                Language = "en",
                                Text = "Product series description"
                            },
                            new LocaleTyped
                            {
                                Language = "de",
                                Text = "Produktserienbeschreibung"
                            }
                        },
                        Pictures = new[]
                        {
                            new ImageFileTyped
                            {
                                FileName = "image.png",
                                Uri = "https://example.org/image.png",
                                ImageType = ImageType.ProductPicture,
                                ContentType = FileContentType.ImagePng,
                                Type = FileType.Url
                            },
                            new ImageFileTyped
                            {
                                FileName = "image.png",
                                ImageType = ImageType.ApplicationPicture,
                                Uri = "https://example.org/image.png",
                                ContentType = FileContentType.ImagePng,
                                Type = FileType.Url
                            },
                            new ImageFileTyped
                            {
                                FileName = "image.png",
                                ImageType = ImageType.TechnicalSketch,
                                Uri = "https://example.org/image.png",
                                ContentType = FileContentType.ImagePng,
                                Type = FileType.Url
                            },
                            new ImageFileTyped
                            {
                                FileName = "image.png",
                                ImageType = ImageType.Other,
                                Uri = "https://example.org/image.png",
                                ContentType = FileContentType.ImagePng,
                                Type = FileType.Url
                            }
                        },
                        Hyperlinks = new[]
                        {
                            new HyperlinkTyped
                            {
                                Href = "https://example.org",
                                Language = "en",
                                Region = "eu",
                                CountryCode = "gb",
                                PlainText = "Hyperlink PlainText"
                            }
                        }
                    }
                },
                Pictures = new[]
                {
                    new ImageFileTyped
                    {
                        ImageType = ImageType.Other,
                        FileName = "image.png",
                        ContentType = FileContentType.ImagePng,
                        Type = FileType.Url,
                        Uri = "https://example.org/image.png"
                    }
                },
                Maintenance = new LuminaireMaintenanceTyped
                {
                    Cie97LuminaireType = Cie97LuminaireType.DustProofIp5X,
                    CieMaintenanceFactors = new[]
                    {
                        new CieMaintenanceFactorTyped
                        {
                            Years = 1,
                            RoomCondition = MfRoomCondition.Dirty,
                            Factor = 0.1
                        },
                        new CieMaintenanceFactorTyped
                        {
                            Years = 2,
                            RoomCondition = MfRoomCondition.Normal,
                            Factor = 0.2
                        },
                        new CieMaintenanceFactorTyped
                        {
                            Years = 3,
                            RoomCondition = MfRoomCondition.VeryClean,
                            Factor = 0.2
                        },
                        new CieMaintenanceFactorTyped
                        {
                            Years = 4,
                            RoomCondition = MfRoomCondition.Clean,
                            Factor = 0.2
                        }
                    },
                    IesLightLossFactors = new[]
                    {
                        new IesDirtDepreciationTyped
                        {
                            Years = 5,
                            RoomCondition = DdRoomCondition.VeryClean,
                            Factor = 0.3
                        },
                        new IesDirtDepreciationTyped
                        {
                            Years = 6,
                            RoomCondition = DdRoomCondition.VeryDirty,
                            Factor = 0.4
                        },
                        new IesDirtDepreciationTyped
                        {
                            Years = 7,
                            RoomCondition = DdRoomCondition.Dirty,
                            Factor = 0.4
                        },
                        new IesDirtDepreciationTyped
                        {
                            Years = 8,
                            RoomCondition = DdRoomCondition.Clean,
                            Factor = 0.4
                        },
                        new IesDirtDepreciationTyped
                        {
                            Years = 9,
                            RoomCondition = DdRoomCondition.Moderate,
                            Factor = 0.4
                        }
                    },
                    JiegMaintenanceFactors = new[]
                    {
                        new JiegMaintenanceFactorTyped
                        {
                            Years = 10,
                            RoomCondition = JiegRoomCondition.Normal,
                            Factor = 0.5
                        },
                        new JiegMaintenanceFactorTyped
                        {
                            Years = 11,
                            RoomCondition = JiegRoomCondition.Dirty,
                            Factor = 0.6
                        },
                        new JiegMaintenanceFactorTyped
                        {
                            Years = 12,
                            RoomCondition = JiegRoomCondition.Clean,
                            Factor = 0.6
                        }
                    }
                },
                DescriptiveAttributes = new DescriptiveAttributesTyped()
            },
            Variants = new List<VariantTyped>
            {
                new()
                {
                    Id = "variant-1",
                    Name = new[]
                    {
                        new LocaleTyped { Language = "en", Text = "Variant 1" }
                    },
                    ProductNumber = new LocaleTyped[]
                    {
                        new()
                        {
                            Language = "en",
                            Text = "Product number"
                        },
                        new()
                        {
                            Language = "de",
                            Text = "Produktnummer"
                        }
                    },
                    Description = new LocaleTyped[]
                    {
                        new()
                        {
                            Language = "en",
                            Text = "Product description"
                        },
                        new()
                        {
                            Language = "de",
                            Text = "Produktbeschreibung"
                        }
                    },
                    TenderText = new LocaleTyped[]
                    {
                        new()
                        {
                            Language = "en",
                            Text = "Product tendertext"
                        },
                        new()
                        {
                            Language = "de",
                            Text = "Produkt Auschreibungstext"
                        }
                    },
                    Geometry = new GeometryTyped
                    {
                        EmitterOnly = new EmitterTyped
                        {
                            Id = "emitter",
                            ChangeableEmitterOptions = new ChangeableLightEmitterTyped[]
                            {
                                new()
                                {
                                    Photometry = new PhotometryTyped
                                    {
                                        Id = "photometry",
                                        PhotometryFile = new GldfFileTyped
                                        {
                                            Id = "eulumdat",
                                            ContentType = FileContentType.LdcEulumdat,
                                            Type = FileType.Url,
                                            Uri = "https://example.org/eulumdat.ldt",
                                            FileName = "eulumdat.ldt"
                                        }
                                    }
                                }
                            }
                        }
                    },
                    ProductSeries = new ProductSerieTyped[]
                    {
                        new()
                        {
                            Id = "serie-1",
                            Description = new LocaleTyped[]
                            {
                                new()
                                {
                                    Language = "en",
                                    Text = "Product series description"
                                },
                                new()
                                {
                                    Language = "de",
                                    Text = "Produktserienbeschreibung"
                                }
                            },
                            Hyperlinks = new HyperlinkTyped[]
                            {
                                new()
                                {
                                    CountryCode = "gb",
                                    Href = "https://example.org",
                                    Language = "en",
                                    PlainText = "Hyperlink PlainText",
                                    Region = "eu"
                                }
                            },
                            Name = new LocaleTyped[]
                            {
                                new()
                                {
                                    Language = "en",
                                    Text = "Product series name"
                                },
                                new()
                                {
                                    Language = "de",
                                    Text = "Produktserienname"
                                }
                            },
                            Pictures = new[]
                            {
                                new ImageFileTyped
                                {
                                    FileName = "image.png",
                                    Uri = "https://example.org/image.png",
                                    ImageType = ImageType.ProductPicture,
                                    ContentType = FileContentType.ImagePng,
                                    Type = FileType.Url
                                },
                                new ImageFileTyped
                                {
                                    FileName = "image.png",
                                    ImageType = ImageType.ApplicationPicture,
                                    Uri = "https://example.org/image.png",
                                    ContentType = FileContentType.ImagePng,
                                    Type = FileType.Url
                                },
                                new ImageFileTyped
                                {
                                    FileName = "image.png",
                                    ImageType = ImageType.TechnicalSketch,
                                    Uri = "https://example.org/image.png",
                                    ContentType = FileContentType.ImagePng,
                                    Type = FileType.Url
                                },
                                new ImageFileTyped
                                {
                                    FileName = "image.png",
                                    ImageType = ImageType.Other,
                                    Uri = "https://example.org/image.png",
                                    ContentType = FileContentType.ImagePng,
                                    Type = FileType.Url
                                }
                            }
                        }
                    },
                    Pictures = new ImageFileTyped[]
                    {
                        new()
                        {
                            ImageType = ImageType.Other,
                            FileName = "image.png",
                            ContentType = FileContentType.ImagePng,
                            Type = FileType.Url,
                            Uri = "https://example.org/image.png"
                        }
                    }
                }
            }
        }
    };
}