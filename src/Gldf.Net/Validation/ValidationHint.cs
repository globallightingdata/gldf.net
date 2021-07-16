using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Validation
{
    public class ValidationHint
    {
        public SeverityType Severity { get; }

        public string Message { get; }

        public ErrorType ErrorType { get; }

        internal ValidationHint(SeverityType severityType, string message)
        {
            Severity = severityType;
            Message = message;
            ErrorType = ErrorType.None;
        }

        internal ValidationHint(SeverityType severityType, string message, ErrorType errorType)
        {
            Severity = severityType;
            Message = message;
            ErrorType = errorType;
        }

        internal static IEnumerable<ValidationHint> Empty() => Enumerable.Empty<ValidationHint>();

        internal static IEnumerable<ValidationHint> Info(string infoMessage) => new[]
        {
            new ValidationHint(SeverityType.Info, infoMessage, ErrorType.None)
        };

        internal static IEnumerable<ValidationHint> Warning(string warningMessage, ErrorType errorType) => new[]
        {
            new ValidationHint(SeverityType.Warning, warningMessage, errorType)
        };

        internal static IEnumerable<ValidationHint> Error(string errorMessage, ErrorType errorType) => new[]
        {
            new ValidationHint(SeverityType.Error, errorMessage, errorType)
        };

        public override string ToString()
        {
            return $"{nameof(Severity)}: {Severity}, {nameof(ErrorType)}: {ErrorType}, {nameof(Message)}: {Message}";
        }
    }
}