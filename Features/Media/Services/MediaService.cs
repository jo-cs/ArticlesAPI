using ArticlesAPI.Features.Media.DTOs;
using ArticlesAPI.Features.Media.Repositories;
using ArticlesAPI.Shared.Results;
namespace ArticlesAPI.Features.Media.Services;
public class MediaService : IMediaService
{
    private readonly IMediaRepository _repository;
    public MediaService(IMediaRepository repository) => _repository = repository;
    public Task<ServiceResult<int>> CreateMediaAsync(CreateMediaDto media) => ServiceResult<int>.FromAsync(_repository.CreateMediaAsync(media), "Media creation failed.", 400);
    public Task<ServiceResult<IEnumerable<MediaResponseDto>>> GetAllMediaAsync() => ServiceResult<IEnumerable<MediaResponseDto>>.FromAsync(_repository.GetAllMediaAsync(), "Media could not be retrieved.", 500);
    public Task<ServiceResult<MediaResponseDto>> GetMediaByIdAsync(int id) => ServiceResult<MediaResponseDto>.FromAsync(_repository.GetMediaByIdAsync(id), "Media not found.");
    public Task<ServiceResult<IEnumerable<MediaResponseDto>>> GetMediaByArticleIdAsync(int articleId) => ServiceResult<IEnumerable<MediaResponseDto>>.FromAsync(_repository.GetMediaByArticleIdAsync(articleId), "Media could not be retrieved.", 500);
    public Task<ServiceResult<bool>> UpdateMediaAsync(int id, UpdateMediaDto media) => ServiceResult<bool>.FromAsync(_repository.UpdateMediaAsync(id, media), "Media not found or update failed.");
    public Task<ServiceResult<bool>> DeleteMediaAsync(int id) => ServiceResult<bool>.FromAsync(_repository.DeleteMediaAsync(id), "Media not found.");
}
