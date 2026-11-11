using ArticlesAPI.Features.Auth.DTOs;
using ArticlesAPI.Features.Auth.Services;
using ArticlesAPI.Shared.Base;
using Microsoft.AspNetCore.Mvc;

namespace ArticlesAPI.Features.Auth.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : BaseController
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService) => _authService = authService;

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        => Ok(await _authService.LoginAsync(dto));
}
