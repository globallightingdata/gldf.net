using FluentAssertions;
using Gldf.Net.Extensions;
using NUnit.Framework;
using System;

namespace Gldf.Net.Tests.Extensions;

[TestFixture]
public class DisposableExtensionsTests
{
    [TestCase(true)]
    [TestCase(false)]
    public void DisposeSafe_ShouldDispose_AndNotThrow(bool failOnDispose)
    {
        var testDisposable = new TestDisposable(failOnDispose);
        var act = new Action(() => testDisposable.DisposeSafe());
        
        act.Should().NotThrow();
        testDisposable.IsDispased.Should().BeTrue();
    }

    public class TestDisposable : IDisposable
    {
        private readonly bool _failOnDispose;

        public TestDisposable(bool failOnDispose)
        {
            _failOnDispose = failOnDispose;
        }

        public bool IsDispased { get; set; }
        
        public void Dispose()
        {
            IsDispased = true;
            if(_failOnDispose) throw new Exception();
        }
    }
}