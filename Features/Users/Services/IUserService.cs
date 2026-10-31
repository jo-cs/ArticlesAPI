using ArticlesAPI.Features.Users.DTOs;

namespace ArticlesAPI.Features.Users.Services;

public interface IUserService
{
    Task<int> CreateUserAsync(CreateUserDto dto);

    Task<UserResponseDto?> GetUserByIdAsync(int id);

    Task<IEnumerable<UserResponseDto>> GetAllUsersAsync(
        UserFilterDto filter);

    Task<bool> UpdateUserAsync(int id, UpdateUserDto dto);

    Task<bool> DeleteUserAsync(int id);
}