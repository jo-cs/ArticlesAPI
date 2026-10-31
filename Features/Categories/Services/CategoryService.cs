using ArticlesAPI.Features.Categories.DTOs;
using ArticlesAPI.Features.Categories.Repositories;

namespace ArticlesAPI.Features.Categories.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;
    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }
    
    public Task<int> CreateCategoryAsync(CreateCategoryDto category)
    {
        return _repository.CreateCategoryAsync(category);
    }

    public Task<IEnumerable<CategoryResponseDto>> GetAllCategoriesAsync()
    {
        return _repository.GetAllCategoriesAsync();
    }

    public Task<CategoryResponseDto?> GetCategoryByIdAsync(int id)
    {
        return _repository.GetCategoryByIdAsync(id);
    }

    public Task<bool> UpdateCategoryAsync(int id, UpdateCategoryDto category)
    {
        return _repository.UpdateCategoryAsync(id, category);
    }

    public Task<bool> DeleteCategoryAsync(int id)
    {
        return _repository.DeleteCategoryAsync(id);
    }
}