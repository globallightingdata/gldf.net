using FluentAssertions;
using Gldf.Net.Domain.Xml.Definition.Types;
using NUnit.Framework;

namespace Gldf.Net.Tests.DomainTests;

[TestFixture]
public class LightSourceMaintenanceTests
{
    [Test]
    public void GetAsCie97LampType_Should_Return_Expected()
    {
        var expectedType = new Cie97LampType();
        var lightSourceMaintenance = new LightSourceMaintenance { MaintenanceType = expectedType };
        var maintenanceType = lightSourceMaintenance.GetAsCie97LampType();
        maintenanceType.Should().Be(expectedType);
    }

    [Test]
    public void GetAsLampMaintenanceFactors_Should_Return_Expected()
    {
        var expectedType = new CieLampMaintenanceFactors();
        var lightSourceMaintenance = new LightSourceMaintenance { MaintenanceType = expectedType };
        var maintenanceType = lightSourceMaintenance.GetAsLampMaintenanceFactors();
        maintenanceType.Should().Be(expectedType);
    }

    [Test]
    public void GetAsLedMaintenanceFactor_Should_Return_Expected()
    {
        var expectedType = new LedMaintenanceFactor();
        var lightSourceMaintenance = new LightSourceMaintenance { MaintenanceType = expectedType };
        var maintenanceType = lightSourceMaintenance.GetAsLedMaintenanceFactor();
        maintenanceType.Should().Be(expectedType);
    }
}