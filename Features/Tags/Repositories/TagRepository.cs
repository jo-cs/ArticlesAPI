using ArticlesAPI.Features.Tags.DTOs;
using ArticlesAPI.Infrastructure.Data;
using ArticlesAPI.Shared.Repositories;
namespace ArticlesAPI.Features.Tags.Repositories;
public class TagRepository : BaseRepository, ITagRepository
{
    public TagRepository(DapperContext context) : base(context) { }
    public Task<int> CreateTagAsync(CreateTagDto tag) => QuerySingleAsync<int>("Tag_Create", new { tag.Title, tag.ArticleId });
    public Task<IEnumerable<TagResponseDto>> GetAllTagsAsync() => QueryAsync<TagResponseDto>("Tag_GetAll");
    public Task<TagResponseDto?> GetTagByIdAsync(int id) => QuerySingleOrDefaultAsync<TagResponseDto>("Tag_GetById", new { Id = id });
    public Task<IEnumerable<TagResponseDto>> GetTagsByArticleIdAsync(int articleId) => QueryAsync<TagResponseDto>("Tag_GetByArticleId", new { ArticleId = articleId });
    public Task<bool> UpdateTagAsync(int id, UpdateTagDto tag) => QuerySingleAsync<bool>("Tag_Update", new { Id = id, tag.Title });
    public Task<bool> DeleteTagAsync(int id) => QuerySingleAsync<bool>("Tag_Delete", new { Id = id });
}
