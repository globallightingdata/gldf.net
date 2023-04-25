using FluentAssertions;
using Gldf.Net.Extensions;
using NUnit.Framework;
using System;

namespace Gldf.Net.Tests.Extensions;

[TestFixture]
public class DisposableExtensionsTests
{
    [Test]
    public void DisposeSafe_ShouldDispose_AndNotThrow()
    {
        var testDisposable = new TestDisposable();
        var act = new Action(() => testDisposable.DisposeSafe());
        
        act.Should().NotThrow();
        testDisposable.IsDispased.Should().BeTrue();
    }

    public class TestDisposable : IDisposable
    {
        public bool IsDispased { get; set; }
        
        public void Dispose()
        {
            IsDispased = true;
            throw new NotImplementedException();
        }
    }
}