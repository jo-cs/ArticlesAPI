namespace ArticlesAPI.Features.Media.DTOs;
public class CreateMediaDto
{
    public string MediaUrl { get; set; } = string.Empty;
    public int Type { get; set; }
    public int ArticleId { get; set; }
}
