namespace ArticlesAPI.Features.Categories.DTOs;

public class CategoryFilterDto
{
    public string? Search { get; set; }

    public string SortBy { get; set; } = "Id";

    public string SortOrder { get; set; } = "DESC";

    public int PageNumber { get; set; } = 1;

    public int PageSize { get; set; } = 10;
}