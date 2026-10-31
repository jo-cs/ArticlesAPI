namespace ArticlesAPI.Features.Users.DTOs;

public class UpdateUserDto
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int RoleId { get; set; } = 0;
}