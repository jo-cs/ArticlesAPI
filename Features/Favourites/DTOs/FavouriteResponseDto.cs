namespace ArticlesAPI.Features.Favourites.DTOs;
public class FavouriteResponseDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ArticleId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string CategoryName { get; set; } = string.Empty;
    public string AuthorName { get; set; } = string.Empty;
}
