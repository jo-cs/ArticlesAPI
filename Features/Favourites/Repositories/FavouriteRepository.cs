using System.Data;
using ArticlesAPI.Features.Favourites.DTOs;
using ArticlesAPI.Infrastructure.Data;
using Dapper;
namespace ArticlesAPI.Features.Favourites.Repositories;
public class FavouriteRepository : IFavouriteRepository
{
    private readonly DapperContext _context;
    public FavouriteRepository(DapperContext context) => _context = context;
    public async Task<bool> AddFavouriteAsync(FavouriteAddDto favourite)
    {
        using var connection = _context.CreateConnection();
        return await connection.QuerySingleAsync<bool>("Favourite_Add", new
        {
            favourite.UserId, favourite.ArticleId
        }, commandType: CommandType.StoredProcedure);
    }
    public async Task<IEnumerable<FavouriteResponseDto>> GetFavouritesByUserIdAsync(int userId)
    {
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<FavouriteResponseDto>("Favourite_GetByUserId", new
        {
            UserId = userId
        }, commandType: CommandType.StoredProcedure);
    }
    public async Task<bool> RemoveFavouriteAsync(int userId, int articleId)
    {
        using var connection = _context.CreateConnection();
        return await connection.QuerySingleAsync<bool>("Favourite_Remove", new
        {
            UserId = userId, ArticleId = articleId
        }, commandType: CommandType.StoredProcedure);
    }
}
