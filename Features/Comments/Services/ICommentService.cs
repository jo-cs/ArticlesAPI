using ArticlesAPI.Features.Comments.DTOs;
using ArticlesAPI.Shared.Results;
namespace ArticlesAPI.Features.Comments.Services;
public interface ICommentService
{
    Task<ServiceResult<int>> CreateCommentAsync(CreateCommentDto comment);
    Task<ServiceResult<CommentResponseDto>> GetCommentByIdAsync(int id);
    Task<ServiceResult<IEnumerable<CommentResponseDto>>> GetCommentsByArticleIdAsync(int articleId);
    Task<ServiceResult<IEnumerable<CommentResponseDto>>> GetCommentsByUserIdAsync(int userId);
    Task<ServiceResult<bool>> UpdateCommentAsync(int id, UpdateCommentDto comment);
    Task<ServiceResult<bool>> DeleteCommentAsync(int id);
}
