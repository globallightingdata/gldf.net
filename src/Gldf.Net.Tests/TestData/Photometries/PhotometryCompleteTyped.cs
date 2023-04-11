using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Typed.Global;
using Gldf.Net.Domain.Typed.Head;
using Gldf.Net.Domain.Typed.Head.Types;
using Gldf.Net.Domain.Xml.Definition.Types;
using System;
using System.Collections.Generic;

namespace Gldf.Net.Tests.TestData.Photometries;

public class PhotometryCompleteTyped
{
    public static RootTyped RootTyped => new()
    {
        Header = new HeaderTyped
        {
            Manufacturer = "DIAL",
            GldfCreationTimeCode = new DateTime(2021, 3, 29, 14, 30, 0, DateTimeKind.Utc),
            CreatedWithApplication = "Visual Studio Code",
            FormatVersion = new FormatVersionTyped { Major = 1, Minor = 0, PreRelease = 2 },
            UniqueGldfId = "3BE556FF-9061-4592-AEB1-1BC9D507280E"
        },
        GeneralDefinitions = new GeneralDefinitionsTyped
        {
            Files = new List<GldfFileTyped>
            {
                new()
                {
                    Id = "eulumdat",
                    ContentType = FileContentType.LdcEulumdat,
                    Type = FileType.Url,
                    FileName = "eulumdat.ldt",
                    Uri = "https://example.org/eulumdat.ldt"
                }
            },
            Photometries = new List<PhotometryTyped>
            {
                new()
                {
                    Id = "photometry",
                    PhotometryFile = new GldfFileTyped
                    {
                        Id = "eulumdat",
                        ContentType = FileContentType.LdcEulumdat,
                        Type = FileType.Url,
                        FileName = "eulumdat.ldt",
                        Uri = "https://example.org/eulumdat.ldt"
                    },
                    DescriptivePhotometry = new DescriptivePhotometryTyped
                    {
                        LuminaireLuminance = 2,
                        LightOutputRatio = 0.01,
                        LuminousEfficacy = 90.5,
                        DownwardFluxFraction = 0.03,
                        DownwardLightOutputRatio = 0.04,
                        UpwardLightOutputRatio = 0.05,
                        TenthPeakDivergence = new TenthPeakDivergenceTyped
                        {
                            C0C180 = 11,
                            C90C270 = 12
                        },
                        HalfPeakDivergence = new HalfPeakDivergenceTyped
                        {
                            C0C180 = 13,
                            C90C270 = 14
                        },
                        PhotometricCode = "PhotometricCode",
                        CieFluxCode = "CIE-FluxCode",
                        CutOffAngle = 0.08,
                        Ugr4H8H = new Ugr4H8HTyped
                        {
                            X = 0.09,
                            Y = 0.1
                        },
                        IesnaLightDistributionDefinition = "IESNA-LightDistributionDefinition",
                        LightDistributionBugRating = "LightDistributionBUG-Rating"
                    }
                }
            },
            Emitter = new List<EmitterTyped>
            {
                new()
                {
                    Id = "emitter",
                    ChangeableEmitterOptions = new[]
                    {
                        new ChangeableLightEmitterTyped
                        {
                            Photometry = new PhotometryTyped
                            {
                                Id = "photometry",
                                PhotometryFile = new GldfFileTyped
                                {
                                    Id = "eulumdat",
                                    ContentType = FileContentType.LdcEulumdat,
                                    Type = FileType.Url,
                                    FileName = "eulumdat.ldt",
                                    Uri = "https://example.org/eulumdat.ldt"
                                },
                                DescriptivePhotometry = new DescriptivePhotometryTyped
                                {
                                    LuminaireLuminance = 2,
                                    LightOutputRatio = 0.01,
                                    LuminousEfficacy = 90.5,
                                    DownwardFluxFraction = 0.03,
                                    DownwardLightOutputRatio = 0.04,
                                    UpwardLightOutputRatio = 0.05,
                                    TenthPeakDivergence = new TenthPeakDivergenceTyped
                                    {
                                        C0C180 = 11,
                                        C90C270 = 12
                                    },
                                    HalfPeakDivergence = new HalfPeakDivergenceTyped
                                    {
                                        C0C180 = 13,
                                        C90C270 = 14
                                    },
                                    PhotometricCode = "PhotometricCode",
                                    CieFluxCode = "CIE-FluxCode",
                                    CutOffAngle = 0.08,
                                    Ugr4H8H = new Ugr4H8HTyped
                                    {
                                        X = 0.09,
                                        Y = 0.1
                                    },
                                    IesnaLightDistributionDefinition = "IESNA-LightDistributionDefinition",
                                    LightDistributionBugRating = "LightDistributionBUG-Rating"
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
            Variants = new List<VariantTyped>
            {
                new()
                {
                    Id = "variant-1",
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
                            Text = "Variant 1"
                        }
                    },
                    Geometry = new GeometryTyped
                    {
                        EmitterOnly = new EmitterTyped
                        {
                            Id = "emitter",
                            ChangeableEmitterOptions = new[]
                            {
                                new ChangeableLightEmitterTyped
                                {
                                    Photometry = new PhotometryTyped
                                    {
                                        Id = "photometry",
                                        PhotometryFile = new GldfFileTyped
                                        {
                                            Id = "eulumdat",
                                            ContentType = FileContentType.LdcEulumdat,
                                            Type = FileType.Url,
                                            FileName = "eulumdat.ldt",
                                            Uri = "https://example.org/eulumdat.ldt"
                                        },
                                        DescriptivePhotometry = new DescriptivePhotometryTyped
                                        {
                                            LuminaireLuminance = 2,
                                            LightOutputRatio = 0.01,
                                            LuminousEfficacy = 90.5,
                                            DownwardFluxFraction = 0.03,
                                            DownwardLightOutputRatio = 0.04,
                                            UpwardLightOutputRatio = 0.05,
                                            TenthPeakDivergence = new TenthPeakDivergenceTyped
                                            {
                                                C0C180 = 11,
                                                C90C270 = 12
                                            },
                                            HalfPeakDivergence = new HalfPeakDivergenceTyped
                                            {
                                                C0C180 = 13,
                                                C90C270 = 14
                                            },
                                            PhotometricCode = "PhotometricCode",
                                            CieFluxCode = "CIE-FluxCode",
                                            CutOffAngle = 0.08,
                                            Ugr4H8H = new Ugr4H8HTyped
                                            {
                                                X = 0.09,
                                                Y = 0.1
                                            },
                                            IesnaLightDistributionDefinition = "IESNA-LightDistributionDefinition",
                                            LightDistributionBugRating = "LightDistributionBUG-Rating"
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