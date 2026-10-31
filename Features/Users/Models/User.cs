namespace ArticlesAPI.Features.Users.Models;

public class User
{
    public int  Id { get; set; }
    public string FullName { get; set; } =  string.Empty;
    public string Email { get; set; }  = string.Empty;
    public string HashPassword { get; set; }  = string.Empty;
    
    public string RoleName { get; set; } = string.Empty;
    public int RoleId { get; set; } 
}