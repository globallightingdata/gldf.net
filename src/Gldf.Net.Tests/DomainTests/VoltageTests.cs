using FluentAssertions;
using Gldf.Net.Domain.Global;
using NUnit.Framework;

namespace Gldf.Net.Tests.DomainTests
{
    [TestFixture]
    public class VoltageTests
    {
        [Test]
        public void GetAsFixedVoltage_Should_Return_Expected()
        {
            var expectedValue = new FixedVoltage();
            var voltage = new Voltage {Value = expectedValue};

            var voltageValue = voltage.GetAsFixedVoltage();

            voltageValue.Should().BeEquivalentTo(expectedValue);
        }

        [Test]
        public void GetAsVoltageRange_Should_Return_Expected()
        {
            var expectedValue = new VoltageRange();
            var voltage = new Voltage {Value = expectedValue};

            var voltageValue = voltage.GetAsVoltageRange();

            voltageValue.Should().BeEquivalentTo(expectedValue);
        }
    }
}