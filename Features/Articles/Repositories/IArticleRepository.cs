using ArticlesAPI.Features.Articles.DTOs;
using ArticlesAPI.Shared.DTOs;

namespace ArticlesAPI.Features.Articles.Repositories;

public interface IArticleRepository
{
    Task<int> CreateArticleAsync(CreateArticleDto article);
    Task<ArticleResponseDto>  GetArticleByIdAsync(int id);
    Task<IEnumerable<ArticleResponseDto>>  GetAllArticlesAsync();
    Task<bool> UpdateArticleAsync(int id, UpdateArticleDto article);
    Task<bool> DeleteArticleAsync(int id);
    Task<IEnumerable<ArticleResponseDto>> SearchArticlesAsync(string search);
    Task<PagedResponseDto<ArticleResponseDto>> GetFilteredArticlesAsync(
        ArticleFilterDto filter);
    Task<int> CreateArticleWithRelationsAsync(
        CreateArticleWithRelationsDto article);
}