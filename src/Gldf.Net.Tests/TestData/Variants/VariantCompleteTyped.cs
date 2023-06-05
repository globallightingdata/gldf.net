using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Typed.Global;
using Gldf.Net.Domain.Typed.Head;
using Gldf.Net.Domain.Typed.Head.Types;
using Gldf.Net.Domain.Typed.Product;
using Gldf.Net.Domain.Typed.Product.Types;
using Gldf.Net.Domain.Typed.Product.Types.Mounting;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Domain.Xml.Global;
using Gldf.Net.Domain.Xml.Product.Types;
using System;
using System.Collections.Generic;

namespace Gldf.Net.Tests.TestData.Variants;

public static class VariantCompleteTyped
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
                    Id = "eulumdatFile",
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
                    Uri = "https://example.org/geo.l3d",
                    FileName = "geo.l3d"
                },
                new()
                {
                    Id = "sensorFile",
                    ContentType = FileContentType.SensorSensXml,
                    Type = FileType.Url,
                    Uri = "https://example.org/sensor.xml",
                    FileName = "sensor.xml"
                },
                new()
                {
                    Id = "pictureFile",
                    ContentType = FileContentType.ImageSvg,
                    Type = FileType.LocalFileName,
                    FileName = "picture.svg"
                }
            },
            Sensors = new List<SensorTyped>
            {
                new()
                {
                    Id = "sensor",
                    SensorFile = new GldfFileTyped
                    {
                        Id = "sensorFile",
                        ContentType = FileContentType.SensorSensXml,
                        Type = FileType.Url,
                        Uri = "https://example.org/sensor.xml",
                        FileName = "sensor.xml"
                    }
                }
            },
            Photometries = new List<PhotometryTyped>
            {
                new()
                {
                    Id = "photometry",
                    PhotometryFile = new GldfFileTyped
                    {
                        Id = "eulumdatFile",
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
                    Id = "leoEmitter",
                    ChangeableEmitterOptions = new[]
                    {
                        new ChangeableLightEmitterTyped
                        {
                            Photometry = new PhotometryTyped
                            {
                                Id = "photometry",
                                PhotometryFile = new GldfFileTyped
                                {
                                    Id = "eulumdatFile",
                                    ContentType = FileContentType.LdcEulumdat,
                                    Type = FileType.Url,
                                    Uri = "https://example.org/eulumdat.ldt",
                                    FileName = "eulumdat.ldt"
                                }
                            }
                        }
                    }
                },
                new()
                {
                    Id = "sensorEmitter",
                    SensorEmitterOptions = new[]
                    {
                        new SensorEmitterTyped
                        {
                            Sensor = new SensorTyped
                            {
                                Id = "sensor",
                                SensorFile = new GldfFileTyped
                                {
                                    Id = "sensorFile",
                                    ContentType = FileContentType.SensorSensXml,
                                    Type = FileType.Url,
                                    Uri = "https://example.org/sensor.xml",
                                    FileName = "sensor.xml"
                                }
                            }
                        }
                    }
                }
            },
            SimpleGeometries = new List<SimpleGeometryTyped>
            {
                new()
                {
                    Id = "simpleGeometry",
                    CuboidGeometry = new SimpleCuboidGeometryTyped
                    {
                        Width = 1,
                        Length = 2,
                        Height = 3
                    },
                    RectangularEmitter = new SimpleRectangularEmitterTyped
                    {
                        Width = 4,
                        Length = 5
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
                            Uri = "https://example.org/geo.l3d",
                            FileName = "geo.l3d"
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
                            Text = "Variant 1"
                        },
                        new LocaleTyped
                        {
                            Language = "de",
                            Text = "Variante 1"
                        }
                    },
                    Description = new[]
                    {
                        new LocaleTyped
                        {
                            Language = "en",
                            Text = "Variant description"
                        },
                        new LocaleTyped
                        {
                            Language = "de",
                            Text = "Variantenbeschreibung"
                        }
                    },
                    TenderText = new[]
                    {
                        new LocaleTyped
                        {
                            Language = "en",
                            Text = "Variant tender text"
                        },
                        new LocaleTyped
                        {
                            Language = "de",
                            Text = "Varianten Ausschreibungstext"
                        }
                    },
                    GTIN = "12345678",
                    Mountings = new MountingsTyped
                    {
                        Ceiling = new CeilingTyped
                        {
                            Recessed = new RecessedTyped
                            {
                                RecessedDepth = 1,
                                CircularCutout = new CircularCutoutTyped
                                {
                                    Diameter = 2,
                                    Depth = 3
                                }
                            },
                            SurfaceMounted = new SurfaceMountedTyped(),
                            Pendant = new PendantTyped
                            {
                                PendantLength = 4
                            }
                        },
                        Wall = new WallTyped
                        {
                            MountingHeight = 5,
                            Recessed = new WallRecessedTyped
                            {
                                RecessedDepth = 6,
                                RectangularCutout = new RectangularCutoutTyped
                                {
                                    Width = 7,
                                    Length = 8,
                                    Depth = 9
                                }
                            },
                            SurfaceMounted = new WallSurfaceMountedTyped()
                        },
                        WorkingPlane = new WorkingPlaneTyped
                        {
                            FreeStanding = new FreeStandingTyped()
                        },
                        Ground = new GroundTyped
                        {
                            PoleTop = new PoleTopTyped
                            {
                                PoleHeight = 11
                            },
                            PoleIntegrated = new PoleIntegratedTyped
                            {
                                PoleHeight = 12
                            },
                            FreeStanding = new FreeStandingTyped(),
                            SurfaceMounted = new SurfaceMountedTyped(),
                            Recessed = new RecessedTyped
                            {
                                RecessedDepth = 13,
                                CircularCutout = new CircularCutoutTyped
                                {
                                    Diameter = 14,
                                    Depth = 15
                                }
                            }
                        }
                    },
                    Geometry = new GeometryTyped
                    {
                        EmitterOnly = new EmitterTyped
                        {
                            Id = "leoEmitter",
                            ChangeableEmitterOptions = new ChangeableLightEmitterTyped[]
                            {
                                new()
                                {
                                    Photometry = new PhotometryTyped
                                    {
                                        Id = "photometry",
                                        PhotometryFile = new GldfFileTyped
                                        {
                                            Id = "eulumdatFile",
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
                    Pictures = new[]
                    {
                        new ImageFileTyped
                        {
                            FileName = "picture.svg",
                            ImageType = ImageType.Other,
                            ContentType = FileContentType.ImageSvg
                        },
                        new ImageFileTyped
                        {
                            FileName = "picture.svg",
                            ImageType = ImageType.TechnicalSketch,
                            ContentType = FileContentType.ImageSvg
                        },
                        new ImageFileTyped
                        {
                            FileName = "picture.svg",
                            ImageType = ImageType.ApplicationPicture,
                            ContentType = FileContentType.ImageSvg
                        },
                        new ImageFileTyped
                        {
                            FileName = "picture.svg",
                            ImageType = ImageType.ProductPicture,
                            ContentType = FileContentType.ImageSvg
                        }
                    },
                    Symbol = new GldfFileTyped
                    {
                        Id = "pictureFile",
                        ContentType = FileContentType.ImageSvg,
                        Type = FileType.LocalFileName,
                        FileName = "picture.svg"
                    }
                },
                new()
                {
                    Id = "variant-2",
                    Name = new[]
                    {
                        new LocaleTyped { Language = "en", Text = "Variant 2" }
                    },
                    ProductNumber = new LocaleTyped[]
                    {
                        new()
                        {
                            Language = "en",
                            Text = "Product number"
                        }
                    },
                    Mountings = new MountingsTyped
                    {
                        Ceiling = new CeilingTyped
                        {
                            Recessed = new RecessedTyped
                            {
                                RecessedDepth = 16,
                                RectangularCutout = new RectangularCutoutTyped
                                {
                                    Width = 17,
                                    Length = 18,
                                    Depth = 19
                                }
                            }
                        },
                        Wall = new WallTyped
                        {
                            MountingHeight = 21,
                            Recessed = new WallRecessedTyped
                            {
                                RecessedDepth = 22,
                                CircularCutout = new CircularCutoutTyped
                                {
                                    Diameter = 23,
                                    Depth = 24
                                }
                            }
                        },
                        Ground = new GroundTyped
                        {
                            Recessed = new RecessedTyped
                            {
                                RecessedDepth = 25,
                                RectangularCutout = new RectangularCutoutTyped
                                {
                                    Width = 26,
                                    Length = 27,
                                    Depth = 28
                                }
                            }
                        }
                    },
                    Geometry = new GeometryTyped
                    {
                        Simple = new SimpleGeometryEmitterTyped
                        {
                            Geometry = new SimpleGeometryTyped
                            {
                                Id = "simpleGeometry",
                                CuboidGeometry = new SimpleCuboidGeometryTyped
                                {
                                    Width = 1,
                                    Length = 2,
                                    Height = 3
                                },
                                RectangularEmitter = new SimpleRectangularEmitterTyped
                                {
                                    Width = 4,
                                    Length = 5
                                }
                            },
                            Emitter = new EmitterTyped
                            {
                                Id = "leoEmitter",
                                ChangeableEmitterOptions = new ChangeableLightEmitterTyped[]
                                {
                                    new()
                                    {
                                        Photometry = new PhotometryTyped
                                        {
                                            Id = "photometry",
                                            PhotometryFile = new GldfFileTyped
                                            {
                                                Id = "eulumdatFile",
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
                    }
                },
                new()
                {
                    Id = "variant-3",
                    SortOrder = 3,
                    Name = new[]
                    {
                        new LocaleTyped { Language = "en", Text = "Variant 3" }
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
                                        Uri = "https://example.org/geo.l3d",
                                        FileName = "geo.l3d"
                                    }
                                }
                            },
                            Emitter = new ModelEmitterTyped[]
                            {
                                new()
                                {
                                    Emitter = new EmitterTyped
                                    {
                                        Id = "leoEmitter",
                                        ChangeableEmitterOptions = new[]
                                        {
                                            new ChangeableLightEmitterTyped
                                            {
                                                Photometry = new PhotometryTyped
                                                {
                                                    Id = "photometry",
                                                    PhotometryFile = new GldfFileTyped
                                                    {
                                                        Id = "eulumdatFile",
                                                        ContentType = FileContentType.LdcEulumdat,
                                                        Type = FileType.Url,
                                                        Uri = "https://example.org/eulumdat.ldt",
                                                        FileName = "eulumdat.ldt"
                                                    }
                                                }
                                            }
                                        }
                                    },
                                    EmitterObjectExternalName = "leo1"
                                },
                                new()
                                {
                                    Emitter = new EmitterTyped
                                    {
                                        Id = "leoEmitter",
                                        ChangeableEmitterOptions = new[]
                                        {
                                            new ChangeableLightEmitterTyped
                                            {
                                                Photometry = new PhotometryTyped
                                                {
                                                    Id = "photometry",
                                                    PhotometryFile = new GldfFileTyped
                                                    {
                                                        Id = "eulumdatFile",
                                                        ContentType = FileContentType.LdcEulumdat,
                                                        Type = FileType.Url,
                                                        Uri = "https://example.org/eulumdat.ldt",
                                                        FileName = "eulumdat.ldt"
                                                    }
                                                }
                                            }
                                        }
                                    },
                                    EmitterObjectExternalName = "leo1",
                                    TargetModelType = TargetModelType.L3d
                                },
                                new()
                                {
                                    Emitter = new EmitterTyped
                                    {
                                        Id = "leoEmitter",
                                        ChangeableEmitterOptions = new[]
                                        {
                                            new ChangeableLightEmitterTyped
                                            {
                                                Photometry = new PhotometryTyped
                                                {
                                                    Id = "photometry",
                                                    PhotometryFile = new GldfFileTyped
                                                    {
                                                        Id = "eulumdatFile",
                                                        ContentType = FileContentType.LdcEulumdat,
                                                        Type = FileType.Url,
                                                        Uri = "https://example.org/eulumdat.ldt",
                                                        FileName = "eulumdat.ldt"
                                                    }
                                                }
                                            }
                                        }
                                    },
                                    EmitterObjectExternalName = "leo1",
                                    TargetModelType = TargetModelType.M3d
                                },
                                new()
                                {
                                    Emitter = new EmitterTyped
                                    {
                                        Id = "leoEmitter",
                                        ChangeableEmitterOptions = new[]
                                        {
                                            new ChangeableLightEmitterTyped
                                            {
                                                Photometry = new PhotometryTyped
                                                {
                                                    Id = "photometry",
                                                    PhotometryFile = new GldfFileTyped
                                                    {
                                                        Id = "eulumdatFile",
                                                        ContentType = FileContentType.LdcEulumdat,
                                                        Type = FileType.Url,
                                                        Uri = "https://example.org/eulumdat.ldt",
                                                        FileName = "eulumdat.ldt"
                                                    }
                                                }
                                            }
                                        }
                                    },
                                    EmitterObjectExternalName = "leo1",
                                    TargetModelType = TargetModelType.R3d
                                },
                                new()
                                {
                                    Emitter = new EmitterTyped
                                    {
                                        Id = "sensorEmitter",
                                        SensorEmitterOptions = new SensorEmitterTyped[]
                                        {
                                            new()
                                            {
                                                Sensor = new SensorTyped
                                                {
                                                    Id = "sensor",
                                                    SensorFile = new GldfFileTyped
                                                    {
                                                        Id = "sensorFile",
                                                        ContentType = FileContentType.SensorSensXml,
                                                        Type = FileType.Url,
                                                        Uri = "https://example.org/sensor.xml",
                                                        FileName = "sensor.xml"
                                                    }
                                                }
                                            }
                                        }
                                    },
                                    EmitterObjectExternalName = "sensor",
                                }
                            }
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
                                    Text = "Variant name 1"
                                },
                                new LocaleTyped
                                {
                                    Language = "de",
                                    Text = "Variantenname 1"
                                }
                            },
                            Description = new[]
                            {
                                new LocaleTyped
                                {
                                    Language = "en",
                                    Text = "Variant description"
                                },
                                new LocaleTyped
                                {
                                    Language = "de",
                                    Text = "Variantenbeschreibung"
                                }
                            },
                            Pictures = new[]
                            {
                                new ImageFileTyped
                                {
                                    FileName = "picture.svg",
                                    ContentType = FileContentType.ImageSvg,
                                    ImageType = ImageType.TechnicalSketch
                                },
                                new ImageFileTyped
                                {
                                    FileName = "picture.svg",
                                    ContentType = FileContentType.ImageSvg,
                                    ImageType = ImageType.ApplicationPicture
                                },
                                new ImageFileTyped
                                {
                                    FileName = "picture.svg",
                                    ContentType = FileContentType.ImageSvg,
                                    ImageType = ImageType.ProductPicture
                                },
                                new ImageFileTyped
                                {
                                    FileName = "picture.svg",
                                    ContentType = FileContentType.ImageSvg,
                                    ImageType = ImageType.Other
                                }
                            },
                            Hyperlinks = new[]
                            {
                                new HyperlinkTyped
                                {
                                    Href = "href1",
                                    PlainText = "Hyperlink 1"
                                },
                                new HyperlinkTyped
                                {
                                    Href = "href2",
                                    Region = "region",
                                    Language = "en",
                                    CountryCode = "de",
                                    PlainText = "Hyperlink 2"
                                }
                            }
                        },
                        new ProductSerieTyped
                        {
                            Id = "serie-2",
                            Name = new[]
                            {
                                new LocaleTyped
                                {
                                    Language = "en",
                                    Text = "Variant name 2"
                                },
                                new LocaleTyped
                                {
                                    Language = "de",
                                    Text = "Variantenname 2"
                                }
                            }
                        }
                    }
                },
                new()
                {
                    Id = "variant-4",
                    SortOrder = 4,
                    Name = new[]
                    {
                        new LocaleTyped { Language = "en", Text = "Variant 4" }
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
                        Simple = new SimpleGeometryEmitterTyped
                        {
                            Geometry = new SimpleGeometryTyped
                            {
                                Id = "simpleGeometry",
                                CuboidGeometry = new SimpleCuboidGeometryTyped
                                {
                                    Width = 1,
                                    Length = 2,
                                    Height = 3
                                },
                                RectangularEmitter = new SimpleRectangularEmitterTyped
                                {
                                    Width = 4,
                                    Length = 5
                                }
                            },
                            Emitter = new EmitterTyped
                            {
                                Id = "leoEmitter",
                                ChangeableEmitterOptions = new[]
                                {
                                    new ChangeableLightEmitterTyped
                                    {
                                        Photometry = new PhotometryTyped
                                        {
                                            Id = "photometry",
                                            PhotometryFile = new GldfFileTyped
                                            {
                                                Id = "eulumdatFile",
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
                                        Uri = "https://example.org/geo.l3d",
                                        FileName = "geo.l3d"
                                    }
                                }
                            },
                            Emitter = new ModelEmitterTyped[]
                            {
                                new()
                                {
                                    TargetModelType = TargetModelType.L3d,
                                    EmitterObjectExternalName = "Leo",
                                    Emitter = new EmitterTyped
                                    {
                                        Id = "leoEmitter",
                                        ChangeableEmitterOptions = new[]
                                        {
                                            new ChangeableLightEmitterTyped
                                            {
                                                Photometry = new PhotometryTyped
                                                {
                                                    Id = "photometry",
                                                    PhotometryFile = new GldfFileTyped
                                                    {
                                                        Id = "eulumdatFile",
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
                            }
                        }
                    }
                },
                new()
                {
                    Id = "variant-5",
                    SortOrder = 5,
                    Name = new[]
                    {
                        new LocaleTyped { Language = "en", Text = "Variant 5" }
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
                        Simple = new SimpleGeometryEmitterTyped
                        {
                            Emitter = new EmitterTyped
                            {
                                Id = "leoEmitter",
                                ChangeableEmitterOptions = new[]
                                {
                                    new ChangeableLightEmitterTyped
                                    {
                                        Photometry = new PhotometryTyped
                                        {
                                            Id = "photometry",
                                            PhotometryFile = new GldfFileTyped
                                            {
                                                Id = "eulumdatFile",
                                                ContentType = FileContentType.LdcEulumdat,
                                                Type = FileType.Url,
                                                Uri = "https://example.org/eulumdat.ldt",
                                                FileName = "eulumdat.ldt"
                                            }
                                        }
                                    }
                                }
                            },
                            Geometry = new SimpleGeometryTyped
                            {
                                Id = "simpleGeometry",
                                CuboidGeometry = new SimpleCuboidGeometryTyped
                                {
                                    Width = 1,
                                    Length = 2,
                                    Height = 3
                                },
                                RectangularEmitter = new SimpleRectangularEmitterTyped
                                {
                                    Width = 4,
                                    Length = 5
                                }
                            },
                        },
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
                                        Uri = "https://example.org/geo.l3d",
                                        FileName = "geo.l3d"
                                    }
                                }
                            },
                            Emitter = new ModelEmitterTyped[]
                            {
                                new()
                                {
                                    EmitterObjectExternalName = "Leo",
                                    Emitter = new EmitterTyped
                                    {
                                        Id = "leoEmitter",
                                        ChangeableEmitterOptions = new[]
                                        {
                                            new ChangeableLightEmitterTyped
                                            {
                                                Photometry = new PhotometryTyped
                                                {
                                                    Id = "photometry",
                                                    PhotometryFile = new GldfFileTyped
                                                    {
                                                        Id = "eulumdatFile",
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
                            }
                        }
                    }
                }
            }
        }
    };
}