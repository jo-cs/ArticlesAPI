using System.Data;
using ArticlesAPI.Features.Media.DTOs;
using ArticlesAPI.Infrastructure.Data;
using Dapper;
namespace ArticlesAPI.Features.Media.Repositories;
public class MediaRepository : IMediaRepository
{
    private readonly DapperContext _context;
    public MediaRepository(DapperContext context) => _context = context;
    public async Task<int> CreateMediaAsync(CreateMediaDto media)
    {
        using var connection = _context.CreateConnection();
        return await connection.QuerySingleAsync<int>("Media_Create", new
        {
            media.MediaUrl, media.Type, media.ArticleId
        }, commandType: CommandType.StoredProcedure);
    }
    public async Task<IEnumerable<MediaResponseDto>> GetAllMediaAsync()
    {
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<MediaResponseDto>("Media_GetAll",
            commandType: CommandType.StoredProcedure);
    }
    public async Task<MediaResponseDto?> GetMediaByIdAsync(int id)
    {
        using var connection = _context.CreateConnection();
        return await connection.QuerySingleOrDefaultAsync<MediaResponseDto>("Media_GetById", new
        {
            Id = id
        }, commandType: CommandType.StoredProcedure);
    }
    public async Task<IEnumerable<MediaResponseDto>> GetMediaByArticleIdAsync(int articleId)
    {
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<MediaResponseDto>("Media_GetByArticleId", new
        {
            ArticleId = articleId
        }, commandType: CommandType.StoredProcedure);
    }
    public async Task<bool> UpdateMediaAsync(int id, UpdateMediaDto media)
    {
        using var connection = _context.CreateConnection();
        return await connection.QuerySingleAsync<bool>("Media_Update", new
        {
            Id = id, media.MediaUrl, media.Type, media.ArticleId
        }, commandType: CommandType.StoredProcedure);
    }
    public async Task<bool> DeleteMediaAsync(int id)
    {
        using var connection = _context.CreateConnection();
        return await connection.QuerySingleAsync<bool>("Media_Delete", new
        {
            Id = id
        }, commandType: CommandType.StoredProcedure);
    }
}
