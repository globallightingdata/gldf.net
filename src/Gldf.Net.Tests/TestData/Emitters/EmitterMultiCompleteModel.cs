using Gldf.Net.Domain.Xml;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Domain.Xml.Global;
using Gldf.Net.Domain.Xml.Head;
using Gldf.Net.Domain.Xml.Head.Types;
using Gldf.Net.Domain.Xml.Product;
using Gldf.Net.Domain.Xml.Product.Types;
using System;

namespace Gldf.Net.Tests.TestData.Emitters;

public static class EmitterMultiCompleteModel
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
                    Id = "photometryFile",
                    ContentType = FileContentType.LdcEulumdat,
                    Type = FileType.Url,
                    File = "https://example.org/photometry.ldt"
                }
            },
            Photometries = new[]
            {
                new Photometry
                {
                    Id = "photometry",
                    Content = new PhotometryFileReference
                    {
                        FileId = "photometryFile"
                    }
                }
            },
            Spectrums = new[]
            {
                new Spectrum
                {
                    Id = "spectrum",
                    Intensities = new[]
                    {
                        new SpectrumIntensity
                        {
                            Wavelength = 380,
                            Intensity = 0.8
                        }
                    }
                }
            },
            LightSources = new LightSourceBase[]
            {
                new MultiChannelLightSource
                {
                    Id = "multiChannelLightSource",
                    Name = new[]
                    {
                        new Locale
                        {
                            Language = "en",
                            Text = "RGB module"
                        }
                    },
                    RatedInputPower = 30,
                    Channels = new[]
                    {
                        new Channel
                        {
                            Type = ChannelType.NeutralWhite,
                            DisplayName = new Locale[]
                            {
                                new()
                                {
                                    Language = "en",
                                    Text = "Neutral-White"
                                }
                            },
                            SpectrumReference = new SpectrumReference
                            {
                                SpectrumId = "spectrum"
                            },
                            PhotometryReference = new PhotometryReference
                            {
                                PhotometryId = "photometry"
                            },
                            RatedLuminousFlux = 150
                        }
                    }
                }
            },
            ControlGears = new ControlGear[]
            {
                new()
                {
                    Id = "controlGear",
                    Name = new Locale[]
                    {
                        new()
                        {
                            Language = "en",
                            Text = "Electronic ballast"
                        }
                    }
                }
            },
            Emitters = new[]
            {
                new Emitter
                {
                    Id = "emitter-1",
                    PossibleFittings = new EmitterBase[]
                    {
                        new MultiChannelLightEmitter
                        {
                            EmergencyBehaviour = EmergencyBehaviour.EmergencyOnly,
                            Name = new Locale[]
                            {
                                new()
                                {
                                    Language = "en",
                                    Text = "Lightoutput RGB 1"
                                },
                                new()
                                {
                                    Language = "de",
                                    Text = "Lichtaustritt RGB 1"
                                }
                            },
                            Rotation = new Rotation
                            {
                                X = 1,
                                Y = 2,
                                Z = 3,
                                G0 = 4
                            },
                            LightSourceReference = new MultiChannelLightSourceReference
                            {
                                MultiChannelLightSourceId = "multiChannelLightSource"
                            },
                            ControlGearReference = new ControlGearReference
                            {
                                ControlGearId = "controlGear"
                            }
                        }
                    }
                },
                new Emitter
                {
                    Id = "emitter-2",
                    PossibleFittings = new EmitterBase[]
                    {
                        new MultiChannelLightEmitter
                        {
                            EmergencyBehaviour = EmergencyBehaviour.Combined,
                            LightSourceReference = new MultiChannelLightSourceReference
                            {
                                MultiChannelLightSourceId = "multiChannelLightSource"
                            },
                            ControlGearReference = new ControlGearReference
                            {
                                ControlGearId = "controlGear",
                                ControlGearCount = 2
                            }
                        }
                    }
                },
                new Emitter
                {
                    Id = "emitter-3",
                    PossibleFittings = new EmitterBase[]
                    {
                        new MultiChannelLightEmitter
                        {
                            EmergencyBehaviour = EmergencyBehaviour.None,
                            LightSourceReference = new MultiChannelLightSourceReference
                            {
                                MultiChannelLightSourceId = "multiChannelLightSource"
                            }
                        },
                        new MultiChannelLightEmitter
                        {
                            LightSourceReference = new MultiChannelLightSourceReference
                            {
                                MultiChannelLightSourceId = "multiChannelLightSource"
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
                            EmitterId = "emitter-1"
                        }
                    }
                }
            }
        }
    };
}