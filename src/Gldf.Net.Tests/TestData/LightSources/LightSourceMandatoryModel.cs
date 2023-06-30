using Gldf.Net.Domain.Xml;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Domain.Xml.Global;
using Gldf.Net.Domain.Xml.Head;
using Gldf.Net.Domain.Xml.Head.Types;
using Gldf.Net.Domain.Xml.Product;
using Gldf.Net.Domain.Xml.Product.Types;
using System;

namespace Gldf.Net.Tests.TestData.LightSources;

public static class LightSourceMandatoryModel
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
                new FixedLightSource
                {
                    Id = "lightSource-1",
                    Name = new[]
                    {
                        new Locale
                        {
                            Language = "en",
                            Text = "LightSource name"
                        }
                    },
                    RatedInputPower = 50
                },
                new ChangeableLightSource
                {
                    Id = "lightSource-2",
                    Name = new[]
                    {
                        new Locale
                        {
                            Language = "en",
                            Text = "LightSource name 2"
                        }
                    },
                    RatedInputPower = 60,
                    RatedLuminousFlux = 500,
                    ColorInformation = new ColorInformation()
                },
                new MultiChannelLightSource
                {
                    Id = "lightSource-3",
                    Name = new[]
                    {
                        new Locale
                        {
                            Language = "en",
                            Text = "LightSource name 3"
                        }
                    },
                    RatedInputPower = 30,
                    Channels = new[]
                    {
                        new Channel
                        {
                            Type = ChannelType.WarmWhite,
                            DisplayName = new[]
                            {
                                new Locale
                                {
                                    Language = "en",
                                    Text = "WarmWhite channel"
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
            Emitters = new[]
            {
                new Emitter
                {
                    Id = "emitter",
                    PossibleFittings = new EmitterBase[]
                    {
                        new FixedLightEmitter
                        {
                            PhotometryReference = new PhotometryReference
                            {
                                PhotometryId = "photometry"
                            },
                            LightSourceReference = new FixedLightSourceReference
                            {
                                FixedLightSourceId = "lightSource-1"
                            },
                            RatedLuminousFlux = 250
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
                            EmitterId = "emitter"
                        }
                    }
                }
            }
        }
    };
}