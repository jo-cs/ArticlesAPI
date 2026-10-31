using System.Data;
using ArticlesAPI.Features.AuthorCategory.DTOs;
using ArticlesAPI.Infrastructure.Data;
using Dapper;
namespace ArticlesAPI.Features.AuthorCategory.Repositories;
public class AuthorCategoryRepository : IAuthorCategoryRepository
{
    private readonly DapperContext _context;
    public AuthorCategoryRepository(DapperContext context) => _context = context;
    public async Task<bool> AddAuthorCategoryAsync(AddAuthorCategoryDto relation)
    {
        using var connection = _context.CreateConnection();
        return await connection.QuerySingleAsync<bool>("AuthorCategory_Add", new { relation.AuthorId, relation.CategoryId }, commandType: CommandType.StoredProcedure);
    }
    public async Task<IEnumerable<AuthorCategoryResponseDto>> GetCategoriesByAuthorIdAsync(int authorId)
    {
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<AuthorCategoryResponseDto>("AuthorCategory_GetByAuthorId", new { AuthorId = authorId }, commandType: CommandType.StoredProcedure);
    }
    public async Task<bool> DeleteAuthorCategoryAsync(int authorId, int categoryId)
    {
        using var connection = _context.CreateConnection();
        return await connection.QuerySingleAsync<bool>("AuthorCategory_Delete", new { AuthorId = authorId, CategoryId = categoryId }, commandType: CommandType.StoredProcedure);
    }
}
