using ArticlesAPI.Features.Users.Models;

namespace ArticlesAPI.Features.Users.Repositories;

public interface IUserRepository
{
    Task<int> CreateUserAsync(User user);
    Task<User?> GetUserByIdAsync(int id);
    Task<User?> GetUserByEmailAsync(string email);
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task<bool> DeleteUserAsync(int id);
    Task<bool> UpdateUserAsync(User user);
}