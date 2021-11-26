using FluentAssertions;
using Gldf.Net.Container;
using Gldf.Net.Domain.Definition;
using Gldf.Net.Domain.Definition.Types;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Gldf.Net.Tests.ContainerTests
{
    [TestFixture]
    public class GldfFileExtensionsTests
    {
        [Test]
        public void GetBytesFromContainer_ShouldThrow_When_File_IsNull()
        {
            Action act = () => ((GldfFile)null).GetBytesFromContainer(new GldfContainer());

            act.Should()
                .ThrowExactly<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'file')");
        }

        [Test]
        public void GetBytesFromContainer_ShouldThrow_When_Container_IsNull()
        {
            Action act = () => new GldfFile().GetBytesFromContainer(null);

            act.Should()
                .ThrowExactly<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'container')");
        }

        [Test, TestCaseSource(nameof(TestData))]
        public void GetBytesFromContainer_Should_ReturnExpected(GldfContainer container, GldfFile file, byte[] expected)
        {
            var fileContent = file.GetBytesFromContainer(container);

            fileContent.Should().BeSameAs(expected);
        }

        [Test]
        public void GetBytesFromContainer_Should_ReturnNull_When_FileNotExists()
        {
            var gldfFile = new GldfFile { File = "file.jpg", ContentType = FileContentType.ImageJpg };
            var gldfContainer = new GldfContainer();

            var fileContent = gldfFile.GetBytesFromContainer(gldfContainer);

            fileContent.Should().BeNull();
        }

        [Test]
        public void GetBytesFromContainer_Should_IgnoreCase()
        {
            var gldfFile = new GldfFile { File = "file1.jpg", ContentType = FileContentType.ImageJpg };
            var expected = new byte[1];
            var gldfContainer = new GldfContainer();
            gldfContainer.Assets.Images.Add(new ContainerFile("FILE1.JPG", expected));

            var fileContent = gldfFile.GetBytesFromContainer(gldfContainer);

            fileContent.Should().BeSameAs(fileContent);
        }

        [Test]
        public void GetBytesFromContainer_ShouldThrow_WhenInvalid_FileContentType()
        {
            var gldfContainer = new GldfContainer();
            const FileContentType invalidFileContentType = (FileContentType)int.MaxValue;
            var gldfFile = new GldfFile { File = "file.jpg", ContentType = invalidFileContentType };
            gldfContainer.Assets.Images.Add(new ContainerFile("file.jpg", new byte[1]));

            Action act = () => gldfFile.GetBytesFromContainer(gldfContainer);

            act.Should()
                .Throw<ArgumentOutOfRangeException>()
                .WithMessage("Specified argument was out of the range of valid values.");
        }

        private static IEnumerable<TestCaseData> TestData()
        {
            var file1 = new GldfFile { File = "file1.jpg", ContentType = FileContentType.ImageJpg };
            var file2 = new GldfFile { File = "file2.png", ContentType = FileContentType.ImagePng };
            var file3 = new GldfFile { File = "file3.svg", ContentType = FileContentType.ImageSvg };
            var file4 = new GldfFile { File = "file4.l3d", ContentType = FileContentType.GeoL3d };
            var file5 = new GldfFile { File = "file5.m3d", ContentType = FileContentType.GeoM3d };
            var file6 = new GldfFile { File = "file7.r3d", ContentType = FileContentType.GeoR3d };
            var file7 = new GldfFile { File = "file8.ldt", ContentType = FileContentType.LdcEulumdat };
            var file8 = new GldfFile { File = "file9.ies", ContentType = FileContentType.LdcIes };
            var file9 = new GldfFile { File = "file10.pdf", ContentType = FileContentType.DocPdf };
            var file10 = new GldfFile { File = "file11.txt", ContentType = FileContentType.SpectrumText };
            var file11 = new GldfFile { File = "file12.dxf", ContentType = FileContentType.SymbolDxf };
            var file12 = new GldfFile { File = "file13.svg", ContentType = FileContentType.SymbolSvg };
            var file13 = new GldfFile { File = "file14.ldt", ContentType = FileContentType.SensorSensLdt };
            var file14 = new GldfFile { File = "file15.xml", ContentType = FileContentType.SensorSensXml };
            var file15 = new GldfFile { File = "file16.xsl", ContentType = FileContentType.Other };

            var file1Content = new byte[1];
            var file2Content = new byte[1];
            var file3Content = new byte[1];
            var file4Content = new byte[1];
            var file5Content = new byte[1];
            var file6Content = new byte[1];
            var file7Content = new byte[1];
            var file8Content = new byte[1];
            var file9Content = new byte[1];
            var file10Content = new byte[1];
            var file11Content = new byte[1];
            var file12Content = new byte[1];
            var file13Content = new byte[1];
            var file14Content = new byte[1];
            var file15Content = new byte[1];

            var gldfContainer = new GldfContainer();
            gldfContainer.Assets.Images.Add(new ContainerFile("file1.jpg", file1Content));
            gldfContainer.Assets.Images.Add(new ContainerFile("file2.png", file2Content));
            gldfContainer.Assets.Images.Add(new ContainerFile("file3.svg", file3Content));
            gldfContainer.Assets.Geometries.Add(new ContainerFile("file4.l3d", file4Content));
            gldfContainer.Assets.Geometries.Add(new ContainerFile("file5.m3d", file5Content));
            gldfContainer.Assets.Geometries.Add(new ContainerFile("file7.r3d", file6Content));
            gldfContainer.Assets.Photometries.Add(new ContainerFile("file8.ldt", file7Content));
            gldfContainer.Assets.Photometries.Add(new ContainerFile("file9.ies", file8Content));
            gldfContainer.Assets.Documents.Add(new ContainerFile("file10.pdf", file9Content));
            gldfContainer.Assets.Spectrums.Add(new ContainerFile("file11.txt", file10Content));
            gldfContainer.Assets.Symbols.Add(new ContainerFile("file12.dxf", file11Content));
            gldfContainer.Assets.Symbols.Add(new ContainerFile("file13.svg", file12Content));
            gldfContainer.Assets.Sensors.Add(new ContainerFile("file14.ldt", file13Content));
            gldfContainer.Assets.Sensors.Add(new ContainerFile("file15.xml", file14Content));
            gldfContainer.Assets.Other.Add(new ContainerFile("file16.xsl", file15Content));

            return new List<TestCaseData>
            {
                new TestCaseData(gldfContainer, file1, file1Content).SetName("jpg"),
                new TestCaseData(gldfContainer, file2, file2Content).SetName("png"),
                new TestCaseData(gldfContainer, file3, file3Content).SetName("svg"),
                new TestCaseData(gldfContainer, file4, file4Content).SetName("l3d"),
                new TestCaseData(gldfContainer, file5, file5Content).SetName("m3d"),
                new TestCaseData(gldfContainer, file6, file6Content).SetName("r3d"),
                new TestCaseData(gldfContainer, file7, file7Content).SetName("ldt"),
                new TestCaseData(gldfContainer, file8, file8Content).SetName("ies"),
                new TestCaseData(gldfContainer, file9, file9Content).SetName("pdf"),
                new TestCaseData(gldfContainer, file10, file10Content).SetName("txt"),
                new TestCaseData(gldfContainer, file11, file11Content).SetName("dxf"),
                new TestCaseData(gldfContainer, file12, file12Content).SetName("svg"),
                new TestCaseData(gldfContainer, file13, file13Content).SetName("ldt"),
                new TestCaseData(gldfContainer, file14, file14Content).SetName("xml"),
                new TestCaseData(gldfContainer, file15, file15Content).SetName("xsl")
            };
        }
    }
}