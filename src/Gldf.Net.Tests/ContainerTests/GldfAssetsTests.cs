using FluentAssertions;
using Gldf.Net.Container;
using NUnit.Framework;
using System.Collections.Generic;

namespace Gldf.Net.Tests.ContainerTests
{
    [TestFixture]
    public class GldfAssetsTests
    {
        [Test]
        public void All_Property_Should_Return_UnionOfAllCollections()
        {
            var gldfAssets = new GldfAssets();

            var containerFile1 = new ContainerFile("1", new byte[1]);
            var containerFile2 = new ContainerFile("2", new byte[2]);
            var containerFile3 = new ContainerFile("3", new byte[3]);
            var containerFile4 = new ContainerFile("4", new byte[4]);
            var containerFile5 = new ContainerFile("5", new byte[5]);
            var containerFile6 = new ContainerFile("6", new byte[6]);
            var containerFile7 = new ContainerFile("7", new byte[7]);
            var containerFile8 = new ContainerFile("8", new byte[8]);
            var expected = new List<ContainerFile>
            {
                containerFile1, containerFile2, containerFile3, containerFile4,
                containerFile5, containerFile6, containerFile7, containerFile8
            };

            gldfAssets.Documents.Add(containerFile1);
            gldfAssets.Geometries.Add(containerFile2);
            gldfAssets.Images.Add(containerFile3);
            gldfAssets.Other.Add(containerFile4);
            gldfAssets.Photometries.Add(containerFile5);
            gldfAssets.Sensors.Add(containerFile6);
            gldfAssets.Spectrums.Add(containerFile7);
            gldfAssets.Symbols.Add(containerFile8);

            gldfAssets.All.Should().HaveCount(8).And.Contain(expected);
        }
    }
}