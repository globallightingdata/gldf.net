﻿using Gldf.Net.Domain;
using Gldf.Net.Domain.Definition;
using Gldf.Net.Domain.Definition.Types;
using Gldf.Net.Domain.Global;
using Gldf.Net.Domain.Head;
using Gldf.Net.Domain.Product;
using Gldf.Net.Domain.Product.Types;
using System;

namespace Gldf.Net.Tests.TestData.Geometries
{
    public class GeometryCompleteModel
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
                        Id = "geometryFile",
                        ContentType = FileContentType.GeoL3d,
                        Type = FileType.Url,
                        File = "https://example.org/geometry.l3d"
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
                            new LightEmitter
                            {
                                PhotometryId = "photometry"
                            }
                        }
                    }
                },
                Geometries = new Geometry[]
                {
                    new SimpleGeometry
                    {
                        Id = "geometry1",
                        SimpleGeometryType = new SimpleCuboidGeometry
                        {
                            Width = 1,
                            Length = 2,
                            Height = 3
                        },
                        SimpleGeometryEmitterType = new SimpleRectangularEmitter
                        {
                            Width = 4,
                            Length = 5
                        }
                    },
                    new SimpleGeometry
                    {
                        Id = "geometry2",
                        SimpleGeometryType = new SimpleCylinderGeometry
                        {
                            Plane = SimpleCylinderPlane.X,
                            Diameter = 1,
                            Height = 2
                        },
                        SimpleGeometryEmitterType = new SimpleCircularEmitter
                        {
                            Diameter = 3
                        }
                    },
                    new SimpleGeometry
                    {
                        Id = "geometry3",
                        SimpleGeometryType = new SimpleCylinderGeometry
                        {
                            Plane = SimpleCylinderPlane.Y,
                            Diameter = 1,
                            Height = 2
                        },
                        SimpleGeometryEmitterType = new SimpleRectangularEmitter
                        {
                            Width = 3,
                            Length = 4
                        }
                    },
                    new SimpleGeometry
                    {
                        Id = "geometry4",
                        SimpleGeometryType = new SimpleCylinderGeometry
                        {
                            Plane = SimpleCylinderPlane.Z,
                            Diameter = 1,
                            Height = 2
                        },
                        SimpleGeometryEmitterType = new SimpleCircularEmitter
                        {
                            Diameter = 3
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
                        EmitterReference = new EmitterReference
                        {
                            EmitterId = "emitter"
                        }
                    }
                }
            }
        };
    }
}