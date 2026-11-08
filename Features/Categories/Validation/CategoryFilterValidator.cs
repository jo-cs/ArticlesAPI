using ArticlesAPI.Features.Categories.DTOs;
using FluentValidation;

namespace ArticlesAPI.Features.Categories.Validation;

public class CategoryFilterValidator : AbstractValidator<CategoryFilterDto>
{
    public CategoryFilterValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThan(0);

        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, 100);

        RuleFor(x => x.SortBy)
            .Must(x => new[] { "Id", "Name", "CreatedAt" }.Contains(x))
            .WithMessage("Invalid SortBy value.");

        RuleFor(x => x.SortOrder)
            .Must(x => new[] { "ASC", "DESC" }.Contains(x))
            .WithMessage("SortOrder must be ASC or DESC.");
    }
}