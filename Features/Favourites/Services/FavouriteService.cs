using ArticlesAPI.Features.Favourites.DTOs;
using ArticlesAPI.Features.Favourites.Repositories;
using ArticlesAPI.Shared.Results;
namespace ArticlesAPI.Features.Favourites.Services;
public class FavouriteService : IFavouriteService
{
    private readonly IFavouriteRepository _repository;
    public FavouriteService(IFavouriteRepository repository) => _repository = repository;
    public Task<ServiceResult<bool>> AddFavouriteAsync(FavouriteAddDto favourite) => ServiceResult<bool>.FromAsync(_repository.AddFavouriteAsync(favourite), "Article is already in favourites.", 409);
    public Task<ServiceResult<IEnumerable<FavouriteResponseDto>>> GetFavouritesByUserIdAsync(int userId) => ServiceResult<IEnumerable<FavouriteResponseDto>>.FromAsync(_repository.GetFavouritesByUserIdAsync(userId), "Favourites could not be retrieved.", 500);
    public Task<ServiceResult<bool>> RemoveFavouriteAsync(int userId, int articleId) => ServiceResult<bool>.FromAsync(_repository.RemoveFavouriteAsync(userId, articleId), "Favourite not found.");
}
