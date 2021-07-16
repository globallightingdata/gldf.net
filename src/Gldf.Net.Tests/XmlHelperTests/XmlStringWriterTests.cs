using FluentAssertions;
using Gldf.Net.XmlHelper;
using NUnit.Framework;
using System.Text;

namespace Gldf.Net.Tests.XmlHelperTests
{
    [TestFixture]
    public class XmlStringWriterTests
    {
        [Test]
        public void Encoding_Default_Should_Be_Utf8()
        {
            var xmlStringWriter = new XmlStringWriter();

            xmlStringWriter.Encoding.Should().Be(Encoding.UTF8);
        }

        [Test]
        public void Ctor_WithEncodingParameter_Should_SetIt()
        {
            var xmlStringWriter = new XmlStringWriter(Encoding.UTF32);

            xmlStringWriter.Encoding.Should().Be(Encoding.UTF32);
        }
    }
}