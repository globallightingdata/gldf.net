﻿using Gldf.Net.Domain.Xml;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Domain.Xml.Global;
using Gldf.Net.Domain.Xml.Head;
using Gldf.Net.Domain.Xml.Head.Types;
using Gldf.Net.Domain.Xml.Product;
using Gldf.Net.Domain.Xml.Product.Types;
using System;

namespace Gldf.Net.Tests.TestData.Emitters;

public static class EmitterMandatoryModel
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
                },
                new GldfFile
                {
                    Id = "sensorXml",
                    ContentType = FileContentType.SensorSensXml,
                    Type = FileType.Url,
                    File = "https://example.org/sens.xml"
                }
            },
            Sensors = new[]
            {
                new Sensor
                {
                    Id = "sensor",
                    SensorFileReference = new SensorFileReference
                    {
                        FileId = "sensorXml"
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
                    Id = "fixedLightSource",
                    Name = new[]
                    {
                        new Locale
                        {
                            Language = "en",
                            Text = "FixedLightSource"
                        }
                    },
                    RatedInputPower = 10
                },
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
                    RatedInputPower = 10,
                    Channels = new[]
                    {
                        new Channel
                        {
                            Type = ChannelType.Red,
                            DisplayName = new[]
                            {
                                new Locale
                                {
                                    Language = "en",
                                    Text = "Red channel"
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
                            RatedLuminousFlux = 80
                        }
                    },
                    Maintenance = null,
                    EmergencyBallastLumenFactor = null
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
                            }
                        }
                    }
                },
                new Emitter
                {
                    Id = "emitter-2",
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
                                FixedLightSourceId = "fixedLightSource"
                            },
                            RatedLuminousFlux = 50
                        }
                    }
                },
                new Emitter
                {
                    Id = "emitter-3",
                    PossibleFittings = new EmitterBase[]
                    {
                        new SensorEmitter
                        {
                            SensorReference = new SensorReference
                            {
                                SensorId = "sensor"
                            }
                        }
                    }
                },
                new Emitter
                {
                    Id = "emitter-4",
                    PossibleFittings = new EmitterBase[]
                    {
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