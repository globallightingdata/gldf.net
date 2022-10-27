using FluentAssertions;
using Gldf.Net.Domain.Xml.Descriptive.Types;
using NUnit.Framework;

namespace Gldf.Net.Tests.DomainTests
{
    [TestFixture]
    public class CustomPropertyTests
    {
        [Test]
        public void GetAsFileReference_Should_Return_Expected()
        {
            var expectedFileReference = new PropertyFileReference();
            var customProperty = new CustomProperty {Content = expectedFileReference};

            var fileReference = customProperty.GetAsFileReference();

            fileReference.Should().Be(expectedFileReference);
        }

        [Test]
        public void GetAsText_Should_Return_Expected()
        {
            var expectedPropertyText = new PropertyText();
            var customProperty = new CustomProperty {Content = expectedPropertyText};

            var propertyText = customProperty.GetAsText();

            propertyText.Should().Be(expectedPropertyText);
        }
    }
}