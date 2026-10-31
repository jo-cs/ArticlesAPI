namespace ArticlesAPI.Features.Articles.DTOs;

public class UpdateArticleDto
{
    public string Name { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
    public int CategoryId  { get; set; } = 0;
    public int AuthorId  { get; set; } = 0;
}