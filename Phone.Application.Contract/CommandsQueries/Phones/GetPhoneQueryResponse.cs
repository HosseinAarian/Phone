namespace Phone.Application.Contract.CommandsQueries.Phones;

public record GetPhoneQueryResponse
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }

    public List<GetPhoneDetailQueryResponse> PhoneDetails { get; set; } = new List<GetPhoneDetailQueryResponse>();
}

public record GetPhoneDetailQueryResponse
{
    public int Id { get; set; }
    public required string Color { get; set; }
    public required string OS { get; set; }
    public required string Hard { get; set; }
    public required string Ram { get; set; }
}
