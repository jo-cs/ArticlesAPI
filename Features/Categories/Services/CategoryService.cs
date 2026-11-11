using ArticlesAPI.Features.Categories.DTOs;
using ArticlesAPI.Features.Categories.Repositories;
using ArticlesAPI.Shared.DTOs;
using ArticlesAPI.Shared.Results;

namespace ArticlesAPI.Features.Categories.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;
    public CategoryService(ICategoryRepository repository) => _repository = repository;

    public async Task<ServiceResult<int>> CreateCategoryAsync(CreateCategoryDto category)
        => ServiceResult<int>.Ok(await _repository.CreateCategoryAsync(category));

    public async Task<ServiceResult<IEnumerable<CategoryResponseDto>>> GetAllCategoriesAsync()
        => ServiceResult<IEnumerable<CategoryResponseDto>>.Ok(await _repository.GetAllCategoriesAsync());

    public async Task<ServiceResult<bool>> UpdateCategoryAsync(int id, UpdateCategoryDto category)
        => await _repository.UpdateCategoryAsync(id, category)
            ? ServiceResult<bool>.Ok(true)
            : ServiceResult<bool>.Failure("Category not found or update failed.", 404);

    public async Task<ServiceResult<bool>> DeleteCategoryAsync(int id)
        => await _repository.DeleteCategoryAsync(id)
            ? ServiceResult<bool>.Ok(true)
            : ServiceResult<bool>.Failure("Category not found or delete failed.", 404);

    public async Task<ServiceResult<PagedResponseDto<CategoryResponseDto>>> GetFilteredCategoriesAsync(CategoryFilterDto filter)
        => ServiceResult<PagedResponseDto<CategoryResponseDto>>.Ok(await _repository.GetFilteredCategoriesAsync(filter));
}
