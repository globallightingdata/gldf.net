using FluentAssertions;
using Gldf.Net.Container;
using NUnit.Framework;
using System.IO;
using System.IO.Compression;

namespace Gldf.Net.Tests.ContainerTests;

[TestFixture]
public class ZipEntryExtensionsTests
{
    private string _tempFileName;

    [SetUp]
    public void SetUp()
    {
        _tempFileName = Path.GetTempFileName();
    }

    [TearDown]
    public void TearDown()
    {
        File.Delete(_tempFileName);
    }

    [Test]
    public void ZipArchiveEntry_GetBytes_ShouldBeSameAs_WrittenToStream()
    {
        var expectedContent = new byte[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        using var zipFile = ZipFile.Open(_tempFileName, ZipArchiveMode.Update);
        var zipArchiveEntry = zipFile.CreateEntry("test");
        using (var stream = zipArchiveEntry.Open())
            stream.Write(expectedContent);

        zipArchiveEntry.GetBytes().Should().BeEquivalentTo(expectedContent);
    }
}