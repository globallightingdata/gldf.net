using Gldf.Net.Domain;
using Gldf.Net.Domain.Definition;
using Gldf.Net.Domain.Definition.Types;
using Gldf.Net.Domain.Global;
using Gldf.Net.Domain.Head;
using Gldf.Net.Domain.Product;
using Gldf.Net.Domain.Product.Types;
using System;

namespace Gldf.Net.Tests.TestData.Photometries
{
    public class PhotometryCompleteModel
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
                        Content = new PhotometryFileReference {FileId = "eulumdat"},
                        RotationG0 = 1,
                        DescriptivePhotometry = new DescriptivePhotometry
                        {
                            LuminaireLuminance = 2,
                            LightOutputRatio = 0.01,
                            LuminousEfficacy = 0.02,
                            DownwardFluxFraction = 0.03,
                            DownwardLightOutputRatio = 0.04,
                            UpwardLightOutputRatio = 0.05,
                            TenthPeakDivergence = 0.06,
                            HalfPeakDivergence = 0.07,
                            PhotometricCode = "PhotometricCode",
                            CieFluxCode = "CIE-FluxCode",
                            CutOffAngle = 0.08,
                            Ugr4H8H = new Ugr4H8H
                            {
                                X = 0.09,
                                Y = 0.1
                            },
                            IesnaLightDistributionDefinition = "IESNA-LightDistributionDefinition",
                            LightDistributionBugRating = "LightDistributionBUG-Rating",
                            FlickerPstLm = "FlickerPstLM",
                            StroboscopicEffectsSvm = "StroboscopicEffectsSVM"
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