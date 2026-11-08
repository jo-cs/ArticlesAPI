namespace ArticlesAPI.Features.Articles.DTOs;

public class CreateArticleWithRelationsDto
{
    public string Name { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string Details { get; set; } = string.Empty;

    public int CategoryId { get; set; }

    public int AuthorId { get; set; }

    public List<int> TagIds { get; set; } = [];

    public List<MediaInputDto> Media { get; set; } = [];
}