using ArticlesAPI.Features.Authors.DTOs;
using ArticlesAPI.Shared.Results;
namespace ArticlesAPI.Features.Authors.Services;
public interface IAuthorService
{
    Task<ServiceResult<int>> CreateAuthorAsync(CreateAuthorDto author);
    Task<ServiceResult<IEnumerable<AuthorResponseDto>>> GetAllAuthorsAsync();
    Task<ServiceResult<AuthorResponseDto>> GetAuthorByIdAsync(int id);
    Task<ServiceResult<AuthorResponseDto>> GetAuthorByUserIdAsync(int userId);
    Task<ServiceResult<bool>> UpdateAuthorAsync(int id, UpdateAuthorDto author);
    Task<ServiceResult<bool>> DeleteAuthorAsync(int id);
}
