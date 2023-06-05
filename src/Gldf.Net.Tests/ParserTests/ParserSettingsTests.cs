using FluentAssertions;
using Gldf.Net.Parser;
using NUnit.Framework;
using System;
using System.Net.Http;

namespace Gldf.Net.Tests.ParserTests;

[TestFixture]
public class ParserSettingsTests
{
    [Test]
    public void Ctor_ShouldSetExpected_WhenNoParameterSet()
    {
        var parserSettings = new ParserSettings();
        parserSettings.HttpClient.Should().BeNull();
        parserSettings.LocalFileLoadBehaviour.Should().Be(LocalFileLoadBehaviour.Load);
        parserSettings.OnlineFileLoadBehaviour.Should().Be(OnlineFileLoadBehaviour.Skip);
    }

    [TestCase(LocalFileLoadBehaviour.Load)]
    [TestCase(LocalFileLoadBehaviour.Skip)]
    public void Ctor_ShouldSetExpected_WhenParameterSet(LocalFileLoadBehaviour localFileLoadBehaviour)
    {
        using var httpClient = new HttpClient();
        var parserSettings = new ParserSettings(localFileLoadBehaviour, OnlineFileLoadBehaviour.Load, httpClient);
        parserSettings.HttpClient.Should().Be(httpClient);
        parserSettings.LocalFileLoadBehaviour.Should().Be(localFileLoadBehaviour);
        parserSettings.OnlineFileLoadBehaviour.Should().Be(OnlineFileLoadBehaviour.Load);
    }
    
    [TestCase(LocalFileLoadBehaviour.Load)]
    [TestCase(LocalFileLoadBehaviour.Skip)]
    public void Ctor_ShouldThrow_WhenOnlineFileLoadBehaviour_AndMissingHttpClient(LocalFileLoadBehaviour localFileLoadBehaviour)
    {
        var act = new Action(() =>
        {
            _ = new ParserSettings(localFileLoadBehaviour, OnlineFileLoadBehaviour.Load);
        });
        act.Should()
            .ThrowExactly<ArgumentException>()
            .WithMessage("HttpClient must be set when OnlineFileLoadBehaviour is activated");
    }
}