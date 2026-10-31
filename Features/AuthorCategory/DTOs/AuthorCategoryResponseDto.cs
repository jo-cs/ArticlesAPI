namespace ArticlesAPI.Features.AuthorCategory.DTOs;
public class AuthorCategoryResponseDto
{
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = string.Empty;
}
