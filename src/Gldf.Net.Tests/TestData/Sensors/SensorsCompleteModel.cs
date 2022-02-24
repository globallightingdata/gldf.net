using Gldf.Net.Domain;
using Gldf.Net.Domain.Definition;
using Gldf.Net.Domain.Definition.Types;
using Gldf.Net.Domain.Global;
using Gldf.Net.Domain.Head;
using Gldf.Net.Domain.Head.Types;
using Gldf.Net.Domain.Product;
using Gldf.Net.Domain.Product.Types;
using System;

namespace Gldf.Net.Tests.TestData.Sensors
{
    public class SensorsCompleteModel
    {
        public static Root Root => new()
        {
            Header = new Header
            {
                Manufacturer = "DIAL",
                CreationTimeCode = new DateTime(2021, 3, 29, 14, 30, 0, DateTimeKind.Utc),
                CreatedWithApplication = "Visual Studio Code",
                FormatVersion = FormatVersion.V09
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
                                SensorId = "sensor"
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