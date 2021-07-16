using FluentAssertions;
using Gldf.Net.Domain.Definition.Types;
using NUnit.Framework;

namespace Gldf.Net.Tests.DomainTests
{
    [TestFixture]
    public class ControlGearReferenceTests
    {
        [Test]
        public void ControlGearCountSpecified_SetTrue_Should_SetCount_To_1()
        {
            var controlGearReference = new ControlGearReference
            {
                ControlGearCount = 0,
                ControlGearCountSpecified = true
            };

            controlGearReference.ControlGearCount.Should().Be(1);
        }

        [TestCase(0, false)]
        [TestCase(1, true)]
        [TestCase(2, true)]
        public void ControlGearCount_Set_Should_SetSpecified_AsExpected(int count, bool expected)
        {
            var controlGearReference = new ControlGearReference
            {
                ControlGearCount = count
            };

            controlGearReference.ControlGearCountSpecified.Should().Be(expected);
        }
    }
}