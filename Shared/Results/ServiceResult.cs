namespace ArticlesAPI.Shared.Results;

public class ServiceResult<T>
{
    public T? Data { get; set; }

    public string? Error { get; set; }

    public int StatusCode { get; set; } = 200;

    public bool Success => Error == null;

    public ServiceResult()
    {
    }

    // Success Constructor
    public ServiceResult(T? data)
    {
        Data = data;
        StatusCode = 200;
    }

    // Failure Constructor
    public ServiceResult(string? error, int statusCode)
    {
        Error = error;
        StatusCode = statusCode;
    }

    public static ServiceResult<T> Ok(T? data)
        => new(data);

    public static ServiceResult<T> Failure(
        string error,
        int statusCode = 400)
        => new(error, statusCode);

    public static async Task<ServiceResult<T>> FromAsync(
        Task<T> operation,
        string failureMessage,
        int failureStatusCode = 404)
    {
        var data = await operation;

        if (data is null || data is bool success && !success)
            return Failure(failureMessage, failureStatusCode);

        return Ok(data);
    }
}
