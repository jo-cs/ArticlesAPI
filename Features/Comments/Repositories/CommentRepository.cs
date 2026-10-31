using System.Data;
using ArticlesAPI.Features.Comments.DTOs;
using ArticlesAPI.Infrastructure.Data;
using Dapper;
namespace ArticlesAPI.Features.Comments.Repositories;
public class CommentRepository : ICommentRepository
{
    private readonly DapperContext _context;
    public CommentRepository(DapperContext context) => _context = context;
    public async Task<int> CreateCommentAsync(CreateCommentDto comment)
    {
        using var connection = _context.CreateConnection();
        return await connection.QuerySingleAsync<int>("Comment_Create", new { comment.UserId, comment.ArticleId, comment.Content }, commandType: CommandType.StoredProcedure);
    }
    public async Task<CommentResponseDto?> GetCommentByIdAsync(int id)
    {
        using var connection = _context.CreateConnection();
        return await connection.QuerySingleOrDefaultAsync<CommentResponseDto>("Comment_GetById", new { Id = id }, commandType: CommandType.StoredProcedure);
    }
    public async Task<IEnumerable<CommentResponseDto>> GetCommentsByArticleIdAsync(int articleId)
    {
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<CommentResponseDto>("Comment_GetByArticleId", new { ArticleId = articleId }, commandType: CommandType.StoredProcedure);
    }
    public async Task<IEnumerable<CommentResponseDto>> GetCommentsByUserIdAsync(int userId)
    {
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<CommentResponseDto>("Comment_GetByUserId", new { UserId = userId }, commandType: CommandType.StoredProcedure);
    }
    public async Task<bool> UpdateCommentAsync(int id, UpdateCommentDto comment)
    {
        using var connection = _context.CreateConnection();
        return await connection.QuerySingleAsync<bool>("Comment_Update", new { Id = id, comment.Content }, commandType: CommandType.StoredProcedure);
    }
    public async Task<bool> DeleteCommentAsync(int id)
    {
        using var connection = _context.CreateConnection();
        return await connection.QuerySingleAsync<bool>("Comment_Delete", new { Id = id }, commandType: CommandType.StoredProcedure);
    }
}
