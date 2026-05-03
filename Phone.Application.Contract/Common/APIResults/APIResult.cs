namespace Phone.Application.Contract.Common.APIResults;

public class APIResult : IAPIResult
{
    public bool Success { get; set; }
    public List<IAPIError>? Errors { get; set; }

    public static APIResult Ok()
    {
        return new APIResult
        {
            Success = true
        };
    }

    public static APIResult Fail(string code, string message)
    {
        return new APIResult
        {
            Success = false,
            Errors = new List<IAPIError>
            {
                new APIError { Code = code, Message = message }
            }
        };
    }
}

public class APIResult<T> : APIResult, IAPIResult<T>
{
    public T? Data { get; set; }

    public static APIResult<T> Ok(T data)
    {
        return new APIResult<T>
        {
            Success = true,
            Data = data
        };
    }

    public new static APIResult<T> Fail(string code, string message)
    {
        return new APIResult<T>
        {
            Success = false,
            Errors = new List<IAPIError>
            {
                new APIError { Code = code, Message = message }
            }
        };
    }
}

