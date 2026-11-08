using ArticlesAPI.Features.AuthorCategory.DTOs;
using FluentValidation;

namespace ArticlesAPI.Features.AuthorCategory.Validation;

public class AddAuthorCategoryValidator : AbstractValidator<AddAuthorCategoryDto>
{
    public AddAuthorCategoryValidator()
    {
        RuleFor(relation => relation.AuthorId).GreaterThan(0);
        RuleFor(relation => relation.CategoryId).GreaterThan(0);
    }
}
