using Gldf.Net.Domain;
using Gldf.Net.Domain.Definition;
using Gldf.Net.Domain.Definition.Types;
using Gldf.Net.Domain.Global;
using Gldf.Net.Domain.Head;
using Gldf.Net.Domain.Head.Types;
using Gldf.Net.Domain.Product;
using Gldf.Net.Domain.Product.Types;
using System;

namespace Gldf.Net.Tests.TestData.Head
{
    public class HeaderMandatoryModel
    {
        public static Root Root => new()
        {
            Header = new Header
            {
                Manufacturer = "Manufacturer",
                CreationTimeCode = new DateTime(2021, 3, 29, 14, 30, 0, DateTimeKind.Utc),
                CreatedWithApplication = "CreatedWithApplication",
                FormatVersion = FormatVersion.V100
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
}