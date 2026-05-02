using MediatR;
using Phone.Application.Contract.Common.Attributes;

namespace Phone.Application.Contract.CommandsQueries.Phones;

[InvalidateCache("phones:all")]
public class UpdatePhoneCommand : IRequest<int>
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }

    public List<UpdatePhoneDetailsCommand> PhoneDetails { get; set; }
}

public record UpdatePhoneDetailsCommand
{
    public int Id { get; set; }
    public required string Color { get; set; }
    public required string OS { get; set; }
    public required string Hard { get; set; }
    public required string Ram { get; set; }
}
