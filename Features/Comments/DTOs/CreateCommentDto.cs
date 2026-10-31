namespace ArticlesAPI.Features.Comments.DTOs;
public class CreateCommentDto
{
    public int UserId { get; set; }
    public int ArticleId { get; set; }
    public string? Content { get; set; }
}
