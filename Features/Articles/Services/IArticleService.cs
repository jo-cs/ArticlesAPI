using ArticlesAPI.Features.Articles.DTOs;
using ArticlesAPI.Shared.DTOs;
using ArticlesAPI.Shared.Results;

namespace ArticlesAPI.Features.Articles.Services;

public interface IArticleService
{
    Task<ServiceResult<int>> CreateArticleAsync(CreateArticleDto article);

    Task<ServiceResult<ArticleResponseDto>> GetArticleByIdAsync(int id);

    Task<ServiceResult<IEnumerable<ArticleResponseDto>>> GetAllArticlesAsync();

    Task<ServiceResult<bool>> UpdateArticleAsync(int id, UpdateArticleDto article);

    Task<ServiceResult<bool>> DeleteArticleAsync(int id);

    Task<ServiceResult<IEnumerable<ArticleResponseDto>>> SearchArticlesAsync(string search);

    Task<ServiceResult<PagedResponseDto<ArticleResponseDto>>> GetFilteredArticlesAsync(
        ArticleFilterDto filter);

    Task<ServiceResult<int>> CreateArticleWithRelationsAsync(
        CreateArticleWithRelationsDto article);
}