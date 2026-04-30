using MediatR;

namespace Phone.Application.Contract.CommandsQueries.Brands;

public record UpdateBrandCommand : IRequest<UpdateBrandCommandResponse>
{
    public short Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
}
