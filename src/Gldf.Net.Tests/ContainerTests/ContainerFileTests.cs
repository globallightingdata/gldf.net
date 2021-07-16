using FluentAssertions;
using Gldf.Net.Container;
using NUnit.Framework;
using System;

namespace Gldf.Net.Tests.ContainerTests
{
    [TestFixture]
    public class ContainerFileTests
    {
        [Test]
        public void Ctor_Should_Set_Parameter_AsExpected()
        {
            const string fileName = "fileName";
            var fileContent = new byte[1];

            var containerFile = new ContainerFile(fileName, fileContent);

            containerFile.FileName.Should().BeSameAs(fileName);
            containerFile.Bytes.Should().BeSameAs(fileContent);
        }

        [Test]
        public void Ctor_Should_Throw_When_FileName_IsNull()
        {
            Action act = () => _ = new ContainerFile(null, new byte[1]);

            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void Ctor_Should_Throw_When_FileContent_IsNull()
        {
            Action act = () => _ = new ContainerFile("fileName", null);

            act.Should().Throw<ArgumentNullException>();
        }
    }
}