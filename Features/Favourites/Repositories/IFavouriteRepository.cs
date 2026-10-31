using ArticlesAPI.Features.Favourites.DTOs;
namespace ArticlesAPI.Features.Favourites.Repositories;
public interface IFavouriteRepository
{
    Task<bool> AddFavouriteAsync(FavouriteAddDto favourite);
    Task<IEnumerable<FavouriteResponseDto>> GetFavouritesByUserIdAsync(int userId);
    Task<bool> RemoveFavouriteAsync(int userId, int articleId);
}
