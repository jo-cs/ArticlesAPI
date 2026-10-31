using Microsoft.AspNetCore.Mvc;
using ArticlesAPI.Features.Users.DTOs;
using ArticlesAPI.Features.Users.Services;

namespace ArticlesAPI.Features.Users.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserDto dto)
    {
        var userId = await _userService.CreateUserAsync(dto);
        return Ok(userId);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers([FromQuery] UserFilterDto filter)
    {
        var users = await _userService.GetAllUsersAsync(filter);

        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById([FromRoute] int id)
    {
        var userId = await _userService.GetUserByIdAsync(id);

        if (userId == null)
            return NotFound();

        return Ok(userId);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUserAsync(
        [FromRoute] int id,
        [FromBody] UpdateUserDto dto)
    {
        var updated = await _userService.UpdateUserAsync(id, dto);

        if (!updated)
            return NotFound();
        return Ok(updated);
    }


[HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserAsync([FromRoute]int id)
    {
        var deleted = await _userService.DeleteUserAsync(id);
        if (!deleted)
            return NotFound();
        return NoContent();
    }
}