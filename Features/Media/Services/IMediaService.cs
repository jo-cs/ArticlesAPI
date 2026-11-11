using ArticlesAPI.Features.Media.DTOs;
using ArticlesAPI.Shared.Results;
namespace ArticlesAPI.Features.Media.Services;
public interface IMediaService
{
    Task<ServiceResult<int>> CreateMediaAsync(CreateMediaDto media);
    Task<ServiceResult<IEnumerable<MediaResponseDto>>> GetAllMediaAsync();
    Task<ServiceResult<MediaResponseDto>> GetMediaByIdAsync(int id);
    Task<ServiceResult<IEnumerable<MediaResponseDto>>> GetMediaByArticleIdAsync(int articleId);
    Task<ServiceResult<bool>> UpdateMediaAsync(int id, UpdateMediaDto media);
    Task<ServiceResult<bool>> DeleteMediaAsync(int id);
}
