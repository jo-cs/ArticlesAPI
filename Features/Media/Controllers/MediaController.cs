using ArticlesAPI.Features.Media.DTOs;
using ArticlesAPI.Features.Media.Services;
using ArticlesAPI.Shared.Base;
using Microsoft.AspNetCore.Mvc;
namespace ArticlesAPI.Features.Media.Controllers;
[ApiController]
[Route("api/[controller]")]
public class MediaController : BaseController
{
    private readonly IMediaService _service;
    public MediaController(IMediaService service) => _service = service;
    [HttpPost] public async Task<IActionResult> CreateMediaAsync([FromBody] CreateMediaDto media) => Ok(await _service.CreateMediaAsync(media));
    [HttpGet] public async Task<IActionResult> GetAllMediaAsync() => Ok(await _service.GetAllMediaAsync());
    [HttpGet("{id:int}")] public async Task<IActionResult> GetMediaByIdAsync([FromRoute] int id) => Ok(await _service.GetMediaByIdAsync(id));
    [HttpGet("by-article/{articleId:int}")] public async Task<IActionResult> GetMediaByArticleIdAsync([FromRoute] int articleId) => Ok(await _service.GetMediaByArticleIdAsync(articleId));
    [HttpPut("{id:int}")] public async Task<IActionResult> UpdateMediaAsync([FromRoute] int id, [FromBody] UpdateMediaDto media) => Ok(await _service.UpdateMediaAsync(id, media));
    [HttpDelete("{id:int}")] public async Task<IActionResult> DeleteMediaAsync([FromRoute] int id) => Ok(await _service.DeleteMediaAsync(id));
}
