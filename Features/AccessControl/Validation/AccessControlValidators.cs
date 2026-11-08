using ArticlesAPI.Features.AccessControl.DTOs;
using FluentValidation;

namespace ArticlesAPI.Features.AccessControl.Validation;

public class CreatePermissionValidator : AbstractValidator<CreatePermissionDto>
{
    public CreatePermissionValidator()
    {
        RuleFor(permission => permission.NameOfPermission).NotEmpty();
    }
}

public class UpdatePermissionValidator : AbstractValidator<UpdatePermissionDto>
{
    public UpdatePermissionValidator()
    {
        RuleFor(permission => permission.NameOfPermission).NotEmpty();
    }
}

public class CreateRoleValidator : AbstractValidator<CreateRoleDto>
{
    public CreateRoleValidator()
    {
        RuleFor(role => role.NameOfRole).NotEmpty();
    }
}

public class UpdateRoleValidator : AbstractValidator<UpdateRoleDto>
{
    public UpdateRoleValidator()
    {
        RuleFor(role => role.NameOfRole).NotEmpty();
    }
}

public class AssignPermissionValidator : AbstractValidator<AssignPermissionDto>
{
    public AssignPermissionValidator()
    {
        RuleFor(assignment => assignment.RoleId).GreaterThan(0);
        RuleFor(assignment => assignment.PermissionId).GreaterThan(0);
    }
}
