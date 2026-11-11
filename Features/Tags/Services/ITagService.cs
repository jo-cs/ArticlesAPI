using ArticlesAPI.Features.Tags.DTOs;
using ArticlesAPI.Shared.Results;
namespace ArticlesAPI.Features.Tags.Services;
public interface ITagService
{
    Task<ServiceResult<int>> CreateTagAsync(CreateTagDto tag);
    Task<ServiceResult<IEnumerable<TagResponseDto>>> GetAllTagsAsync();
    Task<ServiceResult<TagResponseDto>> GetTagByIdAsync(int id);
    Task<ServiceResult<IEnumerable<TagResponseDto>>> GetTagsByArticleIdAsync(int articleId);
    Task<ServiceResult<bool>> UpdateTagAsync(int id, UpdateTagDto tag);
    Task<ServiceResult<bool>> DeleteTagAsync(int id);
}
