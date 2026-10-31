using ArticlesAPI.Features.Media.DTOs;
using ArticlesAPI.Features.Media.Repositories;
namespace ArticlesAPI.Features.Media.Services;
public class MediaService : IMediaService
{
    private readonly IMediaRepository _repository;
    public MediaService(IMediaRepository repository)
        => _repository = repository;
    
    
    public Task<int> CreateMediaAsync(CreateMediaDto media)
        => _repository.CreateMediaAsync(media);
    
    public Task<IEnumerable<MediaResponseDto>> GetAllMediaAsync() 
        => _repository.GetAllMediaAsync();
    
    public Task<MediaResponseDto?> GetMediaByIdAsync(int id)
        => _repository.GetMediaByIdAsync(id);
    
    public Task<IEnumerable<MediaResponseDto>> GetMediaByArticleIdAsync(int articleId)
        => _repository.GetMediaByArticleIdAsync(articleId);
    
    public Task<bool> UpdateMediaAsync(int id, UpdateMediaDto media)
        => _repository.UpdateMediaAsync(id, media);
    
    public Task<bool> DeleteMediaAsync(int id)
        => _repository.DeleteMediaAsync(id);
}
