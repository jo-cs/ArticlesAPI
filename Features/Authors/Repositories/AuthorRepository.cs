using ArticlesAPI.Features.Authors.DTOs;
using ArticlesAPI.Infrastructure.Data;
using ArticlesAPI.Shared.Repositories;
namespace ArticlesAPI.Features.Authors.Repositories;
public class AuthorRepository : BaseRepository, IAuthorRepository
{
    public AuthorRepository(DapperContext context) : base(context) { }
    public Task<int> CreateAuthorAsync(CreateAuthorDto author) => QuerySingleAsync<int>("Author_Create", new { author.LiteraryName, author.DateOfBirth, author.UserId });
    public Task<IEnumerable<AuthorResponseDto>> GetAllAuthorsAsync() => QueryAsync<AuthorResponseDto>("Author_GetAll");
    public Task<AuthorResponseDto?> GetAuthorByIdAsync(int id) => QuerySingleOrDefaultAsync<AuthorResponseDto>("Author_GetById", new { Id = id });
    public Task<AuthorResponseDto?> GetAuthorByUserIdAsync(int userId) => QuerySingleOrDefaultAsync<AuthorResponseDto>("Author_GetByUserId", new { UserId = userId });
    public Task<bool> UpdateAuthorAsync(int id, UpdateAuthorDto author) => QuerySingleAsync<bool>("Author_Update", new { Id = id, author.LiteraryName, author.DateOfBirth });
    public Task<bool> DeleteAuthorAsync(int id) => QuerySingleAsync<bool>("Author_Delete", new { Id = id });
}
