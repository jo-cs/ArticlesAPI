namespace ArticlesAPI.Features.Articles.DTOs;

public class ArticleFilterDto
{
    public string? Search { get; set; }

    public int? CategoryId { get; set; }

    public int? AuthorId { get; set; }

    public string SortBy { get; set; } = "ArticleId";

    public string SortOrder { get; set; } = "DESC";

    public int PageNumber { get; set; } = 1;

    public int PageSize { get; set; } = 10;
}