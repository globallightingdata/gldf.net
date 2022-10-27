using FluentAssertions;
using Gldf.Net.Domain.Xml.Definition.Types;
using NUnit.Framework;

namespace Gldf.Net.Tests.DomainTests
{
    [TestFixture]
    public class LightSourceReferenceCountTests
    {
        [Test]
        public void LightSourceCountSpecified_SetTrue_Should_SetCount_To_1()
        {
            var lightSourceReference = new LightSourceReference
            {
                LightSourceCount = 0,
                LightSourceCountSpecified = true
            };

            lightSourceReference.LightSourceCount.Should().Be(1);
        }

        [TestCase(0, false)]
        [TestCase(1, true)]
        [TestCase(2, true)]
        public void ControlGearCount_Set_Should_SetSpecifiedAsExpected(int count, bool expected)
        {
            var controlGearReference = new ControlGearReference
            {
                ControlGearCount = count
            };

            controlGearReference.ControlGearCountSpecified.Should().Be(expected);
        }
    }
}