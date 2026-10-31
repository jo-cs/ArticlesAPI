using System.Data;
using ArticlesAPI.Features.Categories.DTOs;
using ArticlesAPI.Infrastructure.Data;
using Dapper;

namespace ArticlesAPI.Features.Categories.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly DapperContext _context;

    public CategoryRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<int> CreateCategoryAsync(CreateCategoryDto category)
    {
        using var connection = _context.CreateConnection();

        var categoryId = await connection.QuerySingleAsync<int>(
            "Category_Create",
            new
            {
                Name = category.Name,
                Description = category.Description
            },
            commandType: CommandType.StoredProcedure
        );

        return categoryId;
    }

    public async Task<IEnumerable<CategoryResponseDto>> GetAllCategoriesAsync()
    {
        using var connection = _context.CreateConnection();

        var categories = await connection.QueryAsync<CategoryResponseDto>(
            "Category_GetAll",
            commandType: CommandType.StoredProcedure
        );

        return categories;
    }

    public async Task<CategoryResponseDto?> GetCategoryByIdAsync(int id)
    {
        using var connection = _context.CreateConnection();

        var category = await connection.QuerySingleOrDefaultAsync<CategoryResponseDto>(
            "Category_GetById",
            new { Id = id },
            commandType: CommandType.StoredProcedure
        );

        return category;
    }

    public async Task<bool> UpdateCategoryAsync(int id, UpdateCategoryDto category)
    {
        using var connection = _context.CreateConnection();

        var success = await connection.QuerySingleAsync<bool>(
            "Category_Update",
            new
            {
                Id = id,
                Name = category.Name,
                Description = category.Description
            },
            commandType: CommandType.StoredProcedure
        );

        return success;
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        using var connection = _context.CreateConnection();

        var success = await connection.QuerySingleAsync<bool>(
            "Category_Delete",
            new { Id = id },
            commandType: CommandType.StoredProcedure
        );

        return success;
    }
}