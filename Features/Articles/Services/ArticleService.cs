
using ArticlesAPI.Features.Articles.DTOs;
using ArticlesAPI.Features.Articles.Repositories;
using ArticlesAPI.Shared.DTOs;
using ArticlesAPI.Shared.Results;

namespace ArticlesAPI.Features.Articles.Services;

public class ArticleService : IArticleService
{
    private readonly IArticleRepository _repository;

    public ArticleService(IArticleRepository repository)
    {
        _repository = repository;
    }

    public async Task<ServiceResult<int>> CreateArticleAsync(
        CreateArticleDto article)
    {
        var articleId = await _repository.CreateArticleAsync(article);

        return ServiceResult<int>.Ok(articleId);
    }

    public async Task<ServiceResult<ArticleResponseDto>> GetArticleByIdAsync(
        int id)
    {
        var article = await _repository.GetArticleByIdAsync(id);

        if (article is null)
            return ServiceResult<ArticleResponseDto>.Failure(
                "Article not found.");

        return ServiceResult<ArticleResponseDto>.Ok(article);
    }

    public async Task<ServiceResult<IEnumerable<ArticleResponseDto>>> GetAllArticlesAsync()
    {
        var articles = await _repository.GetAllArticlesAsync();

        return ServiceResult<IEnumerable<ArticleResponseDto>>.Ok(articles);
    }

    public async Task<ServiceResult<bool>> UpdateArticleAsync(
        int id, UpdateArticleDto article)
    {
        var success = await _repository.UpdateArticleAsync(id, article);

        if (!success)
            return ServiceResult<bool>.Failure("Article not found or update failed.");

        return ServiceResult<bool>.Ok(true);
    }

    public async Task<ServiceResult<bool>> DeleteArticleAsync(int id)
    {
        var success = await _repository.DeleteArticleAsync(id);

        if (!success)
            return ServiceResult<bool>.Failure("Article not found or delete failed.");

        return ServiceResult<bool>.Ok(true);
    }

    public async Task<ServiceResult<IEnumerable<ArticleResponseDto>>> SearchArticlesAsync(string search)
    {
        if (string.IsNullOrWhiteSpace(search))
            return ServiceResult<IEnumerable<ArticleResponseDto>>
                .Failure("Search term is required.", 400);

        var articles = await _repository.SearchArticlesAsync(search);

        return ServiceResult<IEnumerable<ArticleResponseDto>>.Ok(articles);
    }

    public async Task<ServiceResult<PagedResponseDto<ArticleResponseDto>>> GetFilteredArticlesAsync(
        ArticleFilterDto filter)
    {
        var result = await _repository.GetFilteredArticlesAsync(filter);

        return ServiceResult<PagedResponseDto<ArticleResponseDto>>.Ok(result);
    }

    public async Task<ServiceResult<int>> CreateArticleWithRelationsAsync(
        CreateArticleWithRelationsDto article)
    {
        var articleId = await _repository.CreateArticleWithRelationsAsync(article);

        return ServiceResult<int>.Ok(articleId);
    }
}
