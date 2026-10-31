using ArticlesAPI.Features.Comments.DTOs;
using ArticlesAPI.Features.Comments.Repositories;
namespace ArticlesAPI.Features.Comments.Services;
public class CommentService : ICommentService
{
    private readonly ICommentRepository _repository;
    public CommentService(ICommentRepository repository) => _repository = repository;
    public Task<int> CreateCommentAsync(CreateCommentDto comment) => _repository.CreateCommentAsync(comment);
    public Task<CommentResponseDto?> GetCommentByIdAsync(int id) => _repository.GetCommentByIdAsync(id);
    public Task<IEnumerable<CommentResponseDto>> GetCommentsByArticleIdAsync(int articleId) => _repository.GetCommentsByArticleIdAsync(articleId);
    public Task<IEnumerable<CommentResponseDto>> GetCommentsByUserIdAsync(int userId) => _repository.GetCommentsByUserIdAsync(userId);
    public Task<bool> UpdateCommentAsync(int id, UpdateCommentDto comment) => _repository.UpdateCommentAsync(id, comment);
    public Task<bool> DeleteCommentAsync(int id) => _repository.DeleteCommentAsync(id);
}
