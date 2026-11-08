using ArticlesAPI.Features.Categories.DTOs;
using FluentValidation;

namespace ArticlesAPI.Features.Categories.Validation;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryValidator()
    {
        RuleFor(category => category.Name).NotEmpty();
    }
}

public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
{
    public UpdateCategoryValidator()
    {
        RuleFor(category => category.Name).NotEmpty();
    }
}
