namespace Phone.Application.Contract.CommandsQueries.Phones;

public record GetAllPhoneQueryResponse
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }

    public List<GetAllPhoneDetailQueryResponse> PhoneDetails { get; set; } = new List<GetAllPhoneDetailQueryResponse>();
}

public record GetAllPhoneDetailQueryResponse
{
    public int Id { get; set; }
    public required string Color { get; set; }
    public required string OS { get; set; }
    public required string Hard { get; set; }
    public required string Ram { get; set; }
}
