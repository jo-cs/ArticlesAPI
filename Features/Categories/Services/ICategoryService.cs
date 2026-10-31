using ArticlesAPI.Features.Categories.DTOs;

namespace ArticlesAPI.Features.Categories.Services;

public interface ICategoryService
{
    Task<int> CreateCategoryAsync(CreateCategoryDto category);

    Task<IEnumerable<CategoryResponseDto>> GetAllCategoriesAsync();

    Task<CategoryResponseDto?> GetCategoryByIdAsync(int id);

    Task<bool> UpdateCategoryAsync(int id, UpdateCategoryDto category);

    Task<bool> DeleteCategoryAsync(int id);
}