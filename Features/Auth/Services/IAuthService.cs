using ArticlesAPI.Features.Auth.DTOs;

namespace ArticlesAPI.Features.Auth.Services;

public interface IAuthService
{
    Task<LoginResponseDto?> LoginAsync(LoginRequestDto dto);
}