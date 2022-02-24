using Gldf.Net.Domain;
using Gldf.Net.Domain.Definition;
using Gldf.Net.Domain.Definition.Types;
using Gldf.Net.Domain.Global;
using Gldf.Net.Domain.Head;
using Gldf.Net.Domain.Product;
using Gldf.Net.Domain.Product.Types;
using System;

namespace Gldf.Net.Tests.TestData.Spectrums
{
    public class SpectrumCompleteModel
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
                    },
                    new GldfFile
                    {
                        Id = "spectrumFile",
                        ContentType = FileContentType.SpectrumText,
                        Type = FileType.Url,
                        File = "https://example.org/spectrum.txt"
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
                        Id = "spectrum-1",
                        FileReference = new SpectrumFileReference
                        {
                            FileId = "spectrumFile"
                        }
                    },
                    new Spectrum
                    {
                        Id = "spectrum-2",
                        Intensities = new[]
                        {
                            new SpectrumIntensity
                            {
                                Wavelength = 380,
                                Intensity = 0.1
                            },
                            new SpectrumIntensity
                            {
                                Wavelength = 385,
                                Intensity = 0.2
                            },
                            new SpectrumIntensity
                            {
                                Wavelength = 390,
                                Intensity = 0.3
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
                            new LightEmitter
                            {
                                PhotometryId = "photometry"
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
                            new Locale { Language = "en", Text = "Variant 1" }
                        },
                        Reference = new EmitterReference
                        {
                            EmitterId = "emitter"
                        }
                    }
                }
            }
        };
    }
}