using FluentAssertions;
using Gldf.Net.Domain.Product.Types;
using NUnit.Framework;

namespace Gldf.Net.Tests.DomainTests
{
    [TestFixture]
    public class EmitterReferencesTest
    {
        [Test]
        public void GetAsSensorReference_Should_Return_Expected()
        {
            var expectedReference = new SensorReference();
            var equipment = new EmitterReferences {Reference = expectedReference};

            var reference = equipment.GetAsSensorReference();

            reference.Should().Be(expectedReference);
        }

        [Test]
        public void GetAsLightEmitterReference_Should_Return_Expected()
        {
            var expectedReference = new LightEmitterReference();
            var equipment = new EmitterReferences {Reference = expectedReference};

            var reference = equipment.GetAsLightEmitterReference();

            reference.Should().Be(expectedReference);
        }

        [Test]
        public void GetAsGeometryReference_Should_Return_Expected()
        {
            var expectedReference = new GeometryReference();
            var equipment = new EmitterReferences {Reference = expectedReference};

            var reference = equipment.GetAsGeometryReference();

            reference.Should().Be(expectedReference);
        }
    }
}