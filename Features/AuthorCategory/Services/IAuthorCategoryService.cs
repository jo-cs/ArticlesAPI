using ArticlesAPI.Features.AuthorCategory.DTOs;
using ArticlesAPI.Shared.Results;
namespace ArticlesAPI.Features.AuthorCategory.Services;
public interface IAuthorCategoryService
{
    Task<ServiceResult<bool>> AddAuthorCategoryAsync(AddAuthorCategoryDto relation);
    Task<ServiceResult<IEnumerable<AuthorCategoryResponseDto>>> GetCategoriesByAuthorIdAsync(int authorId);
    Task<ServiceResult<bool>> DeleteAuthorCategoryAsync(int authorId, int categoryId);
}
