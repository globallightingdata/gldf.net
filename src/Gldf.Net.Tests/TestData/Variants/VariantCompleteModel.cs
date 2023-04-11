using Gldf.Net.Domain.Xml;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Domain.Xml.Global;
using Gldf.Net.Domain.Xml.Head;
using Gldf.Net.Domain.Xml.Product;
using Gldf.Net.Domain.Xml.Product.Types;
using Gldf.Net.Domain.Xml.Product.Types.Mounting;
using System;

namespace Gldf.Net.Tests.TestData.Variants;

public class VariantCompleteModel
{
    public static Root Root => new()
    {
        Header = new Header
        {
            Manufacturer = "DIAL",
            GldfCreationTimeCode = new DateTime(2021, 3, 29, 14, 30, 0, DateTimeKind.Utc),
            CreatedWithApplication = "Visual Studio Code"
        },
        GeneralDefinitions = new GeneralDefinitions
        {
            Files = new[]
            {
                new GldfFile
                {
                    Id = "eulumdatFile",
                    ContentType = FileContentType.LdcEulumdat,
                    Type = FileType.Url,
                    File = "https://example.org/eulumdat.ldt"
                },
                new GldfFile
                {
                    Id = "geometryFile",
                    ContentType = FileContentType.GeoL3d,
                    Type = FileType.Url,
                    File = "https://example.org/geo.l3d"
                },
                new GldfFile
                {
                    Id = "sensorFile",
                    ContentType = FileContentType.SensorSensXml,
                    Type = FileType.Url,
                    File = "https://example.org/sensor.xml"
                },
                new GldfFile
                {
                    Id = "pictureFile",
                    ContentType = FileContentType.ImageSvg,
                    Type = FileType.LocalFileName,
                    File = "picture.svg"
                }
            },
            Sensors = new[]
            {
                new Sensor
                {
                    Id = "sensor",
                    SensorFileReference = new SensorFileReference
                    {
                        FileId = "sensorFile"
                    }
                }
            },
            Photometries = new[]
            {
                new Photometry
                {
                    Id = "photometry",
                    Content = new PhotometryFileReference
                    {
                        FileId = "eulumdatFile"
                    }
                }
            },
            Emitters = new[]
            {
                new Emitter
                {
                    Id = "leoEmitter",
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
                },
                new Emitter
                {
                    Id = "sensorEmitter",
                    PossibleFittings = new EmitterBase[]
                    {
                        new SensorEmitter
                        {
                            SensorId = "sensor"
                        }
                    }
                }
            },
            Geometries = new GeometryBase[]
            {
                new SimpleGeometry
                {
                    Id = "simpleGeometry",
                    GeometryType = new SimpleCuboidGeometry
                    {
                        Width = 1,
                        Length = 2,
                        Height = 3
                    },
                    EmitterType = new SimpleRectangularEmitter
                    {
                        Width = 4,
                        Length = 5
                    }
                },
                new ModelGeometry
                {
                    Id = "geometry",
                    GeometryFileReferences = new GeometryFileReference[]
                    {
                        new()
                        {
                            FileId = "geometryFile"
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
                    ProductNumber = new[]
                    {
                        new Locale
                        {
                            Language = "en",
                            Text = "Product number"
                        },
                        new Locale
                        {
                            Language = "de",
                            Text = "Produktnummer"
                        }
                    },
                    Name = new[]
                    {
                        new Locale
                        {
                            Language = "en",
                            Text = "Variant 1"
                        },
                        new Locale
                        {
                            Language = "de",
                            Text = "Variante 1"
                        }
                    },
                    Description = new[]
                    {
                        new Locale
                        {
                            Language = "en",
                            Text = "Variant description"
                        },
                        new Locale
                        {
                            Language = "de",
                            Text = "Variantenbeschreibung"
                        }
                    },
                    TenderText = new[]
                    {
                        new Locale
                        {
                            Language = "en",
                            Text = "Variant tender text"
                        },
                        new Locale
                        {
                            Language = "de",
                            Text = "Varianten Ausschreibungstext"
                        }
                    },
                    GTIN = "12345678",
                    Mountings = new Mountings
                    {
                        Ceiling = new Ceiling
                        {
                            Recessed = new Recessed
                            {
                                RecessedDepth = 1,
                                Cutout = new CircularCutout
                                {
                                    Diameter = 2,
                                    Depth = 3
                                }
                            },
                            SurfaceMounted = new SurfaceMounted(),
                            Pendant = new Pendant
                            {
                                PendantLength = 4
                            }
                        },
                        Wall = new Wall
                        {
                            MountingHeight = 5,
                            Recessed = new WallRecessed
                            {
                                RecessedDepth = 6,
                                Cutout = new RectangularCutout
                                {
                                    Width = 7,
                                    Length = 8,
                                    Depth = 9
                                }
                            },
                            SurfaceMounted = new WallSurfaceMounted()
                        },
                        WorkingPlane = new WorkingPlane
                        {
                            FreeStanding = new FreeStanding()
                        },
                        Ground = new Ground
                        {
                            PoleTop = new PoleTop
                            {
                                PoleHeight = 11
                            },
                            PoleIntegrated = new PoleIntegrated
                            {
                                PoleHeight = 12
                            },
                            FreeStanding = new FreeStanding(),
                            SurfaceMounted = new SurfaceMounted(),
                            Recessed = new Recessed
                            {
                                RecessedDepth = 13,
                                Cutout = new CircularCutout
                                {
                                    Diameter = 14,
                                    Depth = 15
                                }
                            }
                        }
                    },
                    Geometry = new GeometryReference
                    {
                        Reference = new EmitterReference
                        {
                            EmitterId = "leoEmitter"
                        }
                    },
                    Pictures = new[]
                    {
                        new Image
                        {
                            FileId = "pictureFile",
                            ImageType = ImageType.Other
                        },
                        new Image
                        {
                            FileId = "pictureFile",
                            ImageType = ImageType.TechnicalSketch
                        },
                        new Image
                        {
                            FileId = "pictureFile",
                            ImageType = ImageType.ApplicationPicture
                        },
                        new Image
                        {
                            FileId = "pictureFile",
                            ImageType = ImageType.ProductPicture
                        }
                    },
                    Symbol = new Symbol
                    {
                        FileId = "pictureFile"
                    }
                },
                new Variant
                {
                    Id = "variant-2",
                    Name = new[]
                    {
                        new Locale { Language = "en", Text = "Variant 2" }
                    },
                    Mountings = new Mountings
                    {
                        Ceiling = new Ceiling
                        {
                            Recessed = new Recessed
                            {
                                RecessedDepth = 16,
                                Cutout = new RectangularCutout
                                {
                                    Width = 17,
                                    Length = 18,
                                    Depth = 19
                                }
                            }
                        },
                        Wall = new Wall
                        {
                            MountingHeight = 21,
                            Recessed = new WallRecessed
                            {
                                RecessedDepth = 22,
                                Cutout = new CircularCutout
                                {
                                    Diameter = 23,
                                    Depth = 24
                                }
                            }
                        },
                        Ground = new Ground
                        {
                            Recessed = new Recessed
                            {
                                RecessedDepth = 25,
                                Cutout = new RectangularCutout
                                {
                                    Width = 26,
                                    Length = 27,
                                    Depth = 28
                                }
                            }
                        }
                    },
                    Geometry = new GeometryReference
                    {
                        Reference = new SimpleGeometryReference
                        {
                            GeometryId = "simpleGeometry",
                            EmitterId = "leoEmitter"
                        }
                    }
                },
                new Variant
                {
                    Id = "variant-3",
                    SortOrder = 3,
                    Name = new[]
                    {
                        new Locale { Language = "en", Text = "Variant 3" }
                    },
                    Geometry = new GeometryReference
                    {
                        Reference = new ModelGeometryReference
                        {
                            GeometryId = "geometry",
                            EmitterReferences = new[]
                            {
                                new GeometryEmitterReference
                                {
                                    EmitterId = "leoEmitter",
                                    EmitterObjectExternalName = "leo1"
                                },
                                new GeometryEmitterReference
                                {
                                    EmitterId = "leoEmitter",
                                    TargetModelType = TargetModelType.L3d,
                                    EmitterObjectExternalName = "leo1"
                                },
                                new GeometryEmitterReference
                                {
                                    EmitterId = "leoEmitter",
                                    TargetModelType = TargetModelType.M3d,
                                    EmitterObjectExternalName = "leo1"
                                },
                                new GeometryEmitterReference
                                {
                                    EmitterId = "leoEmitter",
                                    TargetModelType = TargetModelType.R3d,
                                    EmitterObjectExternalName = "leo1"
                                },
                                new GeometryEmitterReference
                                {
                                    EmitterId = "sensorEmitter",
                                    EmitterObjectExternalName = "sensor"
                                }
                            }
                        }
                    },
                    ProductSeries = new[]
                    {
                        new ProductSerie
                        {
                            Name = new[]
                            {
                                new Locale
                                {
                                    Language = "en",
                                    Text = "Variant name 1"
                                },
                                new Locale
                                {
                                    Language = "de",
                                    Text = "Variantenname 1"
                                }
                            },
                            Description = new[]
                            {
                                new Locale
                                {
                                    Language = "en",
                                    Text = "Variant description"
                                },
                                new Locale
                                {
                                    Language = "de",
                                    Text = "Variantenbeschreibung"
                                }
                            },
                            Pictures = new[]
                            {
                                new Image
                                {
                                    FileId = "pictureFile",
                                    ImageType = ImageType.TechnicalSketch
                                },
                                new Image
                                {
                                    FileId = "pictureFile",
                                    ImageType = ImageType.ApplicationPicture
                                },
                                new Image
                                {
                                    FileId = "pictureFile",
                                    ImageType = ImageType.ProductPicture
                                },
                                new Image
                                {
                                    FileId = "pictureFile",
                                    ImageType = ImageType.Other
                                }
                            },
                            Hyperlinks = new[]
                            {
                                new Hyperlink
                                {
                                    Href = "href1",
                                    PlainText = "Hyperlink 1"
                                },
                                new Hyperlink
                                {
                                    Href = "href2",
                                    Region = "region",
                                    Language = "en",
                                    CountryCode = "de",
                                    PlainText = "Hyperlink 2"
                                }
                            }
                        },
                        new ProductSerie
                        {
                            Name = new[]
                            {
                                new Locale
                                {
                                    Language = "en",
                                    Text = "Variant name 2"
                                },
                                new Locale
                                {
                                    Language = "de",
                                    Text = "Variantenname 2"
                                }
                            }
                        }
                    }
                },
                new Variant
                {
                    Id = "variant-4",
                    SortOrder = 4,
                    Name = new[]
                    {
                        new Locale { Language = "en", Text = "Variant 4" }
                    },
                    Geometry = new GeometryReference
                    {
                        Reference = new GeometryReferences
                        {
                            SimpleGeometryReference = new SimpleGeometryReference
                            {
                                GeometryId = "simpleGeometry",
                                EmitterId = "leoEmitter"
                            },
                            ModelGeometryReference = new ModelGeometryReference
                            {
                                GeometryId = "geometry",
                                EmitterReferences = new[]
                                {
                                    new GeometryEmitterReference
                                    {
                                        EmitterId = "leoEmitter",
                                        TargetModelType = TargetModelType.L3d,
                                        EmitterObjectExternalName = "Leo"
                                    }
                                }
                            }
                        }
                    }
                },
                new Variant
                {
                    Id = "variant-5",
                    SortOrder = 5,
                    Name = new[]
                    {
                        new Locale { Language = "en", Text = "Variant 5" }
                    },
                    Geometry = new GeometryReference
                    {
                        Reference = new GeometryReferences
                        {
                            SimpleGeometryReference = new SimpleGeometryReference
                            {
                                GeometryId = "simpleGeometry",
                                EmitterId = "leoEmitter"
                            },
                            ModelGeometryReference = new ModelGeometryReference
                            {
                                GeometryId = "geometry",
                                EmitterReferences = new[]
                                {
                                    new GeometryEmitterReference
                                    {
                                        EmitterId = "leoEmitter",
                                        EmitterObjectExternalName = "Leo"
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