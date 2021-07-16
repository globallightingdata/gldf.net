using FluentAssertions;
using Gldf.Net.Domain.Definition.Types;
using NUnit.Framework;

namespace Gldf.Net.Tests.DomainTests
{
    [TestFixture]
    public class LightSourceMaintenanceTests
    {
        [Test]
        public void GetAsCie97LampType_Should_Return_Expected()
        {
            var expectedType = new Cie97LampType();
            var equipment = new LightSourceMaintenance {Content = expectedType};

            var maintenanceType = equipment.GetAsCie97LampType();

            maintenanceType.Should().Be(expectedType);
        }

        [Test]
        public void GetAsLampMaintenanceFactors_Should_Return_Expected()
        {
            var expectedType = new CieLampMaintenanceFactors();
            var equipment = new LightSourceMaintenance {Content = expectedType};

            var maintenanceType = equipment.GetAsLampMaintenanceFactors();

            maintenanceType.Should().Be(expectedType);
        }

        [Test]
        public void GetAsLedMaintenanceFactor_Should_Return_Expected()
        {
            var expectedType = new LedMaintenanceFactor();
            var equipment = new LightSourceMaintenance {Content = expectedType};

            var maintenanceType = equipment.GetAsLedMaintenanceFactor();

            maintenanceType.Should().Be(expectedType);
        }
    }
}