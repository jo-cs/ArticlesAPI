using ArticlesAPI.Features.Categories.DTOs;
using ArticlesAPI.Shared.DTOs;

namespace ArticlesAPI.Features.Categories.Repositories;

public interface ICategoryRepository
{
    Task<int> CreateCategoryAsync(CreateCategoryDto category);

    Task<IEnumerable<CategoryResponseDto>> GetAllCategoriesAsync();

    Task<bool> UpdateCategoryAsync(int id, UpdateCategoryDto category);

    Task<bool> DeleteCategoryAsync(int id);
    
    Task<PagedResponseDto<CategoryResponseDto>> GetFilteredCategoriesAsync(
        CategoryFilterDto filter);
}