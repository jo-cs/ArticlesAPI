using ArticlesAPI.Features.Authors.DTOs;
using ArticlesAPI.Features.Authors.Services;
using ArticlesAPI.Shared.Base;
using Microsoft.AspNetCore.Mvc;
namespace ArticlesAPI.Features.Authors.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthorController : BaseController
{
    private readonly IAuthorService _service;
    public AuthorController(IAuthorService service) => _service = service;
    [HttpPost] public async Task<IActionResult> CreateAuthorAsync([FromBody] CreateAuthorDto author) => Ok(await _service.CreateAuthorAsync(author));
    [HttpGet] public async Task<IActionResult> GetAllAuthorsAsync() => Ok(await _service.GetAllAuthorsAsync());
    [HttpGet("{id:int}")] public async Task<IActionResult> GetAuthorByIdAsync([FromRoute] int id) => Ok(await _service.GetAuthorByIdAsync(id));
    [HttpGet("by-user/{userId:int}")] public async Task<IActionResult> GetAuthorByUserIdAsync([FromRoute] int userId) => Ok(await _service.GetAuthorByUserIdAsync(userId));
    [HttpPut("{id:int}")] public async Task<IActionResult> UpdateAuthorAsync([FromRoute] int id, [FromBody] UpdateAuthorDto author) => Ok(await _service.UpdateAuthorAsync(id, author));
    [HttpDelete("{id:int}")] public async Task<IActionResult> DeleteAuthorAsync([FromRoute] int id) => Ok(await _service.DeleteAuthorAsync(id));
}
