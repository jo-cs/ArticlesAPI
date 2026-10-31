namespace ArticlesAPI.Features.Articles.DTOs;

public class ArticleResponseDto
{
    public int ArticleId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string? Details { get; set; } 
    public string CategoryName  { get; set; } =  string.Empty;
    public string AuthorName  { get; set; } = string.Empty;
}