using Gldf.Net.Domain.Xml;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Domain.Xml.Global;
using Gldf.Net.Domain.Xml.Head;
using Gldf.Net.Domain.Xml.Product;
using Gldf.Net.Domain.Xml.Product.Types;
using System;

namespace Gldf.Net.Tests.TestData.Equipments
{
    public class EquipmentCompleteModel
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
                LightSources = new LightSourceBase[]
                {
                    new ChangeableLightSource
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
                        RatedInputPower = 50,
                        RatedLuminousFlux = 250
                    }
                },
                ControlGears = new[]
                {
                    new ControlGear
                    {
                        Id = "controlGear",
                        Name = new[]
                        {
                            new Locale
                            {
                                Language = "en",
                                Text = "ControlGear name"
                            }
                        },
                        Description = new[]
                        {
                            new Locale
                            {
                                Language = "en",
                                Text = "ControlGear description"
                            }
                        }
                    }
                },
                Equipments = new[]
                {
                    new Equipment
                    {
                        Id = "equipment-1",
                        LightSourceReference = new LightSourceReference { ChangeableLightSourceId = "lightSource" },
                        ControlGearReference = new ControlGearReference
                        {
                            ControlGearCount = 2,
                            ControlGearId = "controlGear"
                        },
                        RatedInputPower = 0.1,
                        EmergencyModeOutput = new EmergencyBallastLumenFactor { Factor = 0.2 }
                    },
                    new Equipment
                    {
                        Id = "equipment-2",
                        LightSourceReference = new LightSourceReference { ChangeableLightSourceId = "lightSource" },
                        ControlGearReference = new ControlGearReference
                        {
                            ControlGearId = "controlGear"
                        },
                        RatedInputPower = 0.1,
                        EmergencyModeOutput = new EmergencyRatedLuminousFlux { Flux = 2 }
                    }
                },
                Emitters = new[]
                {
                    new Emitter
                    {
                        Id = "emitter-1",
                        PossibleFittings = new EmitterBase[]
                        {
                            new ChangeableLightEmitter
                            {
                                PhotometryReference = new PhotometryReference
                                {
                                    PhotometryId = "photometry"
                                },
                                EquipmentReference = new EquipmentReference
                                {
                                    EquipmentId = "equipment-1"
                                }
                            }
                        }
                    },
                    new Emitter
                    {
                        Id = "emitter-2",
                        PossibleFittings = new EmitterBase[]
                        {
                            new ChangeableLightEmitter
                            {
                                PhotometryReference = new PhotometryReference
                                {
                                    PhotometryId = "photometry"
                                },
                                EquipmentReference = new EquipmentReference
                                {
                                    EquipmentId = "equipment-2"
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
                        Geometry = new Geometry
                        {
                            Reference = new EmitterReference
                            {
                                EmitterId = "emitter-1"
                            }
                        }
                    }
                }
            }
        };
    }
}