namespace Phone.Application.Contract.Common.APIResults;

public class APIError : IAPIError
{
    public string Code { get; set; } = default!;
    public string Message { get; set; } = default!;
}
