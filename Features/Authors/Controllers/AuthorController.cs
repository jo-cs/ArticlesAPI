using ArticlesAPI.Features.Authors.DTOs;
using ArticlesAPI.Features.Authors.Services;
using Microsoft.AspNetCore.Mvc;
namespace ArticlesAPI.Features.Authors.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _service;
    public AuthorController(IAuthorService service) => _service = service;

    [HttpPost]
    public async Task<IActionResult> CreateAuthorAsync([FromBody] CreateAuthorDto author)
        => Ok(await _service.CreateAuthorAsync(author));

    [HttpGet]
    public async Task<IActionResult> GetAllAuthorsAsync()
        => Ok(await _service.GetAllAuthorsAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAuthorByIdAsync([FromRoute] int id)
    {
        var author = await _service.GetAuthorByIdAsync(id);
        return author is null ? NotFound() : Ok(author);
    }

    [HttpGet("by-user/{userId:int}")]
    public async Task<IActionResult> GetAuthorByUserIdAsync([FromRoute] int userId)
    {
        var author = await _service.GetAuthorByUserIdAsync(userId);
        return author is null ? NotFound() : Ok(author);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAuthorAsync([FromRoute] int id, [FromBody] UpdateAuthorDto author)
        => await _service.UpdateAuthorAsync(id, author) ? NoContent() : NotFound();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAuthorAsync([FromRoute] int id)
        => await _service.DeleteAuthorAsync(id) ? NoContent() : NotFound();
}
