namespace Phone.Application.Contract.Common.APIResults;

public interface IAPIError
{
    public string Code { get; set; }
    public string Message { get; set; }
}
