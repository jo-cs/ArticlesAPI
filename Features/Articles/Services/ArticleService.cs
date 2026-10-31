using ArticlesAPI.Features.Articles.DTOs;
using ArticlesAPI.Features.Articles.Repositories;

namespace ArticlesAPI.Features.Articles.Services;

public class ArticleService : IArticleService
{
    
    private readonly IArticleRepository _repository;

    public ArticleService(IArticleRepository repository)
    {
        _repository = repository;
    }
    
    public Task<int> CreateArticleAsync(CreateArticleDto article)
    {
        return _repository.CreateArticleAsync(article);
    }

    public Task<ArticleResponseDto> GetArticleByIdAsync(int id)
    {
        return _repository.GetArticleByIdAsync(id);
    }

    public Task<IEnumerable<ArticleResponseDto>> GetAllArticlesAsync()
    {
        return _repository.GetAllArticlesAsync();
    }

    public Task<bool> UpdateArticleAsync(int id, UpdateArticleDto article)
    {
        return _repository.UpdateArticleAsync(id, article);
    }

    public Task<bool> DeleteArticleAsync(int id)
    {
        return _repository.DeleteArticleAsync(id);
    }
    
    public Task<IEnumerable<ArticleResponseDto>> SearchArticlesAsync(string search)
    {
        return _repository.SearchArticlesAsync(search);
    }
}