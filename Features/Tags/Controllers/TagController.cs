using ArticlesAPI.Features.Tags.DTOs;
using ArticlesAPI.Features.Tags.Services;
using Microsoft.AspNetCore.Mvc;
namespace ArticlesAPI.Features.Tags.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TagController : ControllerBase
{
    private readonly ITagService _service;
    public TagController(ITagService service) => _service = service;
    [HttpPost]
    public async Task<IActionResult> CreateTagAsync([FromBody] CreateTagDto tag) => Ok(await _service.CreateTagAsync(tag));
    [HttpGet]
    public async Task<IActionResult> GetAllTagsAsync() => Ok(await _service.GetAllTagsAsync());
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetTagByIdAsync([FromRoute] int id)
    {
        var tag = await _service.GetTagByIdAsync(id);
        return tag is null ? NotFound() : Ok(tag);
    }
    [HttpGet("by-article/{articleId:int}")]
    public async Task<IActionResult> GetTagsByArticleIdAsync([FromRoute] int articleId) => Ok(await _service.GetTagsByArticleIdAsync(articleId));
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateTagAsync([FromRoute] int id, [FromBody] UpdateTagDto tag) => await _service.UpdateTagAsync(id, tag) ? NoContent() : NotFound();
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteTagAsync([FromRoute] int id) => await _service.DeleteTagAsync(id) ? NoContent() : NotFound();
}
