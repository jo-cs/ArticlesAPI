using ArticlesAPI.Features.Tags.DTOs;
namespace ArticlesAPI.Features.Tags.Repositories;
public interface ITagRepository
{
    Task<int> CreateTagAsync(CreateTagDto tag);
    Task<IEnumerable<TagResponseDto>> GetAllTagsAsync();
    Task<TagResponseDto?> GetTagByIdAsync(int id);
    Task<IEnumerable<TagResponseDto>> GetTagsByArticleIdAsync(int articleId);
    Task<bool> UpdateTagAsync(int id, UpdateTagDto tag);
    Task<bool> DeleteTagAsync(int id);
}
