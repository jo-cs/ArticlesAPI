namespace ArticlesAPI.Features.Tags.DTOs;
public class TagResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public int ArticleId { get; set; }
}
