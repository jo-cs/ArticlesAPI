using ArticlesAPI.Features.Authors.DTOs;
namespace ArticlesAPI.Features.Authors.Services;
public interface IAuthorService
{
    Task<int> CreateAuthorAsync(CreateAuthorDto author);
    Task<IEnumerable<AuthorResponseDto>> GetAllAuthorsAsync();
    Task<AuthorResponseDto?> GetAuthorByIdAsync(int id);
    Task<AuthorResponseDto?> GetAuthorByUserIdAsync(int userId);
    Task<bool> UpdateAuthorAsync(int id, UpdateAuthorDto author);
    Task<bool> DeleteAuthorAsync(int id);
}
