using ArticlesAPI.Features.Media.DTOs;
using FluentValidation;

namespace ArticlesAPI.Features.Media.Validation;

public class CreateMediaValidator : AbstractValidator<CreateMediaDto>
{
    public CreateMediaValidator()
    {
        RuleFor(media => media.MediaUrl).NotEmpty();
        RuleFor(media => media.ArticleId).GreaterThan(0);
    }
}

public class UpdateMediaValidator : AbstractValidator<UpdateMediaDto>
{
    public UpdateMediaValidator()
    {
        RuleFor(media => media.MediaUrl).NotEmpty();
        RuleFor(media => media.ArticleId).GreaterThan(0);
    }
}
