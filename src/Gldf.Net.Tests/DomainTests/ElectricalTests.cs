using FluentAssertions;
using Gldf.Net.Domain.Descriptive;
using Gldf.Net.Domain.Descriptive.Types;
using NUnit.Framework;

namespace Gldf.Net.Tests.DomainTests
{
    [TestFixture]
    public class ElectricalTests
    {
        [Test]
        public void ShouldSerializeElectricalSafetyClass_ShouldReturnTrue_WhenValueIsSet()
        {
            var electrical = new Electrical { ElectricalSafetyClass = SafetyClass.Item0I };
            electrical.ShouldSerializeElectricalSafetyClass().Should().BeTrue();
        }
        
        [Test]
        public void ShouldSerializeElectricalSafetyClass_ShouldReturnTrue_WhenValueIsNull()
        {
            var electrical = new Electrical();
            electrical.ShouldSerializeElectricalSafetyClass().Should().BeFalse();
        }
        
        [Test]
        public void ShouldSerializeIngressProtectionIPCode_ShouldReturnTrue_WhenValueIsSet()
        {
            var electrical = new Electrical { IngressProtectionIPCode = IngressProtectionIPCode.IP24 };
            electrical.ShouldSerializeIngressProtectionIPCode().Should().BeTrue();
        }
        
        [Test]
        public void ShouldSerializeIngressProtectionIPCode_ShouldReturnTrue_WhenValueIsNull()
        {
            var electrical = new Electrical();
            electrical.ShouldSerializeIngressProtectionIPCode().Should().BeFalse();
        }
        
        [Test]
        public void ShouldSerializePowerFactor_ShouldReturnTrue_WhenValueIsSet()
        {
            var electrical = new Electrical { PowerFactor = 1.2 };
            electrical.ShouldSerializePowerFactor().Should().BeTrue();
        }
        
        [Test]
        public void ShouldSerializePowerFactor_ShouldReturnTrue_WhenValueIsNull()
        {
            var electrical = new Electrical();
            electrical.ShouldSerializePowerFactor().Should().BeFalse();
        }
        
        [Test]
        public void ShouldSerializeConstantLightOutput_ShouldReturnTrue_WhenValueIsSet()
        {
            var electrical = new Electrical { ConstantLightOutput = true };
            electrical.ShouldSerializeConstantLightOutput().Should().BeTrue();
        }
        
        [Test]
        public void ShouldSerializeConstantLightOutput_ShouldReturnTrue_WhenValueIsNull()
        {
            var electrical = new Electrical();
            electrical.ShouldSerializeConstantLightOutput().Should().BeFalse();
        }
        
        [Test]
        public void ShouldSerializeLightDistribution_ShouldReturnTrue_WhenValueIsSet()
        {
            var electrical = new Electrical { LightDistribution = LightDistribution.Asymmetrical };
            electrical.ShouldSerializeLightDistribution().Should().BeTrue();
        }
        
        [Test]
        public void ShouldSerializeLightDistribution_ShouldReturnTrue_WhenValueIsNull()
        {
            var electrical = new Electrical();
            electrical.ShouldSerializeLightDistribution().Should().BeFalse();
        }
    }
}