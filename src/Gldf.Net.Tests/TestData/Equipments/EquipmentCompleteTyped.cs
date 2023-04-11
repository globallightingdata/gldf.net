using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Global;
using Gldf.Net.Domain.Typed.Head;
using Gldf.Net.Domain.Xml.Definition.Types;
using System;
using Gldf.Net.Domain.Typed.Definition.Types;

namespace Gldf.Net.Tests.TestData.Equipments;

public static class EquipmentCompleteTyped
{
    public static RootTyped RootTyped => new()
    {
        Header = new HeaderTyped
        {
            Manufacturer = "DIAL",
            CreationTimeCode = new DateTime(2021, 3, 29, 14, 30, 0, DateTimeKind.Utc),
            CreatedWithApplication = "Visual Studio Code"
        },
        GeneralDefinitions = new GeneralDefinitionsTyped
        {
            Files = new()
            {
                new GldfFileTyped
                {
                    Id = "eulumdat",
                    ContentType = FileContentType.LdcEulumdat,
                    Type = FileType.Url,
                    Uri = "https://example.org/eulumdat.ldt"
                }
            },
            Photometries = new()
            {
                new PhotometryTyped
                {
                    Id = "photometry",
                    PhotometryFile = new GldfFileTyped
                    {
                        Id = "eulumdat"
                    }
                }
            },
            ChangeableLightSources = new()
            {
                new ChangeableLightSourceTyped
                {
                    Id = "lightSource",
                    Name = new[]
                    {
                        new LocaleTyped
                        {
                            Language = "en",
                            Text = "LightSource name"
                        }
                    },
                    RatedInputPower = 50,
                    RatedLuminousFlux = 250
                }
            },
            ControlGears = new()
            {
                new ControlGearTyped
                {
                    Id = "controlGear",
                    Name = new[]
                    {
                        new LocaleTyped
                        {
                            Language = "en",
                            Text = "ControlGear name"
                        }
                    },
                    Description = new[]
                    {
                        new LocaleTyped
                        {
                            Language = "en",
                            Text = "ControlGear description"
                        }
                    }
                }
            },
            Equipments = new()
            {
                new EquipmentTyped
                {
                    Id = "equipment-1",
                    ChangeableLightSource = new()
                    {
                        Id = "lightSource"
                    },
                    ControlGear = new ControlGearTyped
                    {
                        Id = "controlGear"
                    },
                    ControlGearCount = 2,
                    RatedInputPower = 0.1,
                    EmergencyBallastLumenFactor = new EmergencyBallastLumenFactorTyped { Factor = 0.2 }
                },
                new EquipmentTyped
                {
                    Id = "equipment-2",
                    ChangeableLightSource = new ChangeableLightSourceTyped
                    {
                        Id = "lightSource"
                    },
                    ControlGear = new ControlGearTyped
                    {
                        Id = "controlGear"
                    },
                    RatedInputPower = 0.1,
                    EmergencyRatedLuminousFlux = new EmergencyRatedLuminousFluxTyped
                    {
                        Flux = 2
                    }
                }
            },
            Emitter = new()
            {
                new EmitterTyped
                {
                    Id = "emitter-1",
                    ChangeableEmitterOptions = new[]
                    {
                        new ChangeableLightEmitterTyped
                        {
                            Photometry = new PhotometryTyped
                            {
                                Id = "photometry"
                            },
                            Equipment = new EquipmentTyped
                            {
                                Id = "equipment-1"
                            }
                        }
                    }
                },
                new EmitterTyped
                {
                    Id = "emitter-2",
                    ChangeableEmitterOptions = new[]
                    {
                        new ChangeableLightEmitterTyped
                        {
                            Photometry = new PhotometryTyped
                            {
                                Id = "photometry"
                            },
                            Equipment = new EquipmentTyped
                            {
                                Id = "equipment-2"
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
            Variants = new()
            {
                new VariantTyped
                {
                    Id = "variant-1",
                    Name = new[]
                    {
                        new LocaleTyped { Language = "en", Text = "Variant 1" }
                    },
                    Geometry = new GeometryTyped
                    {
                        EmitterOnly = new EmitterTyped
                        {
                            Id = "emitter-1"
                        }
                    }
                }
            }
        }
    };
}