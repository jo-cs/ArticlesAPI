using ArticlesAPI.Features.Authors.DTOs;
using FluentValidation;

namespace ArticlesAPI.Features.Authors.Validation;

public class CreateAuthorValidator : AbstractValidator<CreateAuthorDto>
{
    public CreateAuthorValidator()
    {
        RuleFor(author => author.LiteraryName).NotEmpty();
        RuleFor(author => author.DateOfBirth)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.UtcNow);
        RuleFor(author => author.UserId).GreaterThan(0);
    }
}

public class UpdateAuthorValidator : AbstractValidator<UpdateAuthorDto>
{
    public UpdateAuthorValidator()
    {
        RuleFor(author => author.LiteraryName).NotEmpty();
        RuleFor(author => author.DateOfBirth)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.UtcNow);
    }
}
