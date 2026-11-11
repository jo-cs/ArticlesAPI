using ArticlesAPI.Features.Comments.DTOs;
using ArticlesAPI.Features.Comments.Repositories;
using ArticlesAPI.Shared.Results;
namespace ArticlesAPI.Features.Comments.Services;
public class CommentService : ICommentService
{
    private readonly ICommentRepository _repository;
    public CommentService(ICommentRepository repository) => _repository = repository;
    public Task<ServiceResult<int>> CreateCommentAsync(CreateCommentDto comment) => ServiceResult<int>.FromAsync(_repository.CreateCommentAsync(comment), "Comment creation failed.", 400);
    public Task<ServiceResult<CommentResponseDto>> GetCommentByIdAsync(int id) => ServiceResult<CommentResponseDto>.FromAsync(_repository.GetCommentByIdAsync(id), "Comment not found.");
    public Task<ServiceResult<IEnumerable<CommentResponseDto>>> GetCommentsByArticleIdAsync(int articleId) => ServiceResult<IEnumerable<CommentResponseDto>>.FromAsync(_repository.GetCommentsByArticleIdAsync(articleId), "Comments could not be retrieved.", 500);
    public Task<ServiceResult<IEnumerable<CommentResponseDto>>> GetCommentsByUserIdAsync(int userId) => ServiceResult<IEnumerable<CommentResponseDto>>.FromAsync(_repository.GetCommentsByUserIdAsync(userId), "Comments could not be retrieved.", 500);
    public Task<ServiceResult<bool>> UpdateCommentAsync(int id, UpdateCommentDto comment) => ServiceResult<bool>.FromAsync(_repository.UpdateCommentAsync(id, comment), "Comment not found or update failed.");
    public Task<ServiceResult<bool>> DeleteCommentAsync(int id) => ServiceResult<bool>.FromAsync(_repository.DeleteCommentAsync(id), "Comment not found.");
}
