namespace ArticlesAPI.Features.Users.DTOs;

public class UserFilterDto
{
    public string SearchTerm { get; set; } = string.Empty;
    public int RoleId { get; set; } 
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}