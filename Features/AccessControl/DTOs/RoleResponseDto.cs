namespace ArticlesAPI.Features.AccessControl.DTOs;

public class RoleResponseDto
{
    public int Id { get; set; }
    public string NameOfRole { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
