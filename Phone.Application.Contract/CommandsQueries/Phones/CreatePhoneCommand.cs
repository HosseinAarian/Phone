using MediatR;

namespace Phone.Application.Contract.CommandsQueries.Phones;

public record CreatePhoneCommand : IRequest<int>
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public List<CreatePhoneDetailsCommand> PhoneDetails { get; set; }
}

public record CreatePhoneDetailsCommand
{
    public required string Color { get; set; }
    public required string OS { get; set; }
    public required string Hard { get; set; }
    public required string Ram { get; set; }
}
