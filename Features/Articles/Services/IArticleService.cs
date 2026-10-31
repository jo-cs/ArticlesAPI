using ArticlesAPI.Features.Articles.DTOs;

namespace ArticlesAPI.Features.Articles.Services;

public interface IArticleService
{
    Task<int> CreateArticleAsync(CreateArticleDto article);

    Task<ArticleResponseDto> GetArticleByIdAsync(int id);

    Task<IEnumerable<ArticleResponseDto>> GetAllArticlesAsync();

    Task<bool> UpdateArticleAsync(int id, UpdateArticleDto article);

    Task<bool> DeleteArticleAsync(int id);
    
    Task<IEnumerable<ArticleResponseDto>> SearchArticlesAsync(string search);
}