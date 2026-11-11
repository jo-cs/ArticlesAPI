using ArticlesAPI.Features.AuthorCategory.DTOs;
using ArticlesAPI.Infrastructure.Data;
using ArticlesAPI.Shared.Repositories;
namespace ArticlesAPI.Features.AuthorCategory.Repositories;
public class AuthorCategoryRepository : BaseRepository, IAuthorCategoryRepository
{
    public AuthorCategoryRepository(DapperContext context) : base(context) { }
    public Task<bool> AddAuthorCategoryAsync(AddAuthorCategoryDto relation) => QuerySingleAsync<bool>("AuthorCategory_Add", new { relation.AuthorId, relation.CategoryId });
    public Task<IEnumerable<AuthorCategoryResponseDto>> GetCategoriesByAuthorIdAsync(int authorId) => QueryAsync<AuthorCategoryResponseDto>("AuthorCategory_GetByAuthorId", new { AuthorId = authorId });
    public Task<bool> DeleteAuthorCategoryAsync(int authorId, int categoryId) => QuerySingleAsync<bool>("AuthorCategory_Delete", new { AuthorId = authorId, CategoryId = categoryId });
}
