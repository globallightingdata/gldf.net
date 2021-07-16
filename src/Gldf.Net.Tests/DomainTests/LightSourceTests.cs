using FluentAssertions;
using Gldf.Net.Domain.Definition;
using Gldf.Net.Domain.Definition.Types;
using NUnit.Framework;

namespace Gldf.Net.Tests.DomainTests
{
    [TestFixture]
    public class LightSourceTests
    {
        [Test]
        public void GetAsChangeableLightSource_Should_Return_Expected()
        {
            var expectedChangeable = new ChangeableLightSource();
            var lightSource = new LightSource {LightSourceType = expectedChangeable};

            var changeable = lightSource.GetAsChangeableLightSource();

            changeable.Should().Be(expectedChangeable);
        }

        [Test]
        public void GetAsFixedLightSource_Should_Return_Expected()
        {
            var expectedFixed = new FixedLightSource();
            var lightSource = new LightSource {LightSourceType = expectedFixed};

            var fixedLightSource = lightSource.GetAsFixedLightSource();

            fixedLightSource.Should().Be(expectedFixed);
        }
    }
}