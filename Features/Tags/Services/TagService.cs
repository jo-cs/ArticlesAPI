using ArticlesAPI.Features.Tags.DTOs;
using ArticlesAPI.Features.Tags.Repositories;
namespace ArticlesAPI.Features.Tags.Services;
public class TagService : ITagService
{
    private readonly ITagRepository _repository;
    public TagService(ITagRepository repository) => _repository = repository;
    public Task<int> CreateTagAsync(CreateTagDto tag) => _repository.CreateTagAsync(tag);
    public Task<IEnumerable<TagResponseDto>> GetAllTagsAsync() => _repository.GetAllTagsAsync();
    public Task<TagResponseDto?> GetTagByIdAsync(int id) => _repository.GetTagByIdAsync(id);
    public Task<IEnumerable<TagResponseDto>> GetTagsByArticleIdAsync(int articleId) => _repository.GetTagsByArticleIdAsync(articleId);
    public Task<bool> UpdateTagAsync(int id, UpdateTagDto tag) => _repository.UpdateTagAsync(id, tag);
    public Task<bool> DeleteTagAsync(int id) => _repository.DeleteTagAsync(id);
}
