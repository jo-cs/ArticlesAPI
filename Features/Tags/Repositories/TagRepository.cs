using System.Data;
using ArticlesAPI.Features.Tags.DTOs;
using ArticlesAPI.Infrastructure.Data;
using Dapper;
namespace ArticlesAPI.Features.Tags.Repositories;
public class TagRepository : ITagRepository
{
    private readonly DapperContext _context;
    public TagRepository(DapperContext context) => _context = context;
    public async Task<int> CreateTagAsync(CreateTagDto tag)
    {
        using var connection = _context.CreateConnection();
        return await connection.QuerySingleAsync<int>("Tag_Create", new { tag.Title, tag.ArticleId }, commandType: CommandType.StoredProcedure);
    }
    public async Task<IEnumerable<TagResponseDto>> GetAllTagsAsync()
    {
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<TagResponseDto>("Tag_GetAll", commandType: CommandType.StoredProcedure);
    }
    public async Task<TagResponseDto?> GetTagByIdAsync(int id)
    {
        using var connection = _context.CreateConnection();
        return await connection.QuerySingleOrDefaultAsync<TagResponseDto>("Tag_GetById", new { Id = id }, commandType: CommandType.StoredProcedure);
    }
    public async Task<IEnumerable<TagResponseDto>> GetTagsByArticleIdAsync(int articleId)
    {
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<TagResponseDto>("Tag_GetByArticleId", new { ArticleId = articleId }, commandType: CommandType.StoredProcedure);
    }
    public async Task<bool> UpdateTagAsync(int id, UpdateTagDto tag)
    {
        using var connection = _context.CreateConnection();
        return await connection.QuerySingleAsync<bool>("Tag_Update", new { Id = id, tag.Title }, commandType: CommandType.StoredProcedure);
    }
    public async Task<bool> DeleteTagAsync(int id)
    {
        using var connection = _context.CreateConnection();
        return await connection.QuerySingleAsync<bool>("Tag_Delete", new { Id = id }, commandType: CommandType.StoredProcedure);
    }
}
