using FluentValidation;
using PhotoHorizon.Application.Common.Queries;

namespace PhotoHorizon.Application.Abstractions.Validators;

public class BasePagedSearchQueryValidator : AbstractValidator<PagedSearchQuery>
{
    public BasePagedSearchQueryValidator()
    {
        Include(new BasePagedQueryValidator());
    }
}
