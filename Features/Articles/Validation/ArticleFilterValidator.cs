using ArticlesAPI.Features.Articles.DTOs;
using FluentValidation;

namespace ArticlesAPI.Features.Articles.Validation;

public class ArticleFilterValidator : AbstractValidator<ArticleFilterDto>
{
    public ArticleFilterValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThan(0);

        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, 100);

        RuleFor(x => x.SortBy)
            .Must(x => new[] { "ArticleId", "Name", "Title", "CategoryName", "AuthorName" }
                .Contains(x))
            .WithMessage("Invalid SortBy value.");

        RuleFor(x => x.SortOrder)
            .Must(x => new[] { "ASC", "DESC" }.Contains(x))
            .WithMessage("SortOrder must be ASC or DESC.");
    }
}