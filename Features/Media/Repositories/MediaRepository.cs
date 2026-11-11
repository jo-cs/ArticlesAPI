using ArticlesAPI.Features.Media.DTOs;
using ArticlesAPI.Infrastructure.Data;
using ArticlesAPI.Shared.Repositories;
namespace ArticlesAPI.Features.Media.Repositories;
public class MediaRepository : BaseRepository, IMediaRepository
{
    public MediaRepository(DapperContext context) : base(context) { }
    public Task<int> CreateMediaAsync(CreateMediaDto media) => QuerySingleAsync<int>("Media_Create", new { media.MediaUrl, media.Type, media.ArticleId });
    public Task<IEnumerable<MediaResponseDto>> GetAllMediaAsync() => QueryAsync<MediaResponseDto>("Media_GetAll");
    public Task<MediaResponseDto?> GetMediaByIdAsync(int id) => QuerySingleOrDefaultAsync<MediaResponseDto>("Media_GetById", new { Id = id });
    public Task<IEnumerable<MediaResponseDto>> GetMediaByArticleIdAsync(int articleId) => QueryAsync<MediaResponseDto>("Media_GetByArticleId", new { ArticleId = articleId });
    public Task<bool> UpdateMediaAsync(int id, UpdateMediaDto media) => QuerySingleAsync<bool>("Media_Update", new { Id = id, media.MediaUrl, media.Type, media.ArticleId });
    public Task<bool> DeleteMediaAsync(int id) => QuerySingleAsync<bool>("Media_Delete", new { Id = id });
}
