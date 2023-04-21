using FluentAssertions;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using NUnit.Framework;

namespace Gldf.Net.Tests.DomainTests.Xml;

[TestFixture]
public class EmitterTests
{
    private ChangeableLightEmitter _changeableLightEmitter = null!;
    private FixedLightEmitter _fixedLightEmitter = null!;
    private SensorEmitter _sensorEmitter = null!;
    private EmitterBase[] _possibleFittings = null!;

    [SetUp]
    public void SetUp()
    {
        _changeableLightEmitter = new ChangeableLightEmitter();
        _fixedLightEmitter = new FixedLightEmitter();
        _sensorEmitter = new SensorEmitter();
        _possibleFittings = new EmitterBase[] { _fixedLightEmitter, _changeableLightEmitter, _sensorEmitter };
    }
        
    [Test]
    public void GetChangeableLightEmitters_ShouldReturnExpected()
    {
        var expected = new EmitterBase[] { _changeableLightEmitter };
        var emitter = new Emitter { PossibleFittings = _possibleFittings };

        var lightEmitters = emitter.GetChangeableLightEmitters();

        lightEmitters.Should().BeEquivalentTo(expected);
    }
        
    [Test]
    public void GetFixedLightEmitters_ShouldReturnExpected()
    {
        var expected = new EmitterBase[] { _fixedLightEmitter };
        var emitter = new Emitter { PossibleFittings = _possibleFittings };

        var lightEmitters = emitter.GetFixedLightEmitters();

        lightEmitters.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void GetSensorEmitters_ShouldRetur_Expected()
    {
        var expected = new EmitterBase[] { _sensorEmitter };
        var emitter = new Emitter { PossibleFittings = _possibleFittings };

        var sensorEmitters = emitter.GetSensorEmitters();

        sensorEmitters.Should().BeEquivalentTo(expected);
    }
}