using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Typed.Global;
using Gldf.Net.Domain.Typed.Head;
using Gldf.Net.Domain.Typed.Head.Types;
using Gldf.Net.Domain.Typed.Product;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Domain.Xml.Product.Types;
using System;
using System.Collections.Generic;

namespace Gldf.Net.Tests.TestData.Emitters;

public static class EmitterMultiCompleteTyped
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
                    Id = "photometryFile",
                    ContentType = FileContentType.LdcEulumdat,
                    Type = FileType.Url,
                    FileName = "photometry.ldt",
                    Uri = "https://example.org/photometry.ldt"
                }
            },
            Photometries = new List<PhotometryTyped>
            {
                new()
                {
                    Id = "photometry",
                    PhotometryFile = new GldfFileTyped
                    {
                        Id = "photometryFile",
                        ContentType = FileContentType.LdcEulumdat,
                        Type = FileType.Url,
                        FileName = "photometry.ldt",
                        Uri = "https://example.org/photometry.ldt"
                    }
                }
            },
            Spectrums = new List<SpectrumTyped>
            {
                new()
                {
                    Id = "spectrum",
                    Intensities = new SpectrumIntensityTyped[]
                    {
                        new()
                        {
                            Wavelength = 380,
                            Intensity = 0.8
                        }
                    }
                }
            },
            MultiChannelLightSources = new List<MultiChannelLightSourceTyped>
            {
                new()
                {
                    Id = "multiChannelLightSource",
                    Name = new LocaleTyped[]
                    {
                        new()
                        {
                            Language = "en",
                            Text = "RGB module"
                        }
                    },
                    RatedInputPower = 30,
                    Channels = new ChannelTyped[]
                    {
                        new()
                        {
                            Type = ChannelType.NeutralWhite,
                            DisplayName = new LocaleTyped[]
                            {
                                new()
                                {
                                    Language = "en",
                                    Text = "Neutral-White"
                                }
                            },
                            Spectrum = new SpectrumTyped
                            {
                                Id = "spectrum",
                                Intensities = new SpectrumIntensityTyped[]
                                {
                                    new()
                                    {
                                        Wavelength = 380,
                                        Intensity = 0.8
                                    }
                                }
                            },
                            Photometry = new PhotometryTyped
                            {
                                Id = "photometry",
                                PhotometryFile = new GldfFileTyped
                                {
                                    Id = "photometryFile",
                                    ContentType = FileContentType.LdcEulumdat,
                                    Type = FileType.Url,
                                    FileName = "photometry.ldt",
                                    Uri = "https://example.org/photometry.ldt"
                                }
                            },
                            RatedLuminousFlux = 150
                        }
                    }
                }
            },
            ControlGears = new List<ControlGearTyped>
            {
                new()
                {
                    Id = "controlGear",
                    Name = new LocaleTyped[]
                    {
                        new()
                        {
                            Language = "en",
                            Text = "Electronic ballast"
                        }
                    }
                }
            },
            Emitter = new List<EmitterTyped>
            {
                new()
                {
                    Id = "emitter-1",
                    MultiChannelEmitterOptions = new[]
                    {
                        new MultiChannelLightEmitterTyped
                        {
                            EmergencyBehaviour = EmergencyBehaviour.EmergencyOnly,
                            Name = new LocaleTyped[]
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
                            Rotation = new RotationTyped
                            {
                                X = 1,
                                Y = 2,
                                Z = 3,
                                G0 = 4
                            },
                            MultiChannelLightSource = new MultiChannelLightSourceTyped
                            {
                                Id = "multiChannelLightSource",
                                Name = new LocaleTyped[]
                                {
                                    new()
                                    {
                                        Language = "en",
                                        Text = "RGB module"
                                    }
                                },
                                RatedInputPower = 30,
                                Channels = new ChannelTyped[]
                                {
                                    new()
                                    {
                                        Type = ChannelType.NeutralWhite,
                                        DisplayName = new LocaleTyped[]
                                        {
                                            new()
                                            {
                                                Language = "en",
                                                Text = "Neutral-White"
                                            }
                                        },
                                        Spectrum = new SpectrumTyped
                                        {
                                            Id = "spectrum",
                                            Intensities = new SpectrumIntensityTyped[]
                                            {
                                                new()
                                                {
                                                    Wavelength = 380,
                                                    Intensity = 0.8
                                                }
                                            }
                                        },
                                        Photometry = new PhotometryTyped
                                        {
                                            Id = "photometry",
                                            PhotometryFile = new GldfFileTyped
                                            {
                                                Id = "photometryFile",
                                                ContentType = FileContentType.LdcEulumdat,
                                                Type = FileType.Url,
                                                FileName = "photometry.ldt",
                                                Uri = "https://example.org/photometry.ldt"
                                            }
                                        },
                                        RatedLuminousFlux = 150
                                    }
                                }
                            },
                            ControlGear = new ControlGearTyped
                            {
                                Id = "controlGear",
                                Name = new LocaleTyped[]
                                {
                                    new()
                                    {
                                        Language = "en",
                                        Text = "Electronic ballast"
                                    }
                                }
                            }
                        }
                    }
                },
                new()
                {
                    Id = "emitter-2",
                    MultiChannelEmitterOptions = new[]
                    {
                        new MultiChannelLightEmitterTyped
                        {
                            EmergencyBehaviour = EmergencyBehaviour.Combined,
                            MultiChannelLightSource = new MultiChannelLightSourceTyped
                            {
                                Id = "multiChannelLightSource",
                                Name = new LocaleTyped[]
                                {
                                    new()
                                    {
                                        Language = "en",
                                        Text = "RGB module"
                                    }
                                },
                                RatedInputPower = 30,
                                Channels = new ChannelTyped[]
                                {
                                    new()
                                    {
                                        Type = ChannelType.NeutralWhite,
                                        DisplayName = new LocaleTyped[]
                                        {
                                            new()
                                            {
                                                Language = "en",
                                                Text = "Neutral-White"
                                            }
                                        },
                                        Spectrum = new SpectrumTyped
                                        {
                                            Id = "spectrum",
                                            Intensities = new SpectrumIntensityTyped[]
                                            {
                                                new()
                                                {
                                                    Wavelength = 380,
                                                    Intensity = 0.8
                                                }
                                            }
                                        },
                                        Photometry = new PhotometryTyped
                                        {
                                            Id = "photometry",
                                            PhotometryFile = new GldfFileTyped
                                            {
                                                Id = "photometryFile",
                                                ContentType = FileContentType.LdcEulumdat,
                                                Type = FileType.Url,
                                                FileName = "photometry.ldt",
                                                Uri = "https://example.org/photometry.ldt"
                                            }
                                        },
                                        RatedLuminousFlux = 150
                                    }
                                }
                            },
                            ControlGear = new ControlGearTyped
                            {
                                Id = "controlGear",
                                Name = new LocaleTyped[]
                                {
                                    new()
                                    {
                                        Language = "en",
                                        Text = "Electronic ballast"
                                    }
                                }
                            },
                            ControlGearCount = 2
                        }
                    }
                },
                new()
                {
                    Id = "emitter-3",
                    MultiChannelEmitterOptions = new[]
                    {
                        new MultiChannelLightEmitterTyped
                        {
                            EmergencyBehaviour = EmergencyBehaviour.None,
                            MultiChannelLightSource = new MultiChannelLightSourceTyped
                            {
                                Id = "multiChannelLightSource",
                                Name = new LocaleTyped[]
                                {
                                    new()
                                    {
                                        Language = "en",
                                        Text = "RGB module"
                                    }
                                },
                                RatedInputPower = 30,
                                Channels = new ChannelTyped[]
                                {
                                    new()
                                    {
                                        Type = ChannelType.NeutralWhite,
                                        DisplayName = new LocaleTyped[]
                                        {
                                            new()
                                            {
                                                Language = "en",
                                                Text = "Neutral-White"
                                            }
                                        },
                                        Spectrum = new SpectrumTyped
                                        {
                                            Id = "spectrum",
                                            Intensities = new SpectrumIntensityTyped[]
                                            {
                                                new()
                                                {
                                                    Wavelength = 380,
                                                    Intensity = 0.8
                                                }
                                            }
                                        },
                                        Photometry = new PhotometryTyped
                                        {
                                            Id = "photometry",
                                            PhotometryFile = new GldfFileTyped
                                            {
                                                Id = "photometryFile",
                                                ContentType = FileContentType.LdcEulumdat,
                                                Type = FileType.Url,
                                                FileName = "photometry.ldt",
                                                Uri = "https://example.org/photometry.ldt"
                                            }
                                        },
                                        RatedLuminousFlux = 150
                                    }
                                }
                            }
                        },
                        new MultiChannelLightEmitterTyped
                        {
                            MultiChannelLightSource = new MultiChannelLightSourceTyped
                            {
                                Id = "multiChannelLightSource",
                                Name = new LocaleTyped[]
                                {
                                    new()
                                    {
                                        Language = "en",
                                        Text = "RGB module"
                                    }
                                },
                                RatedInputPower = 30,
                                Channels = new ChannelTyped[]
                                {
                                    new()
                                    {
                                        Type = ChannelType.NeutralWhite,
                                        DisplayName = new LocaleTyped[]
                                        {
                                            new()
                                            {
                                                Language = "en",
                                                Text = "Neutral-White"
                                            }
                                        },
                                        Spectrum = new SpectrumTyped
                                        {
                                            Id = "spectrum",
                                            Intensities = new SpectrumIntensityTyped[]
                                            {
                                                new()
                                                {
                                                    Wavelength = 380,
                                                    Intensity = 0.8
                                                }
                                            }
                                        },
                                        Photometry = new PhotometryTyped
                                        {
                                            Id = "photometry",
                                            PhotometryFile = new GldfFileTyped
                                            {
                                                Id = "photometryFile",
                                                ContentType = FileContentType.LdcEulumdat,
                                                Type = FileType.Url,
                                                FileName = "photometry.ldt",
                                                Uri = "https://example.org/photometry.ldt"
                                            }
                                        },
                                        RatedLuminousFlux = 150
                                    }
                                }
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
                UniqueProductId = "Product 1",
                ProductNumber = new LocaleTyped[]
                {
                    new()
                    {
                        Language = "en",
                        Text = "Product number"
                    }
                },
                Name = new LocaleTyped[]
                {
                    new()
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
                    Name = new LocaleTyped[]
                    {
                        new() { Language = "en", Text = "Variant 1" }
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
                        EmitterOnly = new EmitterTyped
                        {
                            Id = "emitter-1",
                            MultiChannelEmitterOptions = new[]
                            {
                                new MultiChannelLightEmitterTyped
                                {
                                    EmergencyBehaviour = EmergencyBehaviour.EmergencyOnly,
                                    Name = new LocaleTyped[]
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
                                    Rotation = new RotationTyped
                                    {
                                        X = 1,
                                        Y = 2,
                                        Z = 3,
                                        G0 = 4
                                    },
                                    MultiChannelLightSource = new MultiChannelLightSourceTyped
                                    {
                                        Id = "multiChannelLightSource",
                                        Name = new LocaleTyped[]
                                        {
                                            new()
                                            {
                                                Language = "en",
                                                Text = "RGB module"
                                            }
                                        },
                                        RatedInputPower = 30,
                                        Channels = new ChannelTyped[]
                                        {
                                            new()
                                            {
                                                Type = ChannelType.NeutralWhite,
                                                DisplayName = new LocaleTyped[]
                                                {
                                                    new()
                                                    {
                                                        Language = "en",
                                                        Text = "Neutral-White"
                                                    }
                                                },
                                                Spectrum = new SpectrumTyped
                                                {
                                                    Id = "spectrum",
                                                    Intensities = new SpectrumIntensityTyped[]
                                                    {
                                                        new()
                                                        {
                                                            Wavelength = 380,
                                                            Intensity = 0.8
                                                        }
                                                    }
                                                },
                                                Photometry = new PhotometryTyped
                                                {
                                                    Id = "photometry",
                                                    PhotometryFile = new GldfFileTyped
                                                    {
                                                        Id = "photometryFile",
                                                        ContentType = FileContentType.LdcEulumdat,
                                                        Type = FileType.Url,
                                                        FileName = "photometry.ldt",
                                                        Uri = "https://example.org/photometry.ldt"
                                                    }
                                                },
                                                RatedLuminousFlux = 150
                                            }
                                        }
                                    },
                                    ControlGear = new ControlGearTyped
                                    {
                                        Id = "controlGear",
                                        Name = new LocaleTyped[]
                                        {
                                            new()
                                            {
                                                Language = "en",
                                                Text = "Electronic ballast"
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