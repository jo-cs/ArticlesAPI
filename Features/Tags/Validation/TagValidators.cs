using ArticlesAPI.Features.Tags.DTOs;
using FluentValidation;

namespace ArticlesAPI.Features.Tags.Validation;

public class CreateTagValidator : AbstractValidator<CreateTagDto>
{
    public CreateTagValidator()
    {
        RuleFor(tag => tag.Title).NotEmpty();
        RuleFor(tag => tag.ArticleId).GreaterThan(0);
    }
}

public class UpdateTagValidator : AbstractValidator<UpdateTagDto>
{
    public UpdateTagValidator()
    {
        RuleFor(tag => tag.Title).NotEmpty();
    }
}
