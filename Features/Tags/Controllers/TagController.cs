using ArticlesAPI.Features.Tags.DTOs;
using ArticlesAPI.Features.Tags.Services;
using ArticlesAPI.Shared.Base;
using Microsoft.AspNetCore.Mvc;
namespace ArticlesAPI.Features.Tags.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TagController : BaseController
{
    private readonly ITagService _service;
    public TagController(ITagService service) => _service = service;
    [HttpPost] public async Task<IActionResult> CreateTagAsync([FromBody] CreateTagDto tag) => Ok(await _service.CreateTagAsync(tag));
    [HttpGet] public async Task<IActionResult> GetAllTagsAsync() => Ok(await _service.GetAllTagsAsync());
    [HttpGet("{id:int}")] public async Task<IActionResult> GetTagByIdAsync([FromRoute] int id) => Ok(await _service.GetTagByIdAsync(id));
    [HttpGet("by-article/{articleId:int}")] public async Task<IActionResult> GetTagsByArticleIdAsync([FromRoute] int articleId) => Ok(await _service.GetTagsByArticleIdAsync(articleId));
    [HttpPut("{id:int}")] public async Task<IActionResult> UpdateTagAsync([FromRoute] int id, [FromBody] UpdateTagDto tag) => Ok(await _service.UpdateTagAsync(id, tag));
    [HttpDelete("{id:int}")] public async Task<IActionResult> DeleteTagAsync([FromRoute] int id) => Ok(await _service.DeleteTagAsync(id));
}
