using ArticlesAPI.Features.Authors.DTOs;
using ArticlesAPI.Features.Authors.Repositories;
using ArticlesAPI.Shared.Results;
namespace ArticlesAPI.Features.Authors.Services;
public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _repository;
    public AuthorService(IAuthorRepository repository) => _repository = repository;
    public Task<ServiceResult<int>> CreateAuthorAsync(CreateAuthorDto author) => ServiceResult<int>.FromAsync(_repository.CreateAuthorAsync(author), "Author creation failed.", 400);
    public Task<ServiceResult<IEnumerable<AuthorResponseDto>>> GetAllAuthorsAsync() => ServiceResult<IEnumerable<AuthorResponseDto>>.FromAsync(_repository.GetAllAuthorsAsync(), "Authors could not be retrieved.", 500);
    public Task<ServiceResult<AuthorResponseDto>> GetAuthorByIdAsync(int id) => ServiceResult<AuthorResponseDto>.FromAsync(_repository.GetAuthorByIdAsync(id), "Author not found.");
    public Task<ServiceResult<AuthorResponseDto>> GetAuthorByUserIdAsync(int userId) => ServiceResult<AuthorResponseDto>.FromAsync(_repository.GetAuthorByUserIdAsync(userId), "Author not found.");
    public Task<ServiceResult<bool>> UpdateAuthorAsync(int id, UpdateAuthorDto author) => ServiceResult<bool>.FromAsync(_repository.UpdateAuthorAsync(id, author), "Author not found or update failed.");
    public Task<ServiceResult<bool>> DeleteAuthorAsync(int id) => ServiceResult<bool>.FromAsync(_repository.DeleteAuthorAsync(id), "Author not found.");
}
