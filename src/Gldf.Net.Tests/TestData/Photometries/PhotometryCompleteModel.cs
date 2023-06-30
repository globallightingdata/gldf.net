using Gldf.Net.Domain.Xml;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Domain.Xml.Global;
using Gldf.Net.Domain.Xml.Head;
using Gldf.Net.Domain.Xml.Head.Types;
using Gldf.Net.Domain.Xml.Product;
using Gldf.Net.Domain.Xml.Product.Types;
using System;

namespace Gldf.Net.Tests.TestData.Photometries;

public class PhotometryCompleteModel
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
                    Content = new PhotometryFileReference { FileId = "eulumdat" },
                    DescriptivePhotometry = new DescriptivePhotometry
                    {
                        LuminaireLuminance = 2,
                        LightOutputRatio = 0.01,
                        LuminousEfficacy = 90.5,
                        DownwardFluxFraction = 0.03,
                        DownwardLightOutputRatio = 0.04,
                        UpwardLightOutputRatio = 0.05,
                        TenthPeakDivergence = new TenthPeakDivergence
                        {
                            C0C180 = 11,
                            C90C270 = 12
                        },
                        HalfPeakDivergence = new HalfPeakDivergence
                        {
                            C0C180 = 13,
                            C90C270 = 14
                        },
                        PhotometricCode = "PhotometricCode",
                        CieFluxCode = "CIE-FluxCode",
                        CutOffAngle = 0.08,
                        Ugr4H8H = new Ugr4H8H
                        {
                            X = 0.09,
                            Y = 0.1
                        },
                        IesnaLightDistributionDefinition = "IESNA-LightDistributionDefinition",
                        LightDistributionBugRating = "LightDistributionBUG-Rating"
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
                        new ChangeableLightEmitter
                        {
                            PhotometryReference = new PhotometryReference
                            {
                                PhotometryId = "photometry"
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
                            EmitterId = "emitter"
                        }
                    }
                }
            }
        }
    };
}