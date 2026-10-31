using ArticlesAPI.Features.Favourites.DTOs;
using ArticlesAPI.Features.Favourites.Repositories;
namespace ArticlesAPI.Features.Favourites.Services;
public class FavouriteService : IFavouriteService
{
    private readonly IFavouriteRepository _repository;
    public FavouriteService(IFavouriteRepository repository)
        => _repository = repository;
    public Task<bool> AddFavouriteAsync(FavouriteAddDto favourite)
        => _repository.AddFavouriteAsync(favourite);
    public Task<IEnumerable<FavouriteResponseDto>> GetFavouritesByUserIdAsync(int userId)
        => _repository.GetFavouritesByUserIdAsync(userId);
    public Task<bool> RemoveFavouriteAsync(int userId, int articleId)
        => _repository.RemoveFavouriteAsync(userId, articleId);
}
