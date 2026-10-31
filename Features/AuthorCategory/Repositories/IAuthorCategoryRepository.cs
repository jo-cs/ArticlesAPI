using ArticlesAPI.Features.AuthorCategory.DTOs;
namespace ArticlesAPI.Features.AuthorCategory.Repositories;
public interface IAuthorCategoryRepository
{
    Task<bool> AddAuthorCategoryAsync(AddAuthorCategoryDto relation);
    Task<IEnumerable<AuthorCategoryResponseDto>> GetCategoriesByAuthorIdAsync(int authorId);
    Task<bool> DeleteAuthorCategoryAsync(int authorId, int categoryId);
}
