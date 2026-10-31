using ArticlesAPI.Features.Authors.DTOs;
using ArticlesAPI.Features.Authors.Repositories;
namespace ArticlesAPI.Features.Authors.Services;
public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _repository;
    public AuthorService(IAuthorRepository repository) => _repository = repository;
    public Task<int> CreateAuthorAsync(CreateAuthorDto author) => _repository.CreateAuthorAsync(author);
    public Task<IEnumerable<AuthorResponseDto>> GetAllAuthorsAsync() => _repository.GetAllAuthorsAsync();
    public Task<AuthorResponseDto?> GetAuthorByIdAsync(int id) => _repository.GetAuthorByIdAsync(id);
    public Task<AuthorResponseDto?> GetAuthorByUserIdAsync(int userId) => _repository.GetAuthorByUserIdAsync(userId);
    public Task<bool> UpdateAuthorAsync(int id, UpdateAuthorDto author) => _repository.UpdateAuthorAsync(id, author);
    public Task<bool> DeleteAuthorAsync(int id) => _repository.DeleteAuthorAsync(id);
}
