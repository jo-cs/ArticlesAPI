using System.Data;
using Dapper;
using ArticlesAPI.Features.Articles.DTOs;
using ArticlesAPI.Infrastructure.Data;
using ArticlesAPI.Shared.DTOs;

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
             article.Name,
             article.Title,
               article.Details,
              article.CategoryId,
              article.AuthorId

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
    
    public async Task<PagedResponseDto<ArticleResponseDto>> GetFilteredArticlesAsync(
        ArticleFilterDto filter)
    {
        using var connection = _context.CreateConnection();

        using var multi = await connection.QueryMultipleAsync(
            "Article_GetFiltered",
            new
            {
                filter.Search,
                filter.CategoryId,
                filter.AuthorId,
                filter.SortBy,
                filter.SortOrder,
                filter.PageNumber,
                filter.PageSize
            },
            commandType: CommandType.StoredProcedure
        );

        var totalCount = await multi.ReadSingleAsync<int>();

        var items = (await multi.ReadAsync<ArticleResponseDto>()).ToList();

        return new PagedResponseDto<ArticleResponseDto>
        {
            Items = items,
            TotalCount = totalCount,
            PageNumber = filter.PageNumber,
            PageSize = filter.PageSize
        };
    }
    
    public async Task<int> CreateArticleWithRelationsAsync(
        CreateArticleWithRelationsDto article)
    {
        using var connection = _context.CreateConnection();

        var tagTable = new DataTable();

        tagTable.Columns.Add("TagId", typeof(int));

        foreach (var tagId in article.TagIds)
        {
            tagTable.Rows.Add(tagId);
        }

        var mediaTable = new DataTable();

        mediaTable.Columns.Add("MediaUrl", typeof(string));
        mediaTable.Columns.Add("Type", typeof(int));

        foreach (var media in article.Media)
        {
            mediaTable.Rows.Add(media.MediaUrl, media.Type);
        }

        var parameters = new DynamicParameters();

        parameters.Add("@Name", article.Name);
        parameters.Add("@Title", article.Title);
        parameters.Add("@Details", article.Details);
        parameters.Add("@CategoryId", article.CategoryId);
        parameters.Add("@AuthorId", article.AuthorId);

        parameters.Add(
            "@TagIds",
            tagTable.AsTableValuedParameter("dbo.TagIdList")
        );

        parameters.Add(
            "@Media",
            mediaTable.AsTableValuedParameter("dbo.MediaInputList")
        );

        return await connection.QuerySingleAsync<int>(
            "Article_CreateWithRelations",
            parameters,
            commandType: CommandType.StoredProcedure
        );
    }
    
}