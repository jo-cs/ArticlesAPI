using ArticlesAPI.Features.Auth.DTOs;
using ArticlesAPI.Shared.Results;

namespace ArticlesAPI.Features.Auth.Services;

public interface IAuthService
{
    Task<ServiceResult<LoginResponseDto>> LoginAsync(LoginRequestDto dto);
}
