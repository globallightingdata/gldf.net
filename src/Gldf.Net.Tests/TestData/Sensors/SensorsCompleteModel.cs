﻿using Gldf.Net.Domain.Xml;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Domain.Xml.Global;
using Gldf.Net.Domain.Xml.Head;
using Gldf.Net.Domain.Xml.Head.Types;
using Gldf.Net.Domain.Xml.Product;
using Gldf.Net.Domain.Xml.Product.Types;
using System;

namespace Gldf.Net.Tests.TestData.Sensors;

public static class SensorsCompleteModel
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
                    Id = "sensorFile",
                    ContentType = FileContentType.SensorSensLdt,
                    Type = FileType.Url,
                    File = "https://example.org/sensor.sensldt"
                }
            },
            Sensors = new[]
            {
                new Sensor
                {
                    Id = "sensor",
                    SensorFileReference = new SensorFileReference
                    {
                        FileId = "sensorFile"
                    },
                    DetectorCharacteristics = new[]
                    {
                        DetectorCharacteristic.Round,
                        DetectorCharacteristic.Square,
                        DetectorCharacteristic.Other
                    },
                    DetectionMethods = new[]
                    {
                        DetectionMethod.PassiveInfrared,
                        DetectionMethod.HighFrequency,
                        DetectionMethod.Microwave,
                        DetectionMethod.Ultrasonic,
                        DetectionMethod.Camera,
                        DetectionMethod.Other
                    },
                    DetectorTypes = new[]
                    {
                        DetectorType.MotionDetector,
                        DetectorType.PresenceDetector,
                        DetectorType.DaylightDetector,
                        DetectorType.Other
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
                        new SensorEmitter
                        {
                            SensorReference = new SensorReference
                            {
                                SensorId = "sensor"
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