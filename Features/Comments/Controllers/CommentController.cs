using ArticlesAPI.Features.Comments.DTOs;
using ArticlesAPI.Features.Comments.Services;
using ArticlesAPI.Shared.Base;
using Microsoft.AspNetCore.Mvc;
namespace ArticlesAPI.Features.Comments.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CommentController : BaseController
{
    private readonly ICommentService _service;
    public CommentController(ICommentService service) => _service = service;
    [HttpPost] public async Task<IActionResult> CreateCommentAsync([FromBody] CreateCommentDto comment) => Ok(await _service.CreateCommentAsync(comment));
    [HttpGet("{id:int}")] public async Task<IActionResult> GetCommentByIdAsync([FromRoute] int id) => Ok(await _service.GetCommentByIdAsync(id));
    [HttpGet("by-article/{articleId:int}")] public async Task<IActionResult> GetCommentsByArticleIdAsync([FromRoute] int articleId) => Ok(await _service.GetCommentsByArticleIdAsync(articleId));
    [HttpGet("by-user/{userId:int}")] public async Task<IActionResult> GetCommentsByUserIdAsync([FromRoute] int userId) => Ok(await _service.GetCommentsByUserIdAsync(userId));
    [HttpPut("{id:int}")] public async Task<IActionResult> UpdateCommentAsync([FromRoute] int id, [FromBody] UpdateCommentDto comment) => Ok(await _service.UpdateCommentAsync(id, comment));
    [HttpDelete("{id:int}")] public async Task<IActionResult> DeleteCommentAsync([FromRoute] int id) => Ok(await _service.DeleteCommentAsync(id));
}
