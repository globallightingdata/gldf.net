using FluentAssertions;
using Gldf.Net.Domain.Definition;
using Gldf.Net.Domain.Definition.Types;
using NUnit.Framework;

namespace Gldf.Net.Tests.DomainTests
{
    [TestFixture]
    public class EmitterTests
    {
        [Test]
        public void GetLightEmitters_Should_Return_Expected()
        {
            var possibleFittings = new EmitterBase[] { new LightEmitter(), new LightEmitter() };
            var emitter = new Emitter { PossibleFittings = possibleFittings };

            var lightEmitters = emitter.GetLightEmitters();

            lightEmitters.Should().BeEquivalentTo(possibleFittings);
        }

        [Test]
        public void GetSensorEmitters_Should_Return_Expected()
        {
            var possibleFittings = new EmitterBase[] { new SensorEmitter(), new SensorEmitter() };
            var emitter = new Emitter { PossibleFittings = possibleFittings };

            var sensorEmitters = emitter.GetSensorEmitters();

            sensorEmitters.Should().BeEquivalentTo(possibleFittings);
        }
    }
}