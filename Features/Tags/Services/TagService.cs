using ArticlesAPI.Features.Tags.DTOs;
using ArticlesAPI.Features.Tags.Repositories;
using ArticlesAPI.Shared.Results;
namespace ArticlesAPI.Features.Tags.Services;
public class TagService : ITagService
{
    private readonly ITagRepository _repository;
    public TagService(ITagRepository repository) => _repository = repository;
    public Task<ServiceResult<int>> CreateTagAsync(CreateTagDto tag) => ServiceResult<int>.FromAsync(_repository.CreateTagAsync(tag), "Tag creation failed.", 400);
    public Task<ServiceResult<IEnumerable<TagResponseDto>>> GetAllTagsAsync() => ServiceResult<IEnumerable<TagResponseDto>>.FromAsync(_repository.GetAllTagsAsync(), "Tags could not be retrieved.", 500);
    public Task<ServiceResult<TagResponseDto>> GetTagByIdAsync(int id) => ServiceResult<TagResponseDto>.FromAsync(_repository.GetTagByIdAsync(id), "Tag not found.");
    public Task<ServiceResult<IEnumerable<TagResponseDto>>> GetTagsByArticleIdAsync(int articleId) => ServiceResult<IEnumerable<TagResponseDto>>.FromAsync(_repository.GetTagsByArticleIdAsync(articleId), "Tags could not be retrieved.", 500);
    public Task<ServiceResult<bool>> UpdateTagAsync(int id, UpdateTagDto tag) => ServiceResult<bool>.FromAsync(_repository.UpdateTagAsync(id, tag), "Tag not found or update failed.");
    public Task<ServiceResult<bool>> DeleteTagAsync(int id) => ServiceResult<bool>.FromAsync(_repository.DeleteTagAsync(id), "Tag not found.");
}
