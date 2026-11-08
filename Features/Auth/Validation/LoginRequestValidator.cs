using ArticlesAPI.Features.Auth.DTOs;
using FluentValidation;

namespace ArticlesAPI.Features.Auth.Validation;

public class LoginRequestValidator : AbstractValidator<LoginRequestDto>
{
    public LoginRequestValidator()
    {
        RuleFor(request => request.Email)
            .NotEmpty()
            .EmailAddress();
        RuleFor(request => request.Password).NotEmpty();
    }
}
