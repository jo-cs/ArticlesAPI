namespace ArticlesAPI.Features.AccessControl.DTOs;

public class UpdateRoleDto
{
    public string NameOfRole { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
