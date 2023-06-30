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

namespace Gldf.Net.Tests.TestData.Geometries;

public static class GeometryMandatoryTyped
{
    public static RootTyped RootTyped => new()
    {
        Header = new HeaderTyped
        {
            Manufacturer = "DIAL",
            GldfCreationTimeCode = new DateTime(2021, 3, 29, 14, 30, 0, DateTimeKind.Utc),
            CreatedWithApplication = "Visual Studio Code",
            FormatVersion = new FormatVersionTyped { Major = 1, Minor = 0, PreRelease = 3 },
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
                    Id = "geometryFile",
                    ContentType = FileContentType.GeoL3d,
                    Type = FileType.Url,
                    Uri = "https://example.org/geometry.l3d",
                    FileName = "geometry.l3d"
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
            },
            ModelGeometries = new List<ModelGeometryTyped>
            {
                new()
                {
                    Id = "geometry",
                    GeometryFiles = new ModelFileTyped[]
                    {
                        new()
                        {
                            ContentType = FileContentType.GeoL3d,
                            Type = FileType.Url,
                            Uri = "https://example.org/geometry.l3d",
                            FileName = "geometry.l3d",
                            LevelOfDetail = LevelOfDetail.Low
                        },
                        new()
                        {
                            ContentType = FileContentType.GeoL3d,
                            Type = FileType.Url,
                            Uri = "https://example.org/geometry.l3d",
                            FileName = "geometry.l3d",
                            LevelOfDetail = LevelOfDetail.Medium
                        },
                        new()
                        {
                            ContentType = FileContentType.GeoL3d,
                            Type = FileType.Url,
                            Uri = "https://example.org/geometry.l3d",
                            FileName = "geometry.l3d",
                            LevelOfDetail = LevelOfDetail.High
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
                        }
                    },
                    Geometry = new GeometryTyped
                    {
                        Model = new ModelGeometryEmitterTyped
                        {
                            Geometry = new ModelGeometryTyped
                            {
                                Id = "geometry",
                                GeometryFiles = new ModelFileTyped[]
                                {
                                    new()
                                    {
                                        ContentType = FileContentType.GeoL3d,
                                        Type = FileType.Url,
                                        Uri = "https://example.org/geometry.l3d",
                                        FileName = "geometry.l3d",
                                        LevelOfDetail = LevelOfDetail.Low 
                                    },
                                    new()
                                    {
                                        ContentType = FileContentType.GeoL3d,
                                        Type = FileType.Url,
                                        Uri = "https://example.org/geometry.l3d",
                                        FileName = "geometry.l3d",
                                        LevelOfDetail = LevelOfDetail.Medium
                                    },
                                    new()
                                    {
                                        ContentType = FileContentType.GeoL3d,
                                        Type = FileType.Url,
                                        Uri = "https://example.org/geometry.l3d",
                                        FileName = "geometry.l3d",
                                        LevelOfDetail = LevelOfDetail.High
                                    }
                                }
                            },
                            Emitter = new[]
                            {
                                new ModelEmitterTyped
                                {
                                    Emitter = new EmitterTyped
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
                                    },
                                    EmitterObjectExternalName = "Leo"
                                }
                            }
                        }
                    }
                }
            }
        }
    };
}