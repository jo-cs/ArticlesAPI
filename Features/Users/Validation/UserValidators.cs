using ArticlesAPI.Features.Users.DTOs;
using FluentValidation;

namespace ArticlesAPI.Features.Users.Validation;

public class CreateUserValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserValidator()
    {
        RuleFor(user => user.FullName)
            .NotEmpty()
            .WithMessage("Full name is required.");

        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("A valid email address is required.");

        RuleFor(user => user.Password)
            .NotEmpty()
            .WithMessage("Password is required.")
            .MinimumLength(8)
            .WithMessage("Password must be at least 8 characters long.");

        RuleFor(user => user.RoleId)
            .GreaterThan(0)
            .WithMessage("RoleId must be greater than zero.");
    }
}

public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
{
    public UpdateUserValidator()
    {
        RuleFor(user => user.FullName)
            .NotEmpty()
            .WithMessage("Full name is required.");

        RuleFor(user => user.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("A valid email address is required.");

        RuleFor(user => user.RoleId)
            .GreaterThan(0)
            .WithMessage("RoleId must be greater than zero.");
    }
}
