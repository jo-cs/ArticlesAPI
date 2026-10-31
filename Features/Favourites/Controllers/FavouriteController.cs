using ArticlesAPI.Features.Favourites.DTOs;
using ArticlesAPI.Features.Favourites.Services;
using Microsoft.AspNetCore.Mvc;
namespace ArticlesAPI.Features.Favourites.Controllers;
[ApiController]
[Route("api/[controller]")]
public class FavouriteController : ControllerBase
{
    private readonly IFavouriteService _service;
    public FavouriteController(IFavouriteService service) => _service = service;
    [HttpPost]
    public async Task<IActionResult> AddFavouriteAsync([FromBody] FavouriteAddDto favourite)
    {
        var added = await _service.AddFavouriteAsync(favourite);
        return added ? Ok() : Conflict("This article is already in favourites.");
    }
    [HttpGet("by-user/{userId:int}")]
    public async Task<IActionResult> GetFavouritesByUserIdAsync([FromRoute] int userId) => Ok(await _service.GetFavouritesByUserIdAsync(userId));
    [HttpDelete("by-user/{userId:int}/article/{articleId:int}")]
    public async Task<IActionResult> RemoveFavouriteAsync([FromRoute] int userId, [FromRoute] int articleId)
        => await _service.RemoveFavouriteAsync(userId, articleId) ? NoContent() : NotFound();
}
