using ArticlesAPI.Features.Categories.DTOs;
using ArticlesAPI.Infrastructure.Data;
using ArticlesAPI.Shared.DTOs;
using ArticlesAPI.Shared.Repositories;

namespace ArticlesAPI.Features.Categories.Repositories;

public class CategoryRepository :BaseRepository, ICategoryRepository
{
    public CategoryRepository(DapperContext context)
        : base(context)
    {
    }

    public async Task<int> CreateCategoryAsync(CreateCategoryDto category)
    {
        var parameters = new
        {
            Name = category.Name,
            Description = category.Description
        };

        return await QuerySingleAsync<int>(
            "Category_Create",
            parameters
        );
    }

    public async Task<IEnumerable<CategoryResponseDto>> GetAllCategoriesAsync()
    {
        return await QueryAsync<CategoryResponseDto>(
            "Category_GetAll"
        );
    }


    public async Task<bool> UpdateCategoryAsync(int id, UpdateCategoryDto category)
    {
        var parameters = new
        {
            Id = id,
            Name = category.Name,
            Description = category.Description
        };

        return await QuerySingleAsync<bool>(
            "Category_Update",
            parameters
        );
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        return await QuerySingleAsync<bool>(
            "Category_Delete",
            new { Id = id }
        );
    }
    
    public Task<PagedResponseDto<CategoryResponseDto>> GetFilteredCategoriesAsync(
        CategoryFilterDto filter)
    {
        var parameters = new
        {
            filter.Search,
            filter.SortBy,
            filter.SortOrder,
            filter.PageNumber,
            filter.PageSize
        };

        return QueryMultipleAsync(
            "Category_GetFiltered",
            parameters,
            async multi =>
            {
                var totalCount = await multi.ReadSingleAsync<int>();

                var items = (await multi.ReadAsync<CategoryResponseDto>())
                    .ToList();

                return new PagedResponseDto<CategoryResponseDto>
                {
                    Items = items,
                    TotalCount = totalCount,
                    PageNumber = filter.PageNumber,
                    PageSize = filter.PageSize
                };
            }
        );
    }
}