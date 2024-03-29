﻿using Gldf.Net.Domain.Xml;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Domain.Xml.Global;
using Gldf.Net.Domain.Xml.Head;
using Gldf.Net.Domain.Xml.Head.Types;
using Gldf.Net.Domain.Xml.Product;
using Gldf.Net.Domain.Xml.Product.Types;
using System;

namespace Gldf.Net.Tests.TestData.Files;

public static class FilesCompleteModel
{
    public static Root Root => new()
    {
        Header = new Header
        {
            Manufacturer = "DIAL",
            GldfCreationTimeCode = new DateTime(2021, 3, 29, 14, 30, 0, DateTimeKind.Utc),
            CreatedWithApplication = "Visual Studio Code",
            FormatVersion = new FormatVersion { Major = 1, Minor = 0, PreRelease = 3, PreReleaseSpecified = true },
            UniqueGldfId = "3BE556FF-9061-4592-AEB1-1BC9D507280E"
        },
        GeneralDefinitions = new GeneralDefinitions
        {
            Files = new[]
            {
                new GldfFile
                {
                    Id = "eulumdat",
                    ContentType = FileContentType.LdcEulumdat,
                    Type = FileType.Url,
                    Language = "en",
                    File = "https://example.org/test.ldt"
                },
                new GldfFile
                {
                    Id = "ies",
                    ContentType = FileContentType.LdcIes,
                    Type = FileType.LocalFileName,
                    Language = "de",
                    File = "product.ies"
                },
                new GldfFile
                {
                    Id = "iesxml",
                    ContentType = FileContentType.LdcIesXml,
                    Type = FileType.LocalFileName,
                    Language = "de",
                    File = "product.iesxml"
                },
                new GldfFile
                {
                    Id = "jpg",
                    ContentType = FileContentType.ImageJpg,
                    Type = FileType.LocalFileName,
                    Language = "de",
                    File = "product.jpg"
                },
                new GldfFile
                {
                    Id = "png",
                    ContentType = FileContentType.ImagePng,
                    Type = FileType.LocalFileName,
                    Language = "de",
                    File = "product.png"
                },
                new GldfFile
                {
                    Id = "svg",
                    ContentType = FileContentType.ImageSvg,
                    Type = FileType.LocalFileName,
                    Language = "de",
                    File = "product.svg"
                },
                new GldfFile
                {
                    Id = "sensxml",
                    ContentType = FileContentType.SensorSensXml,
                    Type = FileType.LocalFileName,
                    Language = "de",
                    File = "product.sensxml"
                },
                new GldfFile
                {
                    Id = "sensldt",
                    ContentType = FileContentType.SensorSensLdt,
                    Type = FileType.LocalFileName,
                    Language = "de",
                    File = "product.sensldt"
                },
                new GldfFile
                {
                    Id = "text",
                    ContentType = FileContentType.SpectrumText,
                    Type = FileType.LocalFileName,
                    Language = "de",
                    File = "product.text"
                },
                new GldfFile
                {
                    Id = "l3d",
                    ContentType = FileContentType.GeoL3d,
                    Type = FileType.LocalFileName,
                    Language = "de",
                    File = "product.l3d"
                },
                new GldfFile
                {
                    Id = "m3d",
                    ContentType = FileContentType.GeoM3d,
                    Type = FileType.LocalFileName,
                    Language = "de",
                    File = "product.m3d"
                },
                new GldfFile
                {
                    Id = "r3d",
                    ContentType = FileContentType.GeoR3d,
                    Type = FileType.LocalFileName,
                    Language = "de",
                    File = "product.r3d"
                },
                new GldfFile
                {
                    Id = "pdf",
                    ContentType = FileContentType.DocPdf,
                    Type = FileType.LocalFileName,
                    Language = "de",
                    File = "product.pdf"
                },
                new GldfFile
                {
                    Id = "symbol-dxf",
                    ContentType = FileContentType.SymbolDxf,
                    Type = FileType.LocalFileName,
                    Language = "de",
                    File = "product.dxf"
                },
                new GldfFile
                {
                    Id = "symbol-svg",
                    ContentType = FileContentType.SymbolSvg,
                    Type = FileType.LocalFileName,
                    Language = "de",
                    File = "product.svg"
                },
                new GldfFile
                {
                    Id = "other",
                    ContentType = FileContentType.Other,
                    Type = FileType.LocalFileName,
                    Language = "de",
                    File = "product.other"
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