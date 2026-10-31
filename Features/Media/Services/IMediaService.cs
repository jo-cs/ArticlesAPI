using ArticlesAPI.Features.Media.DTOs;
namespace ArticlesAPI.Features.Media.Services;
public interface IMediaService
{
    Task<int> CreateMediaAsync(CreateMediaDto media);
    Task<IEnumerable<MediaResponseDto>> GetAllMediaAsync();
    Task<MediaResponseDto?> GetMediaByIdAsync(int id);
    Task<IEnumerable<MediaResponseDto>> GetMediaByArticleIdAsync(int articleId);
    Task<bool> UpdateMediaAsync(int id, UpdateMediaDto media);
    Task<bool> DeleteMediaAsync(int id);
}
