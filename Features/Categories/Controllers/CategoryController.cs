using ArticlesAPI.Features.Categories.DTOs;
using ArticlesAPI.Features.Categories.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArticlesAPI.Features.Categories.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
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

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCategoryByIdAsync(
        [FromRoute] int id)
    {
        var category = await _service.GetCategoryByIdAsync(id);

        if (category is null)
        {
            return NotFound();
        }

        return Ok(category);
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
}