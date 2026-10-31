namespace ArticlesAPI.Features.Auth.DTOs;

public class LoginResponseDto
{
    public string Token { get; set; } = string.Empty;

    public int Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public int RoleId { get; set; }
}