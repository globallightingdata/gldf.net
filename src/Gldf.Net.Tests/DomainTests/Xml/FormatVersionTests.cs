using FluentAssertions;
using Gldf.Net.Domain.Xml.Head.Types;
using NUnit.Framework;

namespace Gldf.Net.Tests.DomainTests.Xml;

[TestFixture]
public class FormatVersionTests
{
    [Test]
    public void Ctor_ShouldSetValues()
    {
        var formatVersion = new FormatVersion(1, 2);
        formatVersion.Major.Should().Be(1);
        formatVersion.Minor.Should().Be(2);
        formatVersion.PreRelease.Should().Be(0);
        formatVersion.PreReleaseSpecified.Should().BeFalse();
    }

    [Test]
    public void Ctor_ShouldSetValues_WhenPreRelease()
    {
        var formatVersion = new FormatVersion(1, 2, 3);
        formatVersion.Major.Should().Be(1);
        formatVersion.Minor.Should().Be(2);
        formatVersion.PreRelease.Should().Be(3);
        formatVersion.PreReleaseSpecified.Should().BeTrue();
    }

    [Test]
    public void SetPreRelease_ShouldSetPreReleaseSpecified()
    {
        var formatVersion = new FormatVersion();
        formatVersion.PreReleaseSpecified.Should().BeFalse();
        formatVersion.PreRelease = 1;
        formatVersion.PreReleaseSpecified.Should().BeTrue();
    }

    [Test]
    public void ToString_ShouldReturnExpected()
    {
        var formatVersion1 = new FormatVersion(1, 2);
        var formatVersion2 = new FormatVersion(1, 2, 3);
        formatVersion1.ToString().Should().Be("v1.2");
        formatVersion2.ToString().Should().Be("v1.2-rc3");
    }
}