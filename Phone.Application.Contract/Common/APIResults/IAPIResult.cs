namespace Phone.Application.Contract.Common.APIResults;

public interface IAPIResult
{
    bool Success { get; set; }

    List<IAPIError>? Errors { get; set; }
}

public interface IAPIResult<T> : IAPIResult
{
    T? Data { get; set; }
}