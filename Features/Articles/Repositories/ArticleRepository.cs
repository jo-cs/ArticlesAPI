using System.Data;
using Dapper;
using ArticlesAPI.Features.Articles.DTOs;
using ArticlesAPI.Infrastructure.Data;

namespace ArticlesAPI.Features.Articles.Repositories;

public class ArticleRepository : IArticleRepository
{
    private readonly DapperContext _context;
    public ArticleRepository(DapperContext context)
    {
        _context = context;
    }
    
    public async Task<int> CreateArticleAsync(CreateArticleDto article)
    {
        using var connection = _context.CreateConnection();

        var articleId = await connection.QuerySingleAsync<int>(
            "Article_Create",
            new
            {
                Name = article.Name,
                Title = article.Title,
                Details = article.Details,
                CategoryId = article.CategoryId,
                AuthorId = article.AuthorId

            },
            commandType: CommandType.StoredProcedure
        );
        return articleId;
    }

    public async Task<ArticleResponseDto> GetArticleByIdAsync(int id)
    {
        using var connection = _context.CreateConnection();

        var areticle = await connection.QuerySingleAsync<ArticleResponseDto>(
            "Article_GetById",
            new { Id = id },
            commandType: CommandType.StoredProcedure
        );
        return areticle;
    }

    public async Task<IEnumerable<ArticleResponseDto>> GetAllArticlesAsync()
    {
        using var connection = _context.CreateConnection();

        var article = await connection.QueryAsync<ArticleResponseDto>(
            "Article_GetAll",
            commandType: CommandType.StoredProcedure);
        return article;
    }

    public async Task<bool> UpdateArticleAsync(int id, UpdateArticleDto article)
    {
        using var connection = _context.CreateConnection();

        var success = await connection.QuerySingleAsync<bool>(
            "Article_Update",
            new
            {
                Id = id,
                Name = article.Name,
                Title = article.Title,
                Details = article.Details,
                CategoryId = article.CategoryId,
                AuthorId = article.AuthorId

            },
            commandType: CommandType.StoredProcedure
        );

        return success;
    }

    public async Task<bool> DeleteArticleAsync(int id)
    {
        using var connection = _context.CreateConnection();

        var success = await connection.QuerySingleAsync<bool>(
            "Article_Delete",
            new { Id = id },
            commandType: CommandType.StoredProcedure
            );

        return success;
    }
    
    public async Task<IEnumerable<ArticleResponseDto>> SearchArticlesAsync(string search)
    {
        using var connection = _context.CreateConnection();

        var articles = await connection.QueryAsync<ArticleResponseDto>(
            "Article_Search",
            new { Search = search },
            commandType: CommandType.StoredProcedure
        );

        return articles;
    }
    
}