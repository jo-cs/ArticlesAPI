using System.Data;
using ArticlesAPI.Features.Authors.DTOs;
using ArticlesAPI.Infrastructure.Data;
using Dapper;
namespace ArticlesAPI.Features.Authors.Repositories;
public class AuthorRepository : IAuthorRepository
{
    private readonly DapperContext _context;
    public AuthorRepository(DapperContext context) => _context = context;

    public async Task<int> CreateAuthorAsync(CreateAuthorDto author)
    {
        using var connection = _context.CreateConnection();
        return await connection.QuerySingleAsync<int>("Author_Create", new
        {
            author.LiteraryName,
            author.DateOfBirth,
            author.UserId
        }, commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<AuthorResponseDto>> GetAllAuthorsAsync()
    {
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<AuthorResponseDto>("Author_GetAll", commandType: CommandType.StoredProcedure);
    }

    public async Task<AuthorResponseDto?> GetAuthorByIdAsync(int id)
    {
        using var connection = _context.CreateConnection();
        return await connection.QuerySingleOrDefaultAsync<AuthorResponseDto>("Author_GetById", new { Id = id }, commandType: CommandType.StoredProcedure);
    }

    public async Task<AuthorResponseDto?> GetAuthorByUserIdAsync(int userId)
    {
        using var connection = _context.CreateConnection();
        return await connection.QuerySingleOrDefaultAsync<AuthorResponseDto>("Author_GetByUserId", new { UserId = userId }, commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> UpdateAuthorAsync(int id, UpdateAuthorDto author)
    {
        using var connection = _context.CreateConnection();
        return await connection.QuerySingleAsync<bool>("Author_Update", new { Id = id, author.LiteraryName, author.DateOfBirth }, commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> DeleteAuthorAsync(int id)
    {
        using var connection = _context.CreateConnection();
        return await connection.QuerySingleAsync<bool>("Author_Delete", new { Id = id }, commandType: CommandType.StoredProcedure);
    }
}
