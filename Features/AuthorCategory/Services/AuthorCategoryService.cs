using ArticlesAPI.Features.AuthorCategory.DTOs;
using ArticlesAPI.Features.AuthorCategory.Repositories;
namespace ArticlesAPI.Features.AuthorCategory.Services;
public class AuthorCategoryService : IAuthorCategoryService
{
    private readonly IAuthorCategoryRepository _repository;
    public AuthorCategoryService(IAuthorCategoryRepository repository) => _repository = repository;
    public Task<bool> AddAuthorCategoryAsync(AddAuthorCategoryDto relation)
        => _repository.AddAuthorCategoryAsync(relation);
    public Task<IEnumerable<AuthorCategoryResponseDto>> GetCategoriesByAuthorIdAsync(int authorId)
        => _repository.GetCategoriesByAuthorIdAsync(authorId);
    public Task<bool> DeleteAuthorCategoryAsync(int authorId, int categoryId)
        => _repository.DeleteAuthorCategoryAsync(authorId, categoryId);
}
