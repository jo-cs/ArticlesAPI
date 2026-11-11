using ArticlesAPI.Features.Users.Models;
using ArticlesAPI.Infrastructure.Data;
using ArticlesAPI.Shared.Repositories;

namespace ArticlesAPI.Features.Users.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(DapperContext context) : base(context) { }

    public Task<int> CreateUserAsync(User user) => QuerySingleAsync<int>(
        "User_Create",
        new { user.FullName, user.Email, user.HashPassword, user.RoleId });

    public Task<User?> GetUserByIdAsync(int id) => QuerySingleOrDefaultAsync<User>(
        "User_GetById", new { Id = id });

    public Task<User?> GetUserByEmailAsync(string email) => QuerySingleOrDefaultAsync<User>(
        "User_GetByEmail", new { Email = email });

    public Task<IEnumerable<User>> GetAllUsersAsync() => QueryAsync<User>("User_GetAll");

    public async Task<bool> DeleteUserAsync(int id)
        => await QuerySingleAsync<int>("User_Delete", new { Id = id }) > 0;

    public async Task<bool> UpdateUserAsync(User user)
        => await QuerySingleAsync<int>("User_Update", new
        {
            user.Id,
            user.FullName,
            user.Email,
            user.HashPassword,
            user.RoleId
        }) > 0;
}
