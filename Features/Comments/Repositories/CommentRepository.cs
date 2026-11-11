using ArticlesAPI.Features.Comments.DTOs;
using ArticlesAPI.Infrastructure.Data;
using ArticlesAPI.Shared.Repositories;
namespace ArticlesAPI.Features.Comments.Repositories;
public class CommentRepository : BaseRepository, ICommentRepository
{
    public CommentRepository(DapperContext context) : base(context) { }
    public Task<int> CreateCommentAsync(CreateCommentDto comment) => QuerySingleAsync<int>("Comment_Create", new { comment.UserId, comment.ArticleId, comment.Content });
    public Task<CommentResponseDto?> GetCommentByIdAsync(int id) => QuerySingleOrDefaultAsync<CommentResponseDto>("Comment_GetById", new { Id = id });
    public Task<IEnumerable<CommentResponseDto>> GetCommentsByArticleIdAsync(int articleId) => QueryAsync<CommentResponseDto>("Comment_GetByArticleId", new { ArticleId = articleId });
    public Task<IEnumerable<CommentResponseDto>> GetCommentsByUserIdAsync(int userId) => QueryAsync<CommentResponseDto>("Comment_GetByUserId", new { UserId = userId });
    public Task<bool> UpdateCommentAsync(int id, UpdateCommentDto comment) => QuerySingleAsync<bool>("Comment_Update", new { Id = id, comment.Content });
    public Task<bool> DeleteCommentAsync(int id) => QuerySingleAsync<bool>("Comment_Delete", new { Id = id });
}
