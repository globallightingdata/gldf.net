using Gldf.Net.Domain;
using Gldf.Net.Domain.Definition;
using Gldf.Net.Domain.Definition.Types;
using Gldf.Net.Domain.Global;
using Gldf.Net.Domain.Head;
using Gldf.Net.Domain.Product;
using Gldf.Net.Domain.Product.Types;
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
                CreationTimeCode = new DateTime(2021, 3, 29, 16, 30, 0).ToUniversalTime(),
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
                LightSources = new[]
                {
                    new LightSource
                    {
                        Id = "lightSource",
                        LightSourceType = new FixedLightSource()
                    }
                },
                ControlGears = new[]
                {
                    new ControlGear
                    {
                        Id = "controlGear",
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
                        LightSourceReference = new LightSourceReference {LightSourceId = "lightSource"},
                        ControlGearReference = new ControlGearReference
                        {
                            ControlGearCount = 2,
                            ControlGearId = "controlGear"
                        },
                        RatedInputPower = 0.1,
                        RatedLuminousFlux = 1,
                        EmergencyModeOutput = new EmergencyBallastLumenFactor {Factor = 0.2}
                    },
                    new Equipment
                    {
                        Id = "equipment-2",
                        LightSourceReference = new LightSourceReference {LightSourceId = "lightSource"},
                        ControlGearReference = new ControlGearReference
                        {
                            ControlGearId = "controlGear"
                        },
                        RatedInputPower = 0.1,
                        RatedLuminousFlux = 1,
                        EmergencyModeOutput = new EmergencyRatedLuminousFlux {Flux = 2}
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
                    ProductName = new[]
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
                        EmitterReferences = new EmitterReferences
                        {
                            Reference = new LightEmitterReference
                            {
                                PhotometryId = "photometry"
                            }
                        }
                    }
                }
            }
        };
    }
}