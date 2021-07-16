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
        [Test, TestCaseSource(nameof(TestData))]
        public void GetBytesFromContainer_Should_Return_Expected(GldfArchive archive, GldfFile file, byte[] expected)
        {
            var fileContent = file.GetBytesFromContainer(archive);

            fileContent.Should().BeSameAs(expected);
        }

        [Test]
        public void GetBytesFromContainer_Should_IgnoreCase()
        {
            var gldfFile = new GldfFile {File = "file1.jpg", ContentType = FileContentType.ImageJpg};
            var expected = new byte[1];
            var gldfArchive = new GldfArchive();
            gldfArchive.Assets.Images.Add(new ContainerFile("FILE1.JPG", expected));

            var fileContent = gldfFile.GetBytesFromContainer(gldfArchive);

            fileContent.Should().BeSameAs(fileContent);
        }

        [Test]
        public void GetBytesFromContainer_Should_Throw_WhenInvalid_FileContentType()
        {
            var gldfArchive = new GldfArchive();
            const FileContentType invalidFileContentType = (FileContentType) int.MaxValue;
            var gldfFile = new GldfFile {File = "file.jpg", ContentType = invalidFileContentType};
            gldfArchive.Assets.Images.Add(new ContainerFile("file.jpg", new byte[1]));

            Action act = () => gldfFile.GetBytesFromContainer(gldfArchive);

            act.Should()
                .Throw<ArgumentOutOfRangeException>()
                .WithMessage("Specified argument was out of the range of valid values.");
        }

        private static IEnumerable<TestCaseData> TestData()
        {
            var file1 = new GldfFile {File = "file1.jpg", ContentType = FileContentType.ImageJpg};
            var file2 = new GldfFile {File = "file2.png", ContentType = FileContentType.ImagePng};
            var file3 = new GldfFile {File = "file3.svg", ContentType = FileContentType.ImageSvg};
            var file4 = new GldfFile {File = "file4.l3d", ContentType = FileContentType.GeoL3d};
            var file5 = new GldfFile {File = "file5.m3d", ContentType = FileContentType.GeoM3d};
            var file6 = new GldfFile {File = "file7.r3d", ContentType = FileContentType.GeoR3d};
            var file7 = new GldfFile {File = "file8.ldt", ContentType = FileContentType.LdcEulumdat};
            var file8 = new GldfFile {File = "file9.ies", ContentType = FileContentType.LdcIes};
            var file9 = new GldfFile {File = "file10.pdf", ContentType = FileContentType.DocPdf};
            var file10 = new GldfFile {File = "file11.txt", ContentType = FileContentType.SpectrumText};
            var file11 = new GldfFile {File = "file12.dxf", ContentType = FileContentType.SymbolDxf};
            var file12 = new GldfFile {File = "file13.svg", ContentType = FileContentType.SymbolSvg};
            var file13 = new GldfFile {File = "file14.ldt", ContentType = FileContentType.SensorSensLdt};
            var file14 = new GldfFile {File = "file15.xml", ContentType = FileContentType.SensorSensXml};
            var file15 = new GldfFile {File = "file16.xsl", ContentType = FileContentType.Other};

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

            var gldfArchive = new GldfArchive();
            gldfArchive.Assets.Images.Add(new ContainerFile("file1.jpg", file1Content));
            gldfArchive.Assets.Images.Add(new ContainerFile("file2.png", file2Content));
            gldfArchive.Assets.Images.Add(new ContainerFile("file3.svg", file3Content));
            gldfArchive.Assets.Geometries.Add(new ContainerFile("file4.l3d", file4Content));
            gldfArchive.Assets.Geometries.Add(new ContainerFile("file5.m3d", file5Content));
            gldfArchive.Assets.Geometries.Add(new ContainerFile("file7.r3d", file6Content));
            gldfArchive.Assets.Photometries.Add(new ContainerFile("file8.ldt", file7Content));
            gldfArchive.Assets.Photometries.Add(new ContainerFile("file9.ies", file8Content));
            gldfArchive.Assets.Documents.Add(new ContainerFile("file10.pdf", file9Content));
            gldfArchive.Assets.Spectrums.Add(new ContainerFile("file11.txt", file10Content));
            gldfArchive.Assets.Symbols.Add(new ContainerFile("file12.dxf", file11Content));
            gldfArchive.Assets.Symbols.Add(new ContainerFile("file13.svg", file12Content));
            gldfArchive.Assets.Sensors.Add(new ContainerFile("file14.ldt", file13Content));
            gldfArchive.Assets.Sensors.Add(new ContainerFile("file15.xml", file14Content));
            gldfArchive.Assets.Other.Add(new ContainerFile("file16.xsl", file15Content));

            return new List<TestCaseData>
            {
                new TestCaseData(gldfArchive, file1, file1Content).SetName("jpg"),
                new TestCaseData(gldfArchive, file2, file2Content).SetName("png"),
                new TestCaseData(gldfArchive, file3, file3Content).SetName("svg"),
                new TestCaseData(gldfArchive, file4, file4Content).SetName("l3d"),
                new TestCaseData(gldfArchive, file5, file5Content).SetName("m3d"),
                new TestCaseData(gldfArchive, file6, file6Content).SetName("r3d"),
                new TestCaseData(gldfArchive, file7, file7Content).SetName("ldt"),
                new TestCaseData(gldfArchive, file8, file8Content).SetName("ies"),
                new TestCaseData(gldfArchive, file9, file9Content).SetName("pdf"),
                new TestCaseData(gldfArchive, file10, file10Content).SetName("txt"),
                new TestCaseData(gldfArchive, file11, file11Content).SetName("dxf"),
                new TestCaseData(gldfArchive, file12, file12Content).SetName("svg"),
                new TestCaseData(gldfArchive, file13, file13Content).SetName("ldt"),
                new TestCaseData(gldfArchive, file14, file14Content).SetName("xml"),
                new TestCaseData(gldfArchive, file15, file15Content).SetName("xsl")
            };
        }
    }
}