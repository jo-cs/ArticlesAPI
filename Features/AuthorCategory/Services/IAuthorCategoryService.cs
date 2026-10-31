using ArticlesAPI.Features.AuthorCategory.DTOs;
namespace ArticlesAPI.Features.AuthorCategory.Services;
public interface IAuthorCategoryService
{
    Task<bool> AddAuthorCategoryAsync(AddAuthorCategoryDto relation);
    Task<IEnumerable<AuthorCategoryResponseDto>> GetCategoriesByAuthorIdAsync(int authorId);
    Task<bool> DeleteAuthorCategoryAsync(int authorId, int categoryId);
}
