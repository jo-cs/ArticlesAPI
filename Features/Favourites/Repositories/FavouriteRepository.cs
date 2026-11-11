using ArticlesAPI.Features.Favourites.DTOs;
using ArticlesAPI.Infrastructure.Data;
using ArticlesAPI.Shared.Repositories;
namespace ArticlesAPI.Features.Favourites.Repositories;
public class FavouriteRepository : BaseRepository, IFavouriteRepository
{
    public FavouriteRepository(DapperContext context) : base(context) { }
    public Task<bool> AddFavouriteAsync(FavouriteAddDto favourite) => QuerySingleAsync<bool>("Favourite_Add", new { favourite.UserId, favourite.ArticleId });
    public Task<IEnumerable<FavouriteResponseDto>> GetFavouritesByUserIdAsync(int userId) => QueryAsync<FavouriteResponseDto>("Favourite_GetByUserId", new { UserId = userId });
    public Task<bool> RemoveFavouriteAsync(int userId, int articleId) => QuerySingleAsync<bool>("Favourite_Remove", new { UserId = userId, ArticleId = articleId });
}
