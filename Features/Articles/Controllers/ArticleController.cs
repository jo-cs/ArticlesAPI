using ArticlesAPI.Features.Articles.Services;
using Microsoft.AspNetCore.Mvc;
using ArticlesAPI.Features.Articles.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace ArticlesAPI.Features.Articles.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArticleController : ControllerBase
{
    private readonly IArticleService _service;
    public ArticleController(IArticleService service)
    {
        _service = service;
    }
    [Authorize(Policy = "Articles.Create")]
    [HttpPost]
    public async Task<IActionResult> CreateArticleAsync([FromBody]CreateArticleDto create)
    {
        var articleId = await _service.CreateArticleAsync(create);
        return Ok(new { id = articleId });
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetArticleByIdAsync([FromRoute] int id)
    {
        var article = await _service.GetArticleByIdAsync(id);
        return Ok(article);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllArticlesAsync()
    {
        var articles = await _service.GetAllArticlesAsync();
        return Ok(articles);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateArticles([FromRoute]int id, [FromBody]UpdateArticleDto update)
    {
        var success = await _service.UpdateArticleAsync(id,update);
        return success ? Ok() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArticleAsync([FromRoute] int id)
    {
        var success = await _service.DeleteArticleAsync(id);
        return success ? Ok() : NotFound();
    }
    
    [HttpGet("search")]
    public async Task<IActionResult> SearchArticlesAsync(
        [FromQuery] string search)
    {
        if (string.IsNullOrWhiteSpace(search))
        {
            return BadRequest("Search term is required.");
        }

        var articles = await _service.SearchArticlesAsync(search);

        return Ok(articles);
    }
}