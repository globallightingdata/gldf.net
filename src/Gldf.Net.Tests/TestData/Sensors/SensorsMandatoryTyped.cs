using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Typed.Global;
using Gldf.Net.Domain.Typed.Head;
using Gldf.Net.Domain.Typed.Head.Types;
using Gldf.Net.Domain.Xml.Definition.Types;
using System;
using System.Collections.Generic;

namespace Gldf.Net.Tests.TestData.Sensors;

public class SensorsMandatoryTyped
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
                    Id = "sensorFile",
                    ContentType = FileContentType.SensorSensLdt,
                    Type = FileType.Url,
                    FileName = "sensor.sensldt",
                    Uri = "https://example.org/sensor.sensldt"
                }
            },
            Sensors = new List<SensorTyped>
            {
                new()
                {
                    Id = "sensor",
                    SensorFile = new GldfFileTyped
                    {
                        Id = "sensorFile",
                        ContentType = FileContentType.SensorSensLdt,
                        Type = FileType.Url,
                        FileName = "sensor.sensldt",
                        Uri = "https://example.org/sensor.sensldt"
                    }
                }
            },
            Emitter = new List<EmitterTyped>
            {
                new()
                {
                    Id = "emitter",
                    SensorEmitterOptions = new[]
                    {
                        new SensorEmitterTyped
                        {
                            Sensor = new SensorTyped
                            {
                                Id = "sensor",
                                SensorFile = new GldfFileTyped
                                {
                                    Id = "sensorFile",
                                    ContentType = FileContentType.SensorSensLdt,
                                    Type = FileType.Url,
                                    FileName = "sensor.sensldt",
                                    Uri = "https://example.org/sensor.sensldt"
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
                            SensorEmitterOptions = new[]
                            {
                                new SensorEmitterTyped
                                {
                                    Sensor = new SensorTyped
                                    {
                                        Id = "sensor",
                                        SensorFile = new GldfFileTyped
                                        {
                                            Id = "sensorFile",
                                            ContentType = FileContentType.SensorSensLdt,
                                            Type = FileType.Url,
                                            FileName = "sensor.sensldt",
                                            Uri = "https://example.org/sensor.sensldt"
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