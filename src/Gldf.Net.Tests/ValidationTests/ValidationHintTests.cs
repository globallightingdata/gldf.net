using FluentAssertions;
using Gldf.Net.Validation;
using NUnit.Framework;
using System.Linq;

namespace Gldf.Net.Tests.ValidationTests;

[TestFixture]
public class ValidationHintTests
{
    [Test]
    public void Empty_ShouldReturn_EmptyListOfHints()
    {
        var validationHints = ValidationHint.Empty();

        validationHints.Should().BeEmpty();
    }

    [Test]
    public void Info_ShouldReturn_ListWithExpected_Hint()
    {
        const string message = "Message";
        var expectedHint = new ValidationHint(SeverityType.Info, message);
        var validationHints = ValidationHint.Info(message).ToList();

        validationHints.Should().HaveCount(1);
        validationHints.Should().ContainEquivalentOf(expectedHint);
    }

    [Test]
    public void Warning_ShouldReturn_ListWithExpected_Hint()
    {
        const string message = "Message";
        const ErrorType errorType = ErrorType.TooLargeFiles;
        var expectedHint = new ValidationHint(SeverityType.Warning, message, errorType);
        var validationHints = ValidationHint.Warning(message, errorType).ToList();

        validationHints.Should().HaveCount(1);
        validationHints.Should().ContainEquivalentOf(expectedHint);
    }

    [Test]
    public void Error_ShouldReturn_ListWithExpected_Hint()
    {
        const string message = "Message";
        const ErrorType errorType = ErrorType.NonDeserialisableRoot;
        var expectedHint = new ValidationHint(SeverityType.Error, message, errorType);
        var validationHints = ValidationHint.Error(message, errorType).ToList();

        validationHints.Should().HaveCount(1);
        validationHints.Should().ContainEquivalentOf(expectedHint);
    }

    [Test]
    public void ToString_ShouldReturn_StringWithExpectedProperties()
    {
        const string message = "Message";
        const ErrorType errorType = ErrorType.GenericError;
        var hint = new ValidationHint(SeverityType.Error, message, errorType);

        var hintString = hint.ToString();

        hintString.Should().Be("Severity: Error, ErrorType: GenericError, Message: Message");
    }
}