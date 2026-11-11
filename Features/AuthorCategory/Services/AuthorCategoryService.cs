using ArticlesAPI.Features.AuthorCategory.DTOs;
using ArticlesAPI.Features.AuthorCategory.Repositories;
using ArticlesAPI.Shared.Results;
namespace ArticlesAPI.Features.AuthorCategory.Services;
public class AuthorCategoryService : IAuthorCategoryService
{
    private readonly IAuthorCategoryRepository _repository;
    public AuthorCategoryService(IAuthorCategoryRepository repository) => _repository = repository;
    public Task<ServiceResult<bool>> AddAuthorCategoryAsync(AddAuthorCategoryDto relation) => ServiceResult<bool>.FromAsync(_repository.AddAuthorCategoryAsync(relation), "This author-category relation already exists.", 409);
    public Task<ServiceResult<IEnumerable<AuthorCategoryResponseDto>>> GetCategoriesByAuthorIdAsync(int authorId) => ServiceResult<IEnumerable<AuthorCategoryResponseDto>>.FromAsync(_repository.GetCategoriesByAuthorIdAsync(authorId), "Categories could not be retrieved.", 500);
    public Task<ServiceResult<bool>> DeleteAuthorCategoryAsync(int authorId, int categoryId) => ServiceResult<bool>.FromAsync(_repository.DeleteAuthorCategoryAsync(authorId, categoryId), "Author-category relation not found.");
}
