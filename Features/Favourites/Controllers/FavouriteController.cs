using ArticlesAPI.Features.Favourites.DTOs;
using ArticlesAPI.Features.Favourites.Services;
using ArticlesAPI.Shared.Base;
using Microsoft.AspNetCore.Mvc;
namespace ArticlesAPI.Features.Favourites.Controllers;
[ApiController]
[Route("api/[controller]")]
public class FavouriteController : BaseController
{
    private readonly IFavouriteService _service;
    public FavouriteController(IFavouriteService service) => _service = service;
    [HttpPost] public async Task<IActionResult> AddFavouriteAsync([FromBody] FavouriteAddDto favourite) => Ok(await _service.AddFavouriteAsync(favourite));
    [HttpGet("by-user/{userId:int}")] public async Task<IActionResult> GetFavouritesByUserIdAsync([FromRoute] int userId) => Ok(await _service.GetFavouritesByUserIdAsync(userId));
    [HttpDelete("by-user/{userId:int}/article/{articleId:int}")] public async Task<IActionResult> RemoveFavouriteAsync([FromRoute] int userId, [FromRoute] int articleId) => Ok(await _service.RemoveFavouriteAsync(userId, articleId));
}
