using FluentAssertions;
using Gldf.Net.Domain.Definition;
using Gldf.Net.Domain.Product.Types;
using NUnit.Framework;

namespace Gldf.Net.Tests.DomainTests
{
    [TestFixture]
    public class GeometryTests
    {
        [Test]
        public void GetReferenceAsEmitterReference_ShouldReturnExpected()
        {
            var expected = new EmitterReference();
            var geometry = new Geometry { Reference = expected };
            var reference = geometry.GetReferenceAsEmitterReference();
            reference.Should().Be(expected);
        }

        [Test]
        public void GetReferenceAsSimpleGeometryReference_ShouldReturnExpected()
        {
            var expected = new SimpleGeometryReference();
            var geometry = new Geometry { Reference = expected };
            var reference = geometry.GetReferenceAsSimpleGeometryReference();
            reference.Should().Be(expected);
        }

        [Test]
        public void GetReferenceAsModelGeometryReference_ShouldReturnExpected()
        {
            var expected = new ModelGeometryReference();
            var geometry = new Geometry { Reference = expected };
            var reference = geometry.GetReferenceAsModelGeometryReference();
            reference.Should().Be(expected);
        }

        [Test]
        public void GetReferenceAsGeometryReferences_ShouldReturnExpected()
        {
            var expected = new GeometryReferences();
            var geometry = new Geometry { Reference = expected };
            var reference = geometry.GetReferenceAsGeometryReferences();
            reference.Should().Be(expected);
        }

        [Test]
        public void GetAsEmitterReference_ShouldReturnNull_WhenValueNotSet()
        {
            var geometry = new Geometry();
            var reference = geometry.GetReferenceAsEmitterReference();
            reference.Should().BeNull();
        }

        [Test]
        public void GetReferenceAsSimpleGeometryReference_ShouldReturnNull_WhenValueNotSet()
        {
            var geometry = new Geometry();
            var reference = geometry.GetReferenceAsSimpleGeometryReference();
            reference.Should().BeNull();
        }

        [Test]
        public void GetReferenceAsModelGeometryReference_ShouldReturnNull_WhenValueNotSet()
        {
            var geometry = new Geometry();
            var reference = geometry.GetReferenceAsModelGeometryReference();
            reference.Should().BeNull();
        }

        [Test]
        public void GetReferenceAsGeometryReferences_ShouldReturnNull_WhenValueNotSet()
        {
            var geometry = new Geometry();
            var reference = geometry.GetReferenceAsGeometryReferences();
            reference.Should().BeNull();
        }

        [Test]
        public void GetAsEmitterReference_ShouldReturnNull_WhenValueSetToOtherTyp()
        {
            var geometry = new Geometry { Reference = new GeometryReferences() };
            var reference = geometry.GetReferenceAsEmitterReference();
            reference.Should().BeNull();
        }
        
        [Test]
        public void GetReferenceAsSimpleGeometryReference_ShouldReturnNull_WhenValueSetToOtherTyp()
        {
            var geometry = new Geometry { Reference = new GeometryReferences() };
            var reference = geometry.GetReferenceAsSimpleGeometryReference();
            reference.Should().BeNull();
        }
        
        [Test]
        public void GetReferenceAsModelGeometryReference_ShouldReturnNull_WhenValueSetToOtherTyp()
        {
            var geometry = new Geometry { Reference = new GeometryReferences() };
            var reference = geometry.GetReferenceAsModelGeometryReference();
            reference.Should().BeNull();
        }
        
        [Test]
        public void GetReferenceAsGeometryReferences_ShouldReturnNull_WhenValueSetToOtherTyp()
        {
            var geometry = new Geometry { Reference = new SimpleGeometryReference() };
            var reference = geometry.GetReferenceAsGeometryReferences();
            reference.Should().BeNull();
        }
    }
}