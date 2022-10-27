using FluentAssertions;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using NUnit.Framework;

namespace Gldf.Net.Tests.DomainTests
{
    [TestFixture]
    public class EquipmentTests
    {
        [Test]
        public void GetEmergencyModeOutputAsLumenFactor_Should_Return_Expected()
        {
            var expectedMode = new EmergencyBallastLumenFactor();
            var equipment = new Equipment {EmergencyModeOutput = expectedMode};

            var emergencyMode = equipment.GetEmergencyModeOutputAsLumenFactor();

            emergencyMode.Should().Be(expectedMode);
        }

        [Test]
        public void GetEmergencyModeOutputAsLuminousFlux_Should_Return_Expected()
        {
            var expectedMode = new EmergencyRatedLuminousFlux();
            var equipment = new Equipment {EmergencyModeOutput = expectedMode};

            var emergencyMode = equipment.GetEmergencyModeOutputAsLuminousFlux();

            emergencyMode.Should().Be(expectedMode);
        }
    }
}