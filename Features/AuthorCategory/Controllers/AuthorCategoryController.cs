using ArticlesAPI.Features.AuthorCategory.DTOs;
using ArticlesAPI.Features.AuthorCategory.Services;
using ArticlesAPI.Shared.Base;
using Microsoft.AspNetCore.Mvc;
namespace ArticlesAPI.Features.AuthorCategory.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthorCategoryController : BaseController
{
    private readonly IAuthorCategoryService _service;
    public AuthorCategoryController(IAuthorCategoryService service) => _service = service;
    [HttpPost] public async Task<IActionResult> AddAuthorCategoryAsync([FromBody] AddAuthorCategoryDto relation) => Ok(await _service.AddAuthorCategoryAsync(relation));
    [HttpGet("by-author/{authorId:int}")] public async Task<IActionResult> GetCategoriesByAuthorIdAsync([FromRoute] int authorId) => Ok(await _service.GetCategoriesByAuthorIdAsync(authorId));
    [HttpDelete("by-author/{authorId:int}/category/{categoryId:int}")] public async Task<IActionResult> DeleteAuthorCategoryAsync([FromRoute] int authorId, [FromRoute] int categoryId) => Ok(await _service.DeleteAuthorCategoryAsync(authorId, categoryId));
}
