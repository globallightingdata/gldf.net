using FluentAssertions;
using Gldf.Net.Domain.Xml.Head.Types;
using Gldf.Net.XmlHelper;
using NUnit.Framework;
using System.Collections.Generic;

namespace Gldf.Net.Tests.XmlHelperTests;

[TestFixture]
public class FormatVersionComparerTests
{
    [Test, TestCaseSource(nameof(CompareToTestData))]
    public void CompareTo_ShouldReturnExpected(FormatVersion version, FormatVersion other, int expected)
    {
        var compareTo = FormatVersionComparer.Instance.Compare(version, other);
        compareTo.Should().Be(expected);
    }

    public static IEnumerable<TestCaseData> CompareToTestData => new List<TestCaseData>
    {
        new(null, null, 0),
        new(new FormatVersion(1, 0), null, 1),
        new(null, new FormatVersion(1, 0), -1),
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