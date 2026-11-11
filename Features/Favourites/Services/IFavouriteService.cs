using ArticlesAPI.Features.Favourites.DTOs;
using ArticlesAPI.Shared.Results;
namespace ArticlesAPI.Features.Favourites.Services;
public interface IFavouriteService
{
    Task<ServiceResult<bool>> AddFavouriteAsync(FavouriteAddDto favourite);
    Task<ServiceResult<IEnumerable<FavouriteResponseDto>>> GetFavouritesByUserIdAsync(int userId);
    Task<ServiceResult<bool>> RemoveFavouriteAsync(int userId, int articleId);
}
