using FluentValidation;
using PhotoHorizon.Application.Common.Queries;

namespace PhotoHorizon.Application.Abstractions.Validators;

public class BasePagedQueryValidator : AbstractValidator<PagedQuery>
{
    public BasePagedQueryValidator()
    {
        RuleFor(q => q.Page)
            .GreaterThan(0);

        RuleFor(q => q.PerPage)
            .GreaterThan(0);
    }
}
