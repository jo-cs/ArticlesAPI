using System.Data;
using ArticlesAPI.Features.Users.Models;
using Dapper;
using ArticlesAPI.Infrastructure.Data;

namespace ArticlesAPI.Features.Users.Repositories;

public class UserRepository : IUserRepository
{
    
    private readonly DapperContext  _context;
    
    public UserRepository(DapperContext context)
    {
        _context = context;
    }
    
    public async Task<int> CreateUserAsync(User user)
    {
        using var connection = _context.CreateConnection();

        var userId = await connection.QuerySingleAsync<int>(
            "User_Create",
            new
            {
                FullName=user.FullName,
                Email=user.Email,
                HashPassword=user.HashPassword,
                RoleId=user.RoleId
            },
            commandType: CommandType.StoredProcedure
        );

        return userId;
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        using var connection = _context.CreateConnection();

        var user = await connection.QuerySingleOrDefaultAsync<User>(
            "User_GetById",
            new{Id=id},
            commandType: CommandType.StoredProcedure);
        return user;
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        using var connection = _context.CreateConnection();
        
        var user = await connection.QuerySingleOrDefaultAsync<User>(
            "User_GetByEmail",
            new{Email = email},
            commandType: CommandType.StoredProcedure);
            return user;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        using var connection = _context.CreateConnection();
        
        var users = await connection.QueryAsync<User>(
            "User_GetAll",
            commandType: CommandType.StoredProcedure
            );
        return  users;
    }


    public async Task<bool> DeleteUserAsync(int id)
    {
        using var connection = _context.CreateConnection();

        var rowsAffected = await connection.QuerySingleAsync<int>(
            "User_Delete",
            new { Id = id },
            commandType: CommandType.StoredProcedure);

        return rowsAffected > 0;
    }



    public async Task<bool> UpdateUserAsync(User user)
    {
        using var connection = _context.CreateConnection();

        var rowsAffected = await connection.QuerySingleAsync<int>(
            "User_Update",
            new
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                HashPassword = user.HashPassword,
                RoleId = user.RoleId
            },
            commandType: CommandType.StoredProcedure);

        return rowsAffected > 0;
    }

}