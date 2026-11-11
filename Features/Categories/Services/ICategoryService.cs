using ArticlesAPI.Features.Categories.DTOs;
using ArticlesAPI.Shared.DTOs;
using ArticlesAPI.Shared.Results;

namespace ArticlesAPI.Features.Categories.Services;

public interface ICategoryService
{
    Task<ServiceResult<int>> CreateCategoryAsync(CreateCategoryDto category);
    Task<ServiceResult<IEnumerable<CategoryResponseDto>>> GetAllCategoriesAsync();
    Task<ServiceResult<bool>> UpdateCategoryAsync(int id, UpdateCategoryDto category);
    Task<ServiceResult<bool>> DeleteCategoryAsync(int id);
    Task<ServiceResult<PagedResponseDto<CategoryResponseDto>>> GetFilteredCategoriesAsync(CategoryFilterDto filter);
}
