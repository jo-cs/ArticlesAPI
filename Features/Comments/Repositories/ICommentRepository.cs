using ArticlesAPI.Features.Comments.DTOs;
namespace ArticlesAPI.Features.Comments.Repositories;
public interface ICommentRepository
{
    Task<int> CreateCommentAsync(CreateCommentDto comment);
    Task<CommentResponseDto?> GetCommentByIdAsync(int id);
    Task<IEnumerable<CommentResponseDto>> GetCommentsByArticleIdAsync(int articleId);
    Task<IEnumerable<CommentResponseDto>> GetCommentsByUserIdAsync(int userId);
    Task<bool> UpdateCommentAsync(int id, UpdateCommentDto comment);
    Task<bool> DeleteCommentAsync(int id);
}
