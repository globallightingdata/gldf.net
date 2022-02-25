﻿using Gldf.Net.Domain;
using Gldf.Net.Domain.Definition;
using Gldf.Net.Domain.Definition.Types;
using Gldf.Net.Domain.Global;
using Gldf.Net.Domain.Head;
using Gldf.Net.Domain.Product;
using Gldf.Net.Domain.Product.Types;
using System;

namespace Gldf.Net.Tests.TestData.Variants;

public class VariantMandatoryModel
{
    public static Root Root => new()
    {
        Header = new Header
        {
            Manufacturer = "DIAL",
            CreationTimeCode = new DateTime(2021, 3, 29, 14, 30, 0, DateTimeKind.Utc),
            CreatedWithApplication = "Visual Studio Code"
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
            Geometries = new Geometry[]
            {
                new SimpleGeometry
                {
                    Id = "geometry",
                    SimpleGeometryType = new SimpleCuboidGeometry
                    {
                        Width = 1,
                        Length = 2,
                        Height = 3
                    },
                    SimpleGeometryEmitterType = new SimpleRectangularEmitter
                    {
                        Width = 4,
                        Length = 5
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
                        new LightEmitter
                        {
                            PhotometryId = "photometry"
                        }
                    }
                }
            }
        },
        ProductDefinitions = new ProductDefinitions
        {
            ProductMetaData = new ProductMetaData
            {
                ProductNumber = new[]
                {
                    new Locale
                    {
                        Language = "en",
                        Text = "Product number"
                    }
                },
                Product = new[]
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
                        new Locale
                        {
                            Language = "en",
                            Text = "Variant 1"
                        }
                    }
                },
                new Variant
                {
                    Id = "variant-2",
                    Name = new[]
                    {
                        new Locale
                        {
                            Language = "en",
                            Text = "Variant 2"
                        }
                    },
                    Reference = new SimpleGeometryReference
                    {
                        GeometryId = "geometry",
                        EmitterId = "emitter"
                    }
                }
            }
        }
    };
}