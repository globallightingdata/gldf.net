using FluentAssertions;
using Gldf.Net.Domain.Typed.Head.Types;
using NUnit.Framework;

namespace Gldf.Net.Tests.DomainTests.Typed;

[TestFixture]
public class FormatVersionTypedTests
{
    [Test]
    public void ToString_ShoudlReturnExpected()
    {
        var versionTyped = new FormatVersionTyped { Major = 1, Minor = 2 };
        versionTyped.ToString().Should().Be("v1.2");
    }

    [Test]
    public void ToString_ShoudlReturnExpected_WhenPreReleaseIsSet()
    {
        var versionTyped = new FormatVersionTyped { Major = 1, Minor = 2, PreRelease = 3 };
        versionTyped.ToString().Should().Be("v1.2-rc3");
    }
}