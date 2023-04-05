using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Validation;

public class ValidationHint
{
    public SeverityType Severity { get; }

    public string Message { get; }

    public ErrorType ErrorType { get; }

    public ValidationHint(SeverityType severityType, string message)
    {
        Severity = severityType;
        Message = message;
        ErrorType = ErrorType.None;
    }

    public ValidationHint(SeverityType severityType, string message, ErrorType errorType)
    {
        Severity = severityType;
        Message = message;
        ErrorType = errorType;
    }

    public static IEnumerable<ValidationHint> Empty() => Enumerable.Empty<ValidationHint>();

    public static IEnumerable<ValidationHint> Info(string infoMessage) => new[]
    {
        new ValidationHint(SeverityType.Info, infoMessage, ErrorType.None)
    };

    public static IEnumerable<ValidationHint> Warning(string warningMessage, ErrorType errorType)
    {
        yield return new ValidationHint(SeverityType.Warning, warningMessage, errorType);
    }

    public static IEnumerable<ValidationHint> Error(string errorMessage, ErrorType errorType)
    {
        yield return new ValidationHint(SeverityType.Error, errorMessage, errorType);
    }

    public override string ToString()
    {
        return $"{nameof(Severity)}: {Severity}, {nameof(ErrorType)}: {ErrorType}, {nameof(Message)}: {Message}";
    }
}