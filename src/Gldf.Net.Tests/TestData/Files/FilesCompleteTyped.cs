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

namespace Gldf.Net.Tests.TestData.Files;

public static class FilesCompleteTyped
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
                    Language = "en",
                    Uri = "https://example.org/test.ldt",
                    FileName = "test.ldt"
                },
                new()
                {
                    Id = "ies",
                    ContentType = FileContentType.LdcIes,
                    Type = FileType.LocalFileName,
                    Language = "de",
                    FileName = "product.ies"
                },
                new()
                {
                    Id = "iesxml",
                    ContentType = FileContentType.LdcIesXml,
                    Type = FileType.LocalFileName,
                    Language = "de",
                    FileName = "product.iesxml"
                },
                new()
                {
                    Id = "jpg",
                    ContentType = FileContentType.ImageJpg,
                    Type = FileType.LocalFileName,
                    Language = "de",
                    FileName = "product.jpg"
                },
                new()
                {
                    Id = "png",
                    ContentType = FileContentType.ImagePng,
                    Type = FileType.LocalFileName,
                    Language = "de",
                    FileName = "product.png"
                },
                new()
                {
                    Id = "svg",
                    ContentType = FileContentType.ImageSvg,
                    Type = FileType.LocalFileName,
                    Language = "de",
                    FileName = "product.svg"
                },
                new()
                {
                    Id = "sensxml",
                    ContentType = FileContentType.SensorSensXml,
                    Type = FileType.LocalFileName,
                    Language = "de",
                    FileName = "product.sensxml"
                },
                new()
                {
                    Id = "sensldt",
                    ContentType = FileContentType.SensorSensLdt,
                    Type = FileType.LocalFileName,
                    Language = "de",
                    FileName = "product.sensldt"
                },
                new()
                {
                    Id = "text",
                    ContentType = FileContentType.SpectrumText,
                    Type = FileType.LocalFileName,
                    Language = "de",
                    FileName = "product.text"
                },
                new()
                {
                    Id = "l3d",
                    ContentType = FileContentType.GeoL3d,
                    Type = FileType.LocalFileName,
                    Language = "de",
                    FileName = "product.l3d"
                },
                new()
                {
                    Id = "m3d",
                    ContentType = FileContentType.GeoM3d,
                    Type = FileType.LocalFileName,
                    Language = "de",
                    FileName = "product.m3d"
                },
                new()
                {
                    Id = "r3d",
                    ContentType = FileContentType.GeoR3d,
                    Type = FileType.LocalFileName,
                    Language = "de",
                    FileName = "product.r3d"
                },
                new()
                {
                    Id = "pdf",
                    ContentType = FileContentType.DocPdf,
                    Type = FileType.LocalFileName,
                    Language = "de",
                    FileName = "product.pdf"
                },
                new()
                {
                    Id = "symbol-dxf",
                    ContentType = FileContentType.SymbolDxf,
                    Type = FileType.LocalFileName,
                    Language = "de",
                    FileName = "product.dxf"
                },
                new()
                {
                    Id = "symbol-svg",
                    ContentType = FileContentType.SymbolSvg,
                    Type = FileType.LocalFileName,
                    Language = "de",
                    FileName = "product.svg"
                },
                new()
                {
                    Id = "other",
                    ContentType = FileContentType.Other,
                    Type = FileType.LocalFileName,
                    Language = "de",
                    FileName = "product.other"
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
                        Language = "en",
                        Uri = "https://example.org/test.ldt",
                        FileName = "test.ldt"
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
                                    Language = "en",
                                    Uri = "https://example.org/test.ldt",
                                    FileName = "test.ldt"
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
                                            Language = "en",
                                            Uri = "https://example.org/test.ldt",
                                            FileName = "test.ldt"
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