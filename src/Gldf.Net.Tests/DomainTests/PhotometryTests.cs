using FluentAssertions;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using NUnit.Framework;

namespace Gldf.Net.Tests.DomainTests
{
    [TestFixture]
    public class PhotometryTests
    {
        [Test]
        public void GetAsFileReference_Should_Return_Expected()
        {
            var expectedFileReference = new PhotometryFileReference();
            var photometry = new Photometry {Content = expectedFileReference};

            var fileReference = photometry.GetAsFileReference();

            fileReference.Should().Be(expectedFileReference);
        }
    }
}