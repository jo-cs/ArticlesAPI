using ArticlesAPI.Features.Users.DTOs;
using ArticlesAPI.Features.Users.Services;
using ArticlesAPI.Shared.Base;
using Microsoft.AspNetCore.Mvc;

namespace ArticlesAPI.Features.Users.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : BaseController
{
    private readonly IUserService _userService;
    public UserController(IUserService userService) => _userService = userService;

    [HttpPost]
    public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserDto dto)
        => Ok(await _userService.CreateUserAsync(dto));

    [HttpGet]
    public async Task<IActionResult> GetAllUsers([FromQuery] UserFilterDto filter)
        => Ok(await _userService.GetAllUsersAsync(filter));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById([FromRoute] int id)
        => Ok(await _userService.GetUserByIdAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUserAsync([FromRoute] int id, [FromBody] UpdateUserDto dto)
        => Ok(await _userService.UpdateUserAsync(id, dto));

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserAsync([FromRoute] int id)
        => Ok(await _userService.DeleteUserAsync(id));
}
