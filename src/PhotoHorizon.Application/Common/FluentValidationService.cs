using FluentValidation.Results;

namespace PhotoHorizon.Application.Common;

public static class FluentValidationService
{
    public static string FluentValidationFailuresToString(IEnumerable<ValidationFailure> failures)
    {
        return string.Join(Environment.NewLine, failures.Select(f => f.ErrorMessage));
    }
}
