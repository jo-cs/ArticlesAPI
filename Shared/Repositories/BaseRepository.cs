using System.Data;
using Dapper;
using ArticlesAPI.Infrastructure.Data;

namespace ArticlesAPI.Shared.Repositories;

public abstract class BaseRepository
{
    protected readonly DapperContext Context;

    protected BaseRepository(DapperContext context)
    {
        Context = context;
    }

    protected async Task<T> QuerySingleAsync<T>(
        string procedureName,
        object? parameters = null)
    {
        using var connection = Context.CreateConnection();

        return await connection.QuerySingleAsync<T>(
            procedureName,
            parameters,
            commandType: CommandType.StoredProcedure
        );
    }

    protected async Task<T?> QuerySingleOrDefaultAsync<T>(
        string procedureName,
        object? parameters = null)
    {
        using var connection = Context.CreateConnection();

        return await connection.QuerySingleOrDefaultAsync<T>(
            procedureName,
            parameters,
            commandType: CommandType.StoredProcedure
        );
    }

    protected async Task<IEnumerable<T>> QueryAsync<T>(
        string procedureName,
        object? parameters = null)
    {
        using var connection = Context.CreateConnection();

        return await connection.QueryAsync<T>(
            procedureName,
            parameters,
            commandType: CommandType.StoredProcedure
        );
    }
    
    protected async Task<TResult> QueryMultipleAsync<TResult>(
        string procedureName,
        object? parameters,
        Func<SqlMapper.GridReader, Task<TResult>> map)
    {
        using var connection = Context.CreateConnection();

        using var multi = await connection.QueryMultipleAsync(
            procedureName,
            parameters,
            commandType: CommandType.StoredProcedure
        );

        return await map(multi);
    }
}
