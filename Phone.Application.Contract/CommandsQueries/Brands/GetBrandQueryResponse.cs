namespace Phone.Application.Contract.CommandsQueries.Brands;

public record GetBrandQueryResponse
{
    public short Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
}
