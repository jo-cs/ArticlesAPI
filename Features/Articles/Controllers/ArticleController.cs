
using ArticlesAPI.Features.Articles.Services;
using ArticlesAPI.Features.Articles.DTOs;
using ArticlesAPI.Shared.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ArticlesAPI.Features.Articles.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArticleController : BaseController
{
    private readonly IArticleService _service;

    public ArticleController(IArticleService service)
    {
        _service = service;
    }

    [Authorize(Policy = "Articles.Create")]
    [HttpPost]
    public async Task<IActionResult> CreateArticleAsync(
        [FromBody] CreateArticleDto create)
    {
        var result = await _service.CreateArticleAsync(create);

        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetArticleByIdAsync(
        [FromRoute] int id)
    {
        var result = await _service.GetArticleByIdAsync(id);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllArticlesAsync()
    {
        var result = await _service.GetAllArticlesAsync();

        return Ok(result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateArticles(
        [FromRoute] int id,
        [FromBody] UpdateArticleDto update)
    {
        var result = await _service.UpdateArticleAsync(id, update);

        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteArticleAsync(
        [FromRoute] int id)
    {
        var result = await _service.DeleteArticleAsync(id);

        return Ok(result);
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchArticlesAsync([FromQuery] string search)
    {
        var result = await _service.SearchArticlesAsync(search);
        return Ok(result);
    }

    [HttpGet("filtered")]
    public async Task<IActionResult> GetFilteredArticles(
        [FromQuery] ArticleFilterDto filter)
    {
        var result = await _service.GetFilteredArticlesAsync(filter);

        return Ok(result);
    }

    [HttpPost("with-relations")]
    public async Task<IActionResult> CreateArticleWithRelationsAsync(
        [FromBody] CreateArticleWithRelationsDto create)
    {
        var result = await _service.CreateArticleWithRelationsAsync(create);

        if (!result.Success)
            return Ok(result);

        return CreatedAtAction(
            nameof(GetArticleByIdAsync),
            new { id = result.Data },
            new { Id = result.Data });
    }
}
