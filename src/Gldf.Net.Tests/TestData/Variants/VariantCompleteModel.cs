using Gldf.Net.Domain;
using Gldf.Net.Domain.Definition;
using Gldf.Net.Domain.Definition.Types;
using Gldf.Net.Domain.Descriptive;
using Gldf.Net.Domain.Descriptive.Types;
using Gldf.Net.Domain.Global;
using Gldf.Net.Domain.Head;
using Gldf.Net.Domain.Product;
using Gldf.Net.Domain.Product.Types;
using Gldf.Net.Domain.Product.Types.Mounting;
using System;

namespace Gldf.Net.Tests.TestData.Variants
{
    public class VariantCompleteModel
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
                LightSources = new[]
                {
                    new LightSource
                    {
                        Id = "lightSource",
                        Name = new[]
                        {
                            new Locale
                            {
                                Language = "en",
                                Text = "LightSource name"
                            }
                        },
                        LightSourceType = new FixedLightSource()
                    }
                },
                Equipments = new[]
                {
                    new Equipment
                    {
                        Id = "equipment",
                        LightSourceReference = new LightSourceReference
                        {
                            LightSourceId = "lightSource",
                            LightSourceCount = 2
                        },
                        RatedInputPower = 1,
                        RatedLuminousFlux = 2
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
                    },
                    new Emitter
                    {
                        Id = "leoEmitter",
                        PossibleFittings = new EmitterBase[]
                        {
                            new LightEmitter
                            {
                                PhotometryId = "photometry",
                                EquipmentId = "equipment",
                                Name = new[]
                                {
                                    new Locale
                                    {
                                        Language = "en",
                                        Text = "Display name"
                                    },
                                    new Locale
                                    {
                                        Language = "de",
                                        Text = "Anzeigename"
                                    }
                                }
                            },
                            new LightEmitter
                            {
                                PhotometryId = "photometry",
                                EmergencyBehaviour = EmergencyBehaviour.None
                            },
                            new LightEmitter
                            {
                                PhotometryId = "photometry",
                                EquipmentId = "equipment",
                                EmergencyBehaviour = EmergencyBehaviour.EmergencyOnly
                            },
                            new LightEmitter
                            {
                                PhotometryId = "photometry",
                                EquipmentId = "equipment",
                                EmergencyBehaviour = EmergencyBehaviour.Combined
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
                                SensorId = "sensor",
                                Name = new[]
                                {
                                    new Locale
                                    {
                                        Language = "en",
                                        Text = "Display name"
                                    },
                                    new Locale
                                    {
                                        Language = "de",
                                        Text = "Anzeigename"
                                    }
                                }
                            }
                        }
                    }
                },
                Geometries = new Geometry[]
                {
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
                        ProductNumber = "ProductNumber",
                        Mountings = new Mountings
                        {
                            Ceiling = new Ceiling
                            {
                                Recessed = new Recessed
                                {
                                    RecessedDepth = 0.1,
                                    Cutout = new CircularCutout
                                    {
                                        Diameter = 0.2,
                                        Depth = 0.3
                                    }
                                },
                                SurfaceMounted = new SurfaceMounted(),
                                Pendant = new Pendant
                                {
                                    PendantLength = 0.4
                                }
                            },
                            Wall = new Wall
                            {
                                MountingHeight = 0.5,
                                Recessed = new WallRecessed
                                {
                                    RecessedDepth = 0.6,
                                    Cutout = new RectangularCutout
                                    {
                                        Width = 0.7,
                                        Length = 0.8,
                                        Depth = 0.9
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
                                    PoleHeight = 0.11
                                },
                                PoleIntegrated = new PoleIntegrated
                                {
                                    PoleHeight = 0.12
                                },
                                FreeStanding = new FreeStanding(),
                                SurfaceMounted = new SurfaceMounted(),
                                Recessed = new Recessed
                                {
                                    RecessedDepth = 0.13,
                                    Cutout = new CircularCutout
                                    {
                                        Diameter = 0.14,
                                        Depth = 0.15
                                    }
                                }
                            }
                        },
                        Reference = new EmitterReference
                        {
                            EmitterId = "emitter"
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
                                    RecessedDepth = 0.16,
                                    Cutout = new RectangularCutout
                                    {
                                        Width = 0.17,
                                        Length = 0.18,
                                        Depth = 0.19
                                    }
                                }
                            },
                            Wall = new Wall
                            {
                                MountingHeight = 0.21,
                                Recessed = new WallRecessed
                                {
                                    RecessedDepth = 0.22,
                                    Cutout = new CircularCutout
                                    {
                                        Diameter = 0.23,
                                        Depth = 0.24
                                    }
                                }
                            },
                            Ground = new Ground
                            {
                                Recessed = new Recessed
                                {
                                    RecessedDepth = 0.25,
                                    Cutout = new RectangularCutout
                                    {
                                        Width = 0.26,
                                        Length = 0.27,
                                        Depth = 0.28
                                    }
                                }
                            }
                        },
                        Reference = new EmitterReference
                        {
                            EmitterId = "emitter"
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
                        Reference = new ModelGeometryReference
                        {
                            GeometryId = "geometry",
                            EmitterReferences = new[]
                            {
                                new GeometryEmitterReference
                                {
                                    EmitterId = "leoEmitter",
                                    EmitterObjectExternalName = "leo1"
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
                        Reference = new ModelGeometryReference
                        {
                            GeometryId = "geometry",
                            EmitterReferences = new[]
                            {
                                new GeometryEmitterReference
                                {
                                    EmitterId = "sensorEmitter",
                                    EmitterObjectExternalName = "sensor1",
                                    TargetModelType = TargetModelType.L3d
                                },
                                new GeometryEmitterReference
                                {
                                    EmitterId = "sensorEmitter",
                                    EmitterObjectExternalName = "sensor1",
                                    TargetModelType = TargetModelType.M3d
                                },
                                new GeometryEmitterReference
                                {
                                    EmitterId = "sensorEmitter",
                                    EmitterObjectExternalName = "sensor1",
                                    TargetModelType = TargetModelType.R3d
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
                        },
                        DescriptiveAttributes = new DescriptiveAttributes
                        {
                            Electrical = new Electrical
                            {
                                IKRating = IKRating.IK05
                            }
                        }
                    }
                }
            }
        };
    }
}