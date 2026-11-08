using ArticlesAPI.Features.Categories.DTOs;
using ArticlesAPI.Features.Categories.Services;
using ArticlesAPI.Shared.Base;
using Microsoft.AspNetCore.Mvc;

namespace ArticlesAPI.Features.Categories.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : BaseController
{
    private readonly ICategoryService _service;

    public CategoryController(ICategoryService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategoryAsync(
        [FromBody] CreateCategoryDto category)
    {
        var categoryId = await _service.CreateCategoryAsync(category);

        return Ok(categoryId);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategoriesAsync()
    {
        var categories = await _service.GetAllCategoriesAsync();

        return Ok(categories);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCategoryAsync(
        [FromRoute] int id,
        [FromBody] UpdateCategoryDto category)
    {
        var success = await _service.UpdateCategoryAsync(id, category);

        return success ? Ok() : NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCategoryAsync(
        [FromRoute] int id)
    {
        var success = await _service.DeleteCategoryAsync(id);

        return success ? Ok() : NotFound();
    }

    [HttpGet("filtered")]
    public async Task<IActionResult> GetFilteredCategoriesAsync(
        [FromQuery] CategoryFilterDto filter)
    {
        var result =
            await _service.GetFilteredCategoriesAsync(filter);
        return Ok(result);
    }
}