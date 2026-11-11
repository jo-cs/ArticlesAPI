using System.Data;
using Dapper;
using ArticlesAPI.Features.Articles.DTOs;
using ArticlesAPI.Infrastructure.Data;
using ArticlesAPI.Shared.DTOs;
using ArticlesAPI.Shared.Repositories;
namespace ArticlesAPI.Features.Articles.Repositories;
public class ArticleRepository : BaseRepository, IArticleRepository
{
    public ArticleRepository(DapperContext context) : base(context) { }
    public Task<int> CreateArticleAsync(CreateArticleDto article) => QuerySingleAsync<int>("Article_Create", new { article.Name, article.Title, article.Details, article.CategoryId, article.AuthorId });
    public Task<ArticleResponseDto> GetArticleByIdAsync(int id) => QuerySingleAsync<ArticleResponseDto>("Article_GetById", new { Id = id });
    public Task<IEnumerable<ArticleResponseDto>> GetAllArticlesAsync() => QueryAsync<ArticleResponseDto>("Article_GetAll");
    public Task<bool> UpdateArticleAsync(int id, UpdateArticleDto article) => QuerySingleAsync<bool>("Article_Update", new { Id = id, article.Name, article.Title, article.Details, article.CategoryId, article.AuthorId });
    public Task<bool> DeleteArticleAsync(int id) => QuerySingleAsync<bool>("Article_Delete", new { Id = id });
    public Task<IEnumerable<ArticleResponseDto>> SearchArticlesAsync(string search) => QueryAsync<ArticleResponseDto>("Article_Search", new { Search = search });
    public Task<PagedResponseDto<ArticleResponseDto>> GetFilteredArticlesAsync(ArticleFilterDto filter)
        => QueryMultipleAsync("Article_GetFiltered", new { filter.Search, filter.CategoryId, filter.AuthorId, filter.SortBy, filter.SortOrder, filter.PageNumber, filter.PageSize }, async multi =>
        {
            var totalCount = await multi.ReadSingleAsync<int>();
            var items = (await multi.ReadAsync<ArticleResponseDto>()).ToList();
            return new PagedResponseDto<ArticleResponseDto> { Items = items, TotalCount = totalCount, PageNumber = filter.PageNumber, PageSize = filter.PageSize };
        });

    public async Task<int> CreateArticleWithRelationsAsync(CreateArticleWithRelationsDto article)
    {
        var tagTable = new DataTable();
        tagTable.Columns.Add("TagId", typeof(int));
        foreach (var tagId in article.TagIds) tagTable.Rows.Add(tagId);
        var mediaTable = new DataTable();
        mediaTable.Columns.Add("MediaUrl", typeof(string));
        mediaTable.Columns.Add("Type", typeof(int));
        foreach (var media in article.Media) mediaTable.Rows.Add(media.MediaUrl, media.Type);
        var parameters = new DynamicParameters();
        parameters.Add("@Name", article.Name);
        parameters.Add("@Title", article.Title);
        parameters.Add("@Details", article.Details);
        parameters.Add("@CategoryId", article.CategoryId);
        parameters.Add("@AuthorId", article.AuthorId);
        parameters.Add("@TagIds", tagTable.AsTableValuedParameter("dbo.TagIdList"));
        parameters.Add("@Media", mediaTable.AsTableValuedParameter("dbo.MediaInputList"));
        return await QuerySingleAsync<int>("Article_CreateWithRelations", parameters);
    }
}
