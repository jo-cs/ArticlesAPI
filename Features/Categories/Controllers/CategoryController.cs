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
    public CategoryController(ICategoryService service) => _service = service;
    [HttpPost] public async Task<IActionResult> CreateCategoryAsync([FromBody] CreateCategoryDto category) => Ok(await _service.CreateCategoryAsync(category));
    [HttpGet] public async Task<IActionResult> GetAllCategoriesAsync() => Ok(await _service.GetAllCategoriesAsync());
    [HttpPut("{id:int}")] public async Task<IActionResult> UpdateCategoryAsync([FromRoute] int id, [FromBody] UpdateCategoryDto category) => Ok(await _service.UpdateCategoryAsync(id, category));
    [HttpDelete("{id:int}")] public async Task<IActionResult> DeleteCategoryAsync([FromRoute] int id) => Ok(await _service.DeleteCategoryAsync(id));
    [HttpGet("filtered")] public async Task<IActionResult> GetFilteredCategoriesAsync([FromQuery] CategoryFilterDto filter) => Ok(await _service.GetFilteredCategoriesAsync(filter));
}
