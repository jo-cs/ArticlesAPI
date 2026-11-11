using ArticlesAPI.Features.Users.DTOs;
using ArticlesAPI.Shared.Results;

namespace ArticlesAPI.Features.Users.Services;

public interface IUserService
{
    Task<ServiceResult<int>> CreateUserAsync(CreateUserDto dto);
    Task<ServiceResult<UserResponseDto>> GetUserByIdAsync(int id);
    Task<ServiceResult<IEnumerable<UserResponseDto>>> GetAllUsersAsync(UserFilterDto filter);
    Task<ServiceResult<bool>> UpdateUserAsync(int id, UpdateUserDto dto);
    Task<ServiceResult<bool>> DeleteUserAsync(int id);
}
