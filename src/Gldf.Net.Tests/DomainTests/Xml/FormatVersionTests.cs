using FluentAssertions;
using Gldf.Net.Domain.Xml.Head.Types;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

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

    [Test, TestCaseSource(nameof(CompareToTestData))]
    public void CompareTo_ShouldReturnExpected(FormatVersion version, FormatVersion other, int expected)
    {
        var compareTo = version.CompareTo(other);
        compareTo.Should().Be(expected);
    }

    [Test]
    public void Test()
    {
        var versions = new List<FormatVersion>
        {
            new(0, 9, 9),
            new(1, 0, 1),
            new(1, 0, 2),
            new(1, 0, 1),
            new(1, 2, 0),
            new(1, 3),
            new(1, 1),
            new(1, 3, 0),
        };
        Console.WriteLine(versions.Max());
    }

    public static IEnumerable<TestCaseData> CompareToTestData => new List<TestCaseData>
    {
        new(new FormatVersion(1, 1), new FormatVersion(1, 1), 0),
        new(new FormatVersion(1, 1, 1), new FormatVersion(1, 1, 1), 0),
        new(new FormatVersion(2, 1), new FormatVersion(1, 1), 1),
        new(new FormatVersion(1, 2), new FormatVersion(1, 1), 1),
        new(new FormatVersion(1, 1, 0), new FormatVersion(1, 1), -1),
        new(new FormatVersion(1, 1, 1), new FormatVersion(1, 1), -1),
        new(new FormatVersion(1, 1), new FormatVersion(2, 1), -1),
        new(new FormatVersion(1, 1), new FormatVersion(1, 2), -1),
        new(new FormatVersion(1, 1), new FormatVersion(1, 1, 0), 1),
        new(new FormatVersion(1, 1), new FormatVersion(1, 1, 1), 1)
    };
}