using ArticlesAPI.Features.Articles.DTOs;
using FluentValidation;

namespace ArticlesAPI.Features.Articles.Validation;

public class CreateArticleWithRelationsValidator
    : AbstractValidator<CreateArticleWithRelationsDto>
{
    public CreateArticleWithRelationsValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.Title)
            .NotEmpty();

        RuleFor(x => x.Details)
            .NotEmpty();

        RuleFor(x => x.CategoryId)
            .GreaterThan(0);

        RuleFor(x => x.AuthorId)
            .GreaterThan(0);

        RuleFor(x => x.TagIds)
            .Must(tags => tags.Distinct().Count() == tags.Count)
            .WithMessage("Duplicate TagIds are not allowed.");

        RuleForEach(x => x.TagIds)
            .GreaterThan(0);

        RuleForEach(x => x.Media)
            .ChildRules(media =>
            {
                media.RuleFor(x => x.MediaUrl)
                    .NotEmpty();

                media.RuleFor(x => x.Type)
                    .GreaterThan(0);
            });
    }
}