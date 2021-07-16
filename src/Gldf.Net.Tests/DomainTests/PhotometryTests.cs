using FluentAssertions;
using Gldf.Net.Domain.Definition;
using Gldf.Net.Domain.Definition.Types;
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