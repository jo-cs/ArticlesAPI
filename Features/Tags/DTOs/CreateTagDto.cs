namespace ArticlesAPI.Features.Tags.DTOs;
public class CreateTagDto
{
    public string Title { get; set; } = string.Empty;
    public int ArticleId { get; set; }
}
